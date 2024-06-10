using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using MaxiSchool.ViewModels;

namespace MaxiSchool.Views
{
    public partial class ClasseView : UserControl
    {
        public ClasseView()
        {
            InitializeComponent();
            DataContext = new ClasseViewModel();

        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}