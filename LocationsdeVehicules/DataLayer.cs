namespace LocationsdeVehicules;

public class DataLayer : IDataLayer
{
    public List<Clients> Clients { get; set; }
    public List<Vehicules> Vehicules { get; set; }
    public List<Reservations> Reservations { get; set; }
    
    public DataLayer()
    {
        this.Clients = new List<Clients>();
        this.Vehicules = new List<Vehicules>();
        this.Reservations = new List<Reservations>();
    }
}