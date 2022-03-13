namespace LocationsdeVehicules;

public class Reservations
{
    public Clients Client { get; private set; }
    public Vehicules Vehicule { get; private set; }
    public DateTime DateDebut { get; private set; }
    public DateTime DateFin { get; private set; }

    public Reservations(Clients client, Vehicules vehicule, DateTime dateDebut, DateTime dateFin)
    {
        this.Client = client;
        this.Vehicule = vehicule;
        this.DateDebut = dateDebut;
        this.DateFin = dateFin;
    }
}