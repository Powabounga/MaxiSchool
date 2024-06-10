using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace MaxiSchool.Views
{
    public partial class MatiereView : UserControl
    {
        public MatiereView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
