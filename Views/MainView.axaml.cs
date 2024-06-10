using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using MaxiSchool.ViewModels;

namespace MaxiSchool.Views
{
    public partial class MainView : UserControl
    {
        public MainView()
        {
            InitializeComponent();
            DataContext = new MainViewModel();

        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}