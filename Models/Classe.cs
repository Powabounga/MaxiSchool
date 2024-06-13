using System.Collections.Generic;

namespace MaxiSchool.Models;


public class Classe
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<Eleve> Eleves { get; set; }
}