using MoneyManager.Main.ViewModels;
using System.Windows.Controls;

namespace MoneyManager.Main.Views
{
    /// <summary>
    /// Логика взаимодействия для CreateHistoryForm.xaml
    /// </summary>
    public partial class CreateHistoryForm : UserControl
    {
        public CreateHistoryForm()
        {
            InitializeComponent();

            DataContext = new CreateHistoryViewModel();
        }
    }
}
