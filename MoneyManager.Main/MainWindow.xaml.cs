using MoneyManager.Main.ViewModels;
using System.ComponentModel;
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
        /*public MainViewModel MainView 
        {
            get { return _mainView; }
            set
            {
                _mainView = value;
                OnPropertyChanged(nameof(MainView));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }*/
        

        public MainWindow()
        {
            InitializeComponent();
            MainView = new MainViewModel();
            MainView.SelectedViewModel = new BalanceViewModel();
            DataContext = MainView;
        }

    }
}
