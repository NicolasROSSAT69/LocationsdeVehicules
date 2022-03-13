using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentAssertions;
using LocationsdeVehicules;
using SpecFlowLocationsDeVehicules.Fake;
using TechTalk.SpecFlow;

namespace SpecFlowLocationsDeVehicules.Steps;

[Binding]
public sealed class LocationStepDefinitions
{
    // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

    private readonly ScenarioContext _scenarioContext;

    private string _username;
    private string _password;
    private DateTime _dateDebut;
    private DateTime _dateFin;
    private List<string> _listVehiculeDispo;
    private string _strVehiculesDispos;
    private string _immatriculation;
    private Location _location;
    private FakeDataLayer _fakeDataLayer;
    private int _nbrKilometreParcouru;
    private string _result;

    public LocationStepDefinitions(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
        this._fakeDataLayer = new FakeDataLayer();
        this._location = new Location(this._fakeDataLayer);
        this._listVehiculeDispo = new List<string>();
    }
    
    [Given(@"client existant")]
    public void GivenClientExistant(Table table)
    {
        foreach (TableRow row in table.Rows)
        {
            this._fakeDataLayer.Clients.Add(new Clients(row[0], row[1], row[2], row[3], DateTime.Parse(row[4]), long.Parse(row[5])));
        }
    }
    
    [Given(@"vehicule existant")]
    public void GivenVehiculeExistant(Table table)
    {
        foreach (TableRow row in table.Rows)
        {
            this._fakeDataLayer.Vehicules.Add(new Vehicules(row[0], row[1], row[2], row[3], int.Parse(row[4]), int.Parse(row[5]), int.Parse(row[6])));
        }
    }
    
    [Given(@"réservations existantes")]
    public void GivenReservationsExistantes(Table table)
    {
        foreach (TableRow row in table.Rows)
        {
            Clients client = this._fakeDataLayer.Clients.SingleOrDefault(_ => _.Username == row[0]);
            Vehicules vehicules = this._fakeDataLayer.Vehicules.SingleOrDefault(_ => _.Immatriculation == row[1]);
            this._fakeDataLayer.Reservations.Add(new Reservations(client, vehicules, DateTime.Parse(row[2]), DateTime.Parse(row[3])));
        }
    }

    [Given(@"mon nom est ""(.*)""")]
    public void GivenMonNomEst(string username)
    {
        this._username = username;
    }

    [Given(@"mon mot de passe est ""(.*)""")]
    public void GivenMonMotDePasseEst(string password)
    {
        this._password = password;
    }

    [When(@"j'essaye de me connecter à mon compte")]
    public void WhenJessayeDeMeConnecterAMonCompte()
    {
        this._location.ConnectUser(this._username, this._password);
    }

    [Then(@"la connexion est établie")]
    public void ThenLaConnexionEstEtablie()
    {
        this._location.Connected.Should().BeTrue();
    }


    [Then(@"la connexion n'est pas établie")]
    public void ThenLaConnexionNestPasEtablie()
    {
        this._location.Connected.Should().BeFalse();
    }

    [Given(@"le nom de l'utilisateur est ""(.*)""")]
    public void GivenLeNomDeLutilisateurEst(string userName)
    {
        this._username = userName;
    }
    
    [Given(@"l'utilisateur est connecté")]
    public void GivenLutilisateurEstConnecte()
    {
        this._location.Connected = true;
    }
    
    [Given(@"utilisateur pas connecté")]
    public void GivenUtilisateurPasConnecte()
    {
        this._location.Connected = false;
    }
    
    [Given(@"La date de naissance de l'utilisateur est ""(.*)""")]
    public void GivenLaDateDeNaissanceDeLutilisateurEst(string dateNaissance)
    {
        Clients client = this._fakeDataLayer.Clients.SingleOrDefault(_ => _.Username == _username);
        client.DateNaissance = DateTime.Parse(dateNaissance);
    }

    [Given(@"la date de début de location est ""(.*)""")]
    public void GivenLaDateDeDebutDeLocationEst(string dateDebut)
    {
        this._dateDebut = DateTime.Parse(dateDebut);
    }

    [Given(@"la date de fin de location est ""(.*)""")]
    public void GivenLaDateDeFinDeLocationEst(string dateFin)
    {
        this._dateFin = DateTime.Parse(dateFin);
    }
    
    [Given(@"le véhicule choisi est ""(.*)""")]
    public void GivenLeVehiculeChoisiEst(string immatriculation)
    {
        this._immatriculation = immatriculation;
    }

    [When(@"je fais la reservation")]
    public void WhenJeFaisLaReservation()
    {
        this._location.CreerReservation(this._username, this._dateDebut, this._dateFin, this._immatriculation);
    }
    
    [Then(@"la reservation est faite")]
    public void ThenLaReservationEstFaite()
    {
        this._location.Reservated.Should().BeTrue();
    }


    [Then(@"la reservation n'est pas faite")]
    public void ThenLaReservationNestPasFaite()
    {
        this._location.Reservated.Should().BeFalse();
    }

    [Given(@"la date de debut de la reservation du client est ""(.*)""")]
    public void GivenLaDateDeDebutDeLaReservationDuClientEst(string dateDebut)
    {
        this._dateDebut = DateTime.Parse(dateDebut);
    }

    [Given(@"la date de fin de la reservation du client est ""(.*)""")]
    public void GivenLaDateDeFinDeLaReservationDuClientEst(string dateFin)
    {
        this._dateFin = DateTime.Parse(dateFin);
    }

    [When(@"la liste des voitures dispos est fournit au client")]
    public void WhenLaListeDesVoituresDisposEstFournitAuClient()
    {
        this._listVehiculeDispo = this._location.FournirListVehiculeDispoAuClient(this._dateDebut, this._dateFin);
    }

    [Then(@"la liste est ""(.*)""")]
    public void ThenLaListeEst(string list)
    {
        this._strVehiculesDispos = this._listVehiculeDispo.Aggregate((x, y) => x + ", " + y);
        this._strVehiculesDispos.Should().ContainAll(list);
    }

    [Given(@"la location est au nom de ""(.*)""")]
    public void GivenLaLocationEstAuNomDe(string nomClient)
    {
        this._username = nomClient;
    }

    [Given(@"la location est terminé")]
    public void GivenLaLocationEstTermine()
    {
        this._location.ReservationFinie = true;
    }

    [Given(@"le nombre de kilomètre parcouru est (.*)")]
    public void GivenLeNombreDeKilometreParcouruEst(int kilometre)
    {
        this._nbrKilometreParcouru = kilometre;
    }

    [When(@"J'essaye de calculer la location")]
    public void WhenJessayeDeCalculerLaLocation()
    {
        this._result = this._location.CalculerPrixReservation(this._username, this._nbrKilometreParcouru);
    }

    [Then(@"le prix de la location est ""(.*)""")]
    public void ThenLePrixDeLaLocationEst(string result)
    {
        this._result.Should().Be(result);
    }

    [Given(@"la location n'est pas terminé")]
    public void GivenLaLocationNestPasTermine()
    {
        this._location.ReservationFinie = false;
    }
}