using System;
using MaxiSchool.Data;
using MaxiSchool.Models;
using System.Collections.ObjectModel;
using System.Reactive;
using ReactiveUI;

namespace MaxiSchool.ViewModels;


public class EleveViewModel : BaseViewModel
{
    private readonly SchoolContext _context;
    public ObservableCollection<Eleve> Eleves { get; } = new();
    public Eleve? _selectedEleve;
    public string? _newEleveFirstName;
    public string? _newEleveLastName;
    public ReactiveCommand<Unit, Unit> LoadElevesCommand { get; }
    public ReactiveCommand<Unit, Unit> AddEleveCommand { get; }
    public ReactiveCommand<Unit, Unit> DeleteEleveCommand { get; }

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

    public Eleve SelectedEleve
    {
        get => _selectedEleve;
        set => this.RaiseAndSetIfChanged(ref _selectedEleve, value);
    }

    public EleveViewModel()
    {
        _context = new SchoolContext();
        LoadElevesCommand = ReactiveCommand.Create(LoadEleves);
        AddEleveCommand = ReactiveCommand.Create(AddEleve);
        DeleteEleveCommand = ReactiveCommand.Create(DeleteEleve);
        LoadElevesCommand.Execute().Subscribe();

    }


    private void LoadEleves()
    {
        Eleves.Clear();
        foreach (var eleve in _context.Eleves)
        {
            Eleves.Add(eleve);
        }
    }


    private void AddEleve()
    {
        if (!string.IsNullOrWhiteSpace(NewEleveFirstName) && !string.IsNullOrWhiteSpace(NewEleveLastName))
        {
            var eleve = new Eleve { FirstName = NewEleveFirstName, LastName = NewEleveLastName };
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
