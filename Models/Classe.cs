using System.Collections.Generic;

namespace MaxiSchool.Models;


public class Classe
{
    public int ClasseId { get; set; }
    public string? Name { get; set; }
    public ICollection<Eleve> Eleves { get; set; } = new List<Eleve>();
}