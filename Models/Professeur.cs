using System.Collections.Generic;

namespace MaxiSchool.Models;

public class Professeur
{
    public int ProfesseurId { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public List<Matiere>? Matieres { get; set; }
}