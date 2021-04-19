using MoneyManager.Main.ViewModels;
using System.Windows.Controls;

namespace MoneyManager.Main.Views
{
    /// <summary>
    /// Логика взаимодействия для Statistics.xaml
    /// </summary>
    public partial class Statistics : UserControl
    {
        public Statistics()
        {
            InitializeComponent();
            DataContext = new StatisticsViewModel();
        }
    }
}
