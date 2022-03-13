using LocationsdeVehicules;

namespace SpecFlowLocationsDeVehicules.Fake;

public class FakeDataLayer : IDataLayer
{
    public List<Clients> Clients { get; set; }
    public List<Vehicules> Vehicules { get; set; }
    public List<Reservations> Reservations { get; set; }


    public FakeDataLayer()
    {
        this.Clients = new List<Clients>();
        this.Vehicules = new List<Vehicules>();
        this.Reservations = new List<Reservations>();
    }
}