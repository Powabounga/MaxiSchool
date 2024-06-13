using MaxiSchool.Data;
using MaxiSchool.Models;
using System.Collections.ObjectModel;
using System.Reactive;
using ReactiveUI;
using System;
using Microsoft.EntityFrameworkCore;

namespace MaxiSchool.ViewModels;

public class ProfesseurViewModel : BaseViewModel
{
    private readonly SchoolContext _context;
    private string _newProfesseurFirstName;
    private string _newProfesseurLastName;
    private Matiere _selectedMatiere;
    private Professeur _selectedProfesseur;

    public ObservableCollection<Professeur> Professeurs { get; } = new();
    public ObservableCollection<Matiere> Matieres { get; } = new();

    public string NewProfesseurFirstName
    {
        get => _newProfesseurFirstName;
        set => this.RaiseAndSetIfChanged(ref _newProfesseurFirstName, value);
    }

    public string NewProfesseurLastName
    {
        get => _newProfesseurLastName;
        set => this.RaiseAndSetIfChanged(ref _newProfesseurLastName, value);
    }

    public Matiere SelectedMatiere
    {
        get => _selectedMatiere;
        set => this.RaiseAndSetIfChanged(ref _selectedMatiere, value);
    }

    public Professeur SelectedProfesseur
    {
        get => _selectedProfesseur;
        set => this.RaiseAndSetIfChanged(ref _selectedProfesseur, value);
    }

    public ReactiveCommand<Unit, Unit> LoadProfesseursCommand { get; }
    public ReactiveCommand<Unit, Unit> LoadMatieresCommand { get; }
    public ReactiveCommand<Unit, Unit> AddProfesseurCommand { get; }
    public ReactiveCommand<Unit, Unit> DeleteProfesseurCommand { get; }

    public ProfesseurViewModel()
    {
        _context = new SchoolContext();
        LoadProfesseursCommand = ReactiveCommand.Create(LoadProfesseurs);
        LoadMatieresCommand = ReactiveCommand.Create(LoadMatieres);
        AddProfesseurCommand = ReactiveCommand.Create(AddProfesseur);
        DeleteProfesseurCommand = ReactiveCommand.Create(DeleteProfesseur);

        LoadProfesseursCommand.Execute().Subscribe();
        LoadMatieresCommand.Execute().Subscribe();
    }

    private void LoadProfesseurs()
    {
        Professeurs.Clear();
        foreach (var professeur in _context.Professeurs.Include(p => p.Matiere))
        {
            Professeurs.Add(professeur);
        }
    }

    private void LoadMatieres()
    {
        Matieres.Clear();
        foreach (var matiere in _context.Matieres)
        {
            Matieres.Add(matiere);
        }
    }

    private void AddProfesseur()
    {
        if (!string.IsNullOrWhiteSpace(NewProfesseurFirstName) && !string.IsNullOrWhiteSpace(NewProfesseurLastName) && SelectedMatiere != null)
        {
            var professeur = new Professeur { FirstName = NewProfesseurFirstName, LastName = NewProfesseurLastName, MatiereId = SelectedMatiere.Id };
            _context.Professeurs.Add(professeur);
            _context.SaveChanges();
            LoadProfesseurs();
            NewProfesseurFirstName = string.Empty;
            NewProfesseurLastName = string.Empty;
        }
    }

    private void DeleteProfesseur()
    {
        if (SelectedProfesseur != null)
        {
            _context.Professeurs.Remove(SelectedProfesseur);
            _context.SaveChanges();
            LoadProfesseurs();
        }
    }
}