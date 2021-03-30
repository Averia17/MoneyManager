using MoneyManager.Main.ViewModels;
using System.Windows.Controls;

namespace MoneyManager.Main.Views
{
    /// <summary>
    /// Логика взаимодействия для Balance.xaml
    /// </summary>
    public partial class Balance : UserControl
    {
        public Balance()
        {
            InitializeComponent();

            DataContext = new BalanceViewModel();
        }
    }
}
