namespace LocationsdeVehicules;

public class Vehicules
{
    public string Immatriculation { get; private set; }
    public string Marque { get; private set; }
    public string Modele { get; private set; }
    public string Couleur { get; private set; }
    public int TarifKilometrique { get; private set; }
    public int PrixReservation { get; private set; }
    public int ChevauxFiscaux { get; private set; }

    public Vehicules(string immatriculation, string marque , string modele, string couleur, int tarifKilometrique, int prixReservation, int chevauxFiscaux)
    {
        this.Immatriculation = immatriculation;
        this.Marque = marque;
        this.Modele = modele;
        this.Couleur = couleur;
        this.TarifKilometrique = tarifKilometrique;
        this.PrixReservation = prixReservation;
        this.ChevauxFiscaux = chevauxFiscaux;
    }
}