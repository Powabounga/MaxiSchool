using System;
using MaxiSchool.Data;
using MaxiSchool.Models;
using System.Collections.ObjectModel;
using System.Reactive;
using ReactiveUI;


namespace MaxiSchool.ViewModels;


public class MatiereViewModel : BaseViewModel
{
    private readonly SchoolContext _context;
    public ObservableCollection<Matiere> Matieres { get; } = new();
    public Matiere? _selectedMatiere;
    public string? _newMatiereName;
    public ReactiveCommand<Unit, Unit> LoadMatieresCommand { get; }
    public ReactiveCommand<Unit, Unit> AddMatiereCommand { get; }
    public ReactiveCommand<Unit, Unit> DeleteMatiereCommand { get; }

    public string NewMatiereName
    {
        get => _newMatiereName;
        set => this.RaiseAndSetIfChanged(ref _newMatiereName, value);
    }

    public Matiere SelectedMatiere
    {
        get => _selectedMatiere;
        set => this.RaiseAndSetIfChanged(ref _selectedMatiere, value);
    }
    public MatiereViewModel()
    {
        _context = new SchoolContext();

        LoadMatieresCommand = ReactiveCommand.Create(LoadMatieres);
        AddMatiereCommand = ReactiveCommand.Create(AddMatiere);
        DeleteMatiereCommand = ReactiveCommand.Create(DeleteMatiere);
        LoadMatieresCommand.Execute().Subscribe();

    }

    private void LoadMatieres()
    {
        Matieres.Clear();
        foreach (var matiere in _context.Matieres)
        {
            Matieres.Add(matiere);
        }
    }


    private void AddMatiere()
    {
        if (!string.IsNullOrWhiteSpace(NewMatiereName))
        {
            var matiere = new Matiere { Name = NewMatiereName };
            _context.Matieres.Add(matiere);
            _context.SaveChanges();
            LoadMatieres();
            NewMatiereName = string.Empty;
        }
    }

    private void DeleteMatiere()
    {
        if (SelectedMatiere != null)
        {
            _context.Matieres.Remove(SelectedMatiere);
            _context.SaveChanges();
            LoadMatieres();
        }
    }
}
