using System;
using MaxiSchool.Data;
using MaxiSchool.Models;
using System.Collections.ObjectModel;
using System.Reactive;
using ReactiveUI;

namespace MaxiSchool.ViewModels
{
    public class ClasseViewModel : BaseViewModel
    {
        private readonly SchoolContext _context;
        private string _newClassName;
        private Classe _selectedClasse;

        public ObservableCollection<Classe> Classes { get; } = new();

        public string NewClassName
        {
            get => _newClassName;
            set => this.RaiseAndSetIfChanged(ref _newClassName, value);
        }

        public Classe SelectedClasse
        {
            get => _selectedClasse;
            set => this.RaiseAndSetIfChanged(ref _selectedClasse, value);
        }

        public ReactiveCommand<Unit, Unit> LoadClassesCommand { get; }
        public ReactiveCommand<Unit, Unit> AddClasseCommand { get; }
        public ReactiveCommand<Unit, Unit> DeleteClasseCommand { get; }

        public ClasseViewModel()
        {
            _context = new SchoolContext();
            LoadClassesCommand = ReactiveCommand.Create(LoadClasses);
            AddClasseCommand = ReactiveCommand.Create(AddClasse);
            DeleteClasseCommand = ReactiveCommand.Create(DeleteClasse);

            LoadClassesCommand.Execute().Subscribe();
        }

        private void LoadClasses()
        {
            Classes.Clear();
            foreach (var classe in _context.Classes)
            {
                Classes.Add(classe);
            }
        }

        private void AddClasse()
        {
            if (!string.IsNullOrWhiteSpace(NewClassName))
            {
                var classe = new Classe { Name = NewClassName };
                _context.Classes.Add(classe);
                _context.SaveChanges();
                LoadClasses();
                NewClassName = string.Empty;
            }
        }

        private void DeleteClasse()
        {
            if (SelectedClasse != null)
            {
                _context.Classes.Remove(SelectedClasse);
                _context.SaveChanges();
                LoadClasses();
            }
        }
    }
}
