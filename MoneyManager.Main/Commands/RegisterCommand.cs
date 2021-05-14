using MoneyManager.Main.States.Authenticators;
using MoneyManager.Main.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using static MoneyManager.Core.RepositoryIntarfaces.AuthenticationRepository.AuthenticationRepository;

namespace MoneyManager.Main.Commands
{
    public class RegisterCommand : ICommand
    {
        private readonly RegisterViewModel _registerViewModel;
        private readonly IAuthenticator _authenticator;
        private readonly UpdateViewCommand _registerRenavigator;

        public RegisterCommand(RegisterViewModel registerViewModel, IAuthenticator authenticator)
        {
            _registerViewModel = registerViewModel;
            _authenticator = authenticator;
            _registerRenavigator = new UpdateViewCommand(MainWindow.MainView);

            _registerViewModel.PropertyChanged += RegisterViewModel_PropertyChanged;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return _registerViewModel.CanRegister;
        }

        public void Execute(object parameter)
        {
            _registerViewModel.ErrorMessage = string.Empty;

            try
            {
                RegistrationResult registrationResult =  _authenticator.Register(
                       _registerViewModel.Email,
                       _registerViewModel.Username,
                       _registerViewModel.Password,
                       _registerViewModel.ConfirmPassword,
                       _registerViewModel.Balance
                       );

                switch (registrationResult)
                {
                    case RegistrationResult.Success:
                        _registerRenavigator.Execute("Login");
                        break;
                    case RegistrationResult.PasswordDoNotMatch:
                        _registerViewModel.ErrorMessage = "Пароли не совпадают";
                        break;
                    case RegistrationResult.EmailAlreadyExist:
                        _registerViewModel.ErrorMessage = "Аккаунт с таким email уже существует";
                        break;
                    
                    default:
                        _registerViewModel.ErrorMessage = "Не получилось зарегистрироваться";
                        break;
                }
            }
            catch (Exception)
            {
                _registerViewModel.ErrorMessage = "Не получилось зарегистрироваться";
            }
        }


        private void RegisterViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(RegisterViewModel.CanRegister))
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
