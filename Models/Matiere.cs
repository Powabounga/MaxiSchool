using System.Collections.Generic;

namespace MaxiSchool.Models;


public class Matiere
{
    public int MatiereId { get; set; }
    public string? Name { get; set; }
    public List<Professeur>? Professeurs { get; set; }
}