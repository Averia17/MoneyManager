using MoneyManager.Main.ViewModels;
using System.Windows;

namespace MoneyManager.Main
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //стоить убрать этот щит
        public static MainViewModel MainView { get; set; }  

        public MainWindow()
        {
            InitializeComponent();
            MainView = new MainViewModel();
            MainView.SelectedViewModel = new BalanceViewModel();
            DataContext = MainView;
        }

    }
}
