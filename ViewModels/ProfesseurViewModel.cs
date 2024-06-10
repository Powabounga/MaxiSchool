using MaxiSchool.Data;
using MaxiSchool.Models;
using System.Collections.ObjectModel;
using System.Reactive;
using ReactiveUI;
using System;

namespace MaxiSchool.ViewModels;

public class ProfesseurViewModel : BaseViewModel
{
    private readonly SchoolContext _context;
    public ObservableCollection<Professeur> Professeurs { get; } = new();
    public Professeur? _selectedProfesseur;
    public string? _newProfesseurFirstName;
    public string? _newProfesseurLastName;
    public ReactiveCommand<Unit, Unit> LoadProfesseursCommand { get; }
    public ReactiveCommand<Unit, Unit> AddProfesseurCommand { get; }
    public ReactiveCommand<Unit, Unit> DeleteProfesseurCommand { get; }

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

    public Professeur SelectedProfesseur
    {
        get => _selectedProfesseur;
        set => this.RaiseAndSetIfChanged(ref _selectedProfesseur, value);
    }
    public ProfesseurViewModel()
    {
        _context = new SchoolContext();
        LoadProfesseursCommand = ReactiveCommand.Create(LoadProfesseurs);
        AddProfesseurCommand = ReactiveCommand.Create(AddProfesseur);
        DeleteProfesseurCommand = ReactiveCommand.Create(DeleteProfesseur);
        LoadProfesseursCommand.Execute().Subscribe();
    }

    private void LoadProfesseurs()
    {
        Professeurs.Clear();
        foreach (var professeur in _context.Professeurs)
        {
            Professeurs.Add(professeur);
        }
    }

    private void AddProfesseur()
    {
        if (!string.IsNullOrWhiteSpace(NewProfesseurFirstName) && !string.IsNullOrWhiteSpace(NewProfesseurLastName))
        {
            var professeur = new Professeur { FirstName = NewProfesseurFirstName, LastName = NewProfesseurLastName };
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
