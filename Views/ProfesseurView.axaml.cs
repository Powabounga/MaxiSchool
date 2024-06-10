using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using MaxiSchool.ViewModels;

namespace MaxiSchool.Views
{
    public partial class ProfesseurView : UserControl
    {
        public ProfesseurView()
        {
            InitializeComponent();
            DataContext = new ProfesseurViewModel();

        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}