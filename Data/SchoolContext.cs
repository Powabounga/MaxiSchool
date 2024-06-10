using System;
using MaxiSchool.Models;
using Microsoft.EntityFrameworkCore;

namespace MaxiSchool.Data;

public class SchoolContext : DbContext
{
    public DbSet<Classe> Classes { get; set; }
    public DbSet<Matiere> Matieres { get; set; }
    public DbSet<Eleve> Eleves { get; set; }
    public DbSet<Professeur> Professeurs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySql("Server=localhost;Database=maxischool;User=root;Password=password;",
            new MySqlServerVersion(new Version(8, 0, 21)));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Classe>().ToTable("Classes");
        modelBuilder.Entity<Matiere>().ToTable("Matieres");
        modelBuilder.Entity<Eleve>().ToTable("Eleves");
        modelBuilder.Entity<Professeur>().ToTable("Professeurs");
    }
}
