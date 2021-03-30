using MoneyManager.Main.ViewModels;
using System.Windows.Controls;

namespace MoneyManager.Main.Views
{
    /// <summary>
    /// Логика взаимодействия для FilterBalance.xaml
    /// </summary>
    public partial class FilterBalance : UserControl
    {
        public FilterBalance()
        {
            InitializeComponent();

            DataContext = new FilterBalanceViewModel();
        }
    }
}
