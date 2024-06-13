using System.Collections.Generic;

namespace MaxiSchool.Models;

public class Professeur
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int MatiereId { get; set; }
    public Matiere Matiere { get; set; }
}