using MoneyManager.Main.Commands;
using MoneyManager.Main.States.Authenticators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MoneyManager.Main.ViewModels
{
    public class RegisterViewModel : BaseViewModel
    {
        

        private string _username;
        public string Username
        {
            get
            {
                return _username;
            }
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
                OnPropertyChanged(nameof(CanRegister));
            }
        }

        private string _password;
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
                OnPropertyChanged(nameof(CanRegister));
            }
        }

        private string _confirmPassword;
        public string ConfirmPassword
        {
            get
            {
                return _confirmPassword;
            }
            set
            {
                _confirmPassword = value;
                OnPropertyChanged(nameof(ConfirmPassword));
                OnPropertyChanged(nameof(CanRegister));
            }
        }

        private string _balance;
        public string Balance
        {
            get
            {
                return _balance;
            }
            set
            {
                _balance = value;
                OnPropertyChanged(nameof(Balance));
                OnPropertyChanged(nameof(CanRegister));
            }
        }

        // TODO СДЕЛАТЬ ПРОВЕРКУ НА БАЛАНС
        public bool CanRegister => 
            !string.IsNullOrEmpty(Username) &&
            !string.IsNullOrEmpty(Password) &&
            !string.IsNullOrEmpty(Balance) &&
            !string.IsNullOrEmpty(ConfirmPassword);

        public ICommand RegisterCommand { get; }

        public ICommand ViewLoginCommand { get; }

        public ICommand UpdateViewCommand { get; set; }
        public MessageViewModel ErrorMessageViewModel { get; }

        public string ErrorMessage
        {
            set => ErrorMessageViewModel.Message = value;
        }

        public RegisterViewModel(IAuthenticator authenticator)
        {
            ErrorMessageViewModel = new MessageViewModel();

            RegisterCommand = new RegisterCommand(this, authenticator);
            UpdateViewCommand = new UpdateViewCommand(MainWindow.MainView);

        }
    }
}
