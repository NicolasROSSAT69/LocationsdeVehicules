namespace LocationsdeVehicules;

public class Clients
{
    public string Username { get; private set; }
    public string Password { get; private set; }
    public string Nom { get; private set; }
    public string Prenom { get; private set; }
    
    public DateTime DateNaissance { get; set; }
    public DateTime DatePermis { get; private set; }
    public long NumeroPermis { get; private set; }

    public Clients(string username, string password, string nom, string prenom, DateTime datePermis, long numeroPermis)
    {
        this.Username = username;
        this.Password = password;
        this.Nom = nom;
        this.Prenom = prenom;
        this.DatePermis = datePermis;
        this.NumeroPermis = numeroPermis;
    }
}