using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace MaxiSchool.Views
{
    public partial class EleveView : UserControl
    {
        public EleveView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}