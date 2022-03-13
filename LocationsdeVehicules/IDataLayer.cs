namespace LocationsdeVehicules;

public interface IDataLayer
{
    List<Clients> Clients { get; set; }
    List<Vehicules> Vehicules { get; set; }
    List<Reservations> Reservations { get; set; }
    
}