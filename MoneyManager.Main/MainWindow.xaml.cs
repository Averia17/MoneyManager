using MoneyManager.Main.Commands;
using MoneyManager.Main.ViewModels;
using System.Windows;
using System.Windows.Input;

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
            ICommand UpdateViewCommand = new UpdateViewCommand(MainView);
            DataContext = MainView;
            UpdateViewCommand.Execute("Login");

        }
        public void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


    }
}
