using System.Windows.Controls;
using static ChatApp.DI;

namespace ChatApp
{
    /// <summary>
    /// Interaction logic for SettingsControl.xaml
    /// </summary>
    public partial class SettingsControl : UserControl
    {
        public SettingsControl()
        {
            InitializeComponent();

            // Set data context to settings view model
            DataContext = ViewModelSettings;
        }
    }
}
