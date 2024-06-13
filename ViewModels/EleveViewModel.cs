using System;
using MaxiSchool.Data;
using MaxiSchool.Models;
using System.Collections.ObjectModel;
using System.Reactive;
using Microsoft.EntityFrameworkCore;
using ReactiveUI;

namespace MaxiSchool.ViewModels;


public class EleveViewModel : BaseViewModel
{
    private readonly SchoolContext _context;
    private string _newEleveFirstName;
    private string _newEleveLastName;
    private Classe _selectedClasse;
    private Eleve _selectedEleve;

    public ObservableCollection<Eleve> Eleves { get; } = new();
    public ObservableCollection<Classe> Classes { get; } = new();

    public string NewEleveFirstName
    {
        get => _newEleveFirstName;
        set => this.RaiseAndSetIfChanged(ref _newEleveFirstName, value);
    }

    public string NewEleveLastName
    {
        get => _newEleveLastName;
        set => this.RaiseAndSetIfChanged(ref _newEleveLastName, value);
    }

    public Classe SelectedClasse
    {
        get => _selectedClasse;
        set => this.RaiseAndSetIfChanged(ref _selectedClasse, value);
    }

    public Eleve SelectedEleve
    {
        get => _selectedEleve;
        set => this.RaiseAndSetIfChanged(ref _selectedEleve, value);
    }

    public ReactiveCommand<Unit, Unit> LoadElevesCommand { get; }
    public ReactiveCommand<Unit, Unit> LoadClassesCommand { get; }
    public ReactiveCommand<Unit, Unit> AddEleveCommand { get; }
    public ReactiveCommand<Unit, Unit> DeleteEleveCommand { get; }

    public EleveViewModel()
    {
        _context = new SchoolContext();
        LoadElevesCommand = ReactiveCommand.Create(LoadEleves);
        LoadClassesCommand = ReactiveCommand.Create(LoadClasses);
        AddEleveCommand = ReactiveCommand.Create(AddEleve);
        DeleteEleveCommand = ReactiveCommand.Create(DeleteEleve);

        LoadElevesCommand.Execute().Subscribe();
        LoadClassesCommand.Execute().Subscribe();
    }

    private void LoadEleves()
    {
        Eleves.Clear();
        foreach (var eleve in _context.Eleves.Include(e => e.Classe))
        {
            Eleves.Add(eleve);
        }
    }

    private void LoadClasses()
    {
        Classes.Clear();
        foreach (var classe in _context.Classes)
        {
            Classes.Add(classe);
        }
    }

    private void AddEleve()
    {
        if (!string.IsNullOrWhiteSpace(NewEleveFirstName) && !string.IsNullOrWhiteSpace(NewEleveLastName) && SelectedClasse != null)
        {
            var eleve = new Eleve { FirstName = NewEleveFirstName, LastName = NewEleveLastName, ClasseId = SelectedClasse.Id };
            _context.Eleves.Add(eleve);
            _context.SaveChanges();
            LoadEleves();
            NewEleveFirstName = string.Empty;
            NewEleveLastName = string.Empty;
        }
    }

    private void DeleteEleve()
    {
        if (SelectedEleve != null)
        {
            _context.Eleves.Remove(SelectedEleve);
            _context.SaveChanges();
            LoadEleves();
        }
    }
}