using ReactiveUI;

namespace MaxiSchool.ViewModels;


public class MainViewModel : BaseViewModel
{
    public ClasseViewModel ClasseViewModel { get; set; }
    public MatiereViewModel MatiereViewModel { get; set; }
    public EleveViewModel EleveViewModel { get; set; }
    public ProfesseurViewModel ProfesseurViewModel { get; set; }

    public MainViewModel()
    {
        ClasseViewModel = new ClasseViewModel();
        MatiereViewModel = new MatiereViewModel();
        EleveViewModel = new EleveViewModel();
        ProfesseurViewModel = new ProfesseurViewModel();
    }
}