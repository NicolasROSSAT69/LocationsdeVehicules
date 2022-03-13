using System;
using System.Globalization;
using System.Linq;
namespace LocationsdeVehicules;

public class Location
{
    private IDataLayer _dataLayer;
    public bool Connected { get; set; }
    public bool Reservated { get; set; }
    public bool ReservationFinie { get; set; }
    public List<Reservations> Reservations { get; set; }
    
    public List<string> VehiculeDispo { get; set; }

    public Location()
    {
        this._dataLayer = new DataLayer();
    }
    
    public Location(IDataLayer dataLayer)
    {
        this._dataLayer = dataLayer;
        this.Reservations = new List<Reservations>();
        this.VehiculeDispo = new List<string>();
    }

    public void ConnectUser(string username, string password)
    {
        Clients client = this._dataLayer.Clients.SingleOrDefault(_ => _.Username == username);
        if (client != null && client.Password == password)
        {
            this.Connected = true;
        }
    }

    public List<string> FournirListVehiculeDispoAuClient(DateTime dateDebut, DateTime dateFin)
    {
        Reservations reservation = this._dataLayer.Reservations.SingleOrDefault(_ => _.DateDebut == dateDebut && _.DateFin == dateFin);
        if (reservation == null)
        {
            foreach (Vehicules r in this._dataLayer.Vehicules)
            {
                this.VehiculeDispo.Add(r.Modele + ": " + r.Immatriculation);
            }
        }else
        {
            foreach (Vehicules r in this._dataLayer.Vehicules)
            {
                if (reservation.Vehicule.Immatriculation != r.Immatriculation)
                {
                    this.VehiculeDispo.Add(r.Modele + ": " + r.Immatriculation);
                }
            }
        }
        return this.VehiculeDispo;
    }

    public void CreerReservation(string username, DateTime dateDebut, DateTime dateFin, string immatriculation)
    {
        Clients client = this._dataLayer.Clients.SingleOrDefault(_ => _.Username == username);
        Vehicules vehicule = this._dataLayer.Vehicules.SingleOrDefault(_ => _.Immatriculation == immatriculation);
        Reservations reservation = this._dataLayer.Reservations.SingleOrDefault(_ => _.DateDebut == dateDebut && _.DateFin == dateFin && _.Vehicule == vehicule);
        Reservations AutreReservationDuMemeClient = this._dataLayer.Reservations.SingleOrDefault(_ => _.Client == client);
        TimeSpan AgeClient = DateTime.Today.Subtract(client.DateNaissance);
        if (client != null && this.Connected == true && vehicule != null && AgeClient >= TimeSpan.Parse("6570"))
        {
            if (reservation == null && AutreReservationDuMemeClient == null)
            {
                if (AgeClient < TimeSpan.Parse("7665") && vehicule.ChevauxFiscaux >= 8)
                {
                    this.Reservated = false;
                }
                else if (AgeClient >= TimeSpan.Parse("7665") && AgeClient < TimeSpan.Parse("9125") && vehicule.ChevauxFiscaux > 13)
                {
                    this.Reservated = false;
                }
                else
                {
                    this.Reservations.Add(new Reservations(client, vehicule, dateDebut, dateFin));
                    this.Reservated = true;
                }
                
            }else
            {
                this.Reservated = false;
            }
        }else
        {
            this.Reservated = false;
        }
        
    }

    public string CalculerPrixReservation(string nomClient, int nbrKilometreParcouru)
    {
        string result;
        Reservations reservation = this._dataLayer.Reservations.SingleOrDefault(_ => _.Client.Username == nomClient);
        
        if (reservation != null)
        {
            
            if (this.ReservationFinie == true)
            {
                
                int prixLocation = reservation.Vehicule.PrixReservation +
                                   reservation.Vehicule.TarifKilometrique * nbrKilometreParcouru;
                result = Convert.ToString(prixLocation);
                
                return result;
                
            }
            
            return "La Location n'est pas fini";
            
        }

        return "La location n'existe pas";

    }
   
}