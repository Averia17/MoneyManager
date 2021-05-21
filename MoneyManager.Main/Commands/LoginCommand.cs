using MoneyManager.Core.Exceptions;
using MoneyManager.Main.States.Authenticators;
using MoneyManager.Main.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MoneyManager.Main.Commands
{
    public class LoginCommand : ICommand
    {
        private readonly LoginViewModel _loginViewModel;
        private readonly IAuthenticator _authenticator;
        private UpdateViewCommand updateViewCommand { get; set; }

        public event EventHandler CanExecuteChanged;

        public LoginCommand(LoginViewModel loginViewModel, IAuthenticator authenticator)
        {
            _loginViewModel = loginViewModel;
            _authenticator = authenticator;
            updateViewCommand = new UpdateViewCommand(MainWindow.MainView);

            _loginViewModel.PropertyChanged += LoginViewModel_PropertyChanged;
        }

        public bool CanExecute(object parameter)
        {
            return _loginViewModel.CanLogin;
        }

        public void Execute(object parameter)
        {

            //КУДА????
            _loginViewModel.ErrorMessage = string.Empty;
            try
            {
                _authenticator.Login(_loginViewModel.Username, _loginViewModel.Password);
                updateViewCommand.Execute("Balance");
            }
            catch (AccountNotFoundException)
            {
                _loginViewModel.ErrorMessage = "Пользователя с таким именем не существует";
            }
            catch (InvalidPasswordException)
            {
                _loginViewModel.ErrorMessage = "Неверный пароль";
            }
            catch (Exception)
            {
                _loginViewModel.ErrorMessage = "Не получилось авторизоваться";
            }


        }

        private void LoginViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(LoginViewModel.CanLogin))
            {
                OnCanExecuteChanged();
            }
        }
        protected void OnCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, new EventArgs());
        }
    }
}
