using System.Collections.Generic;

namespace MaxiSchool.Models;


public class Matiere
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<Professeur> Professeurs { get; set; }
}