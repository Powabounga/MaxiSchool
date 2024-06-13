namespace MaxiSchool.Models;


public class Eleve
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int ClasseId { get; set; }
    public Classe Classe { get; set; }
}