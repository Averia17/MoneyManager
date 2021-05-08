using MoneyManager.Main.ViewModels;
using System.Data.Linq;
using System.Windows.Controls;

namespace MoneyManager.Main.Views
{
    /// <summary>
    /// Логика взаимодействия для Settings.xaml
    /// </summary>
    public partial class Settings : UserControl
    {
        public Settings()
        {
            InitializeComponent();
            DataContext = new SettingsViewModel();
        }
    }
}
