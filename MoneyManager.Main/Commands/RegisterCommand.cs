using MoneyManager.Core.Exceptions;
using MoneyManager.Main.States.Authenticators;
using MoneyManager.Main.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
                double Balance = double.Parse(_registerViewModel.Balance.Replace('.', ','));
                if (!Regex.IsMatch(_registerViewModel.Username, @"[A-Za-z]\w{3,15}"))
                {
                    throw new RegexException();
                }
                if (!Regex.IsMatch(_registerViewModel.Password, @"\w+"))
                {
                    throw new RegexException();
                }
                RegistrationResult registrationResult =  _authenticator.Register(
                       _registerViewModel.Username,
                       _registerViewModel.Password,
                       _registerViewModel.ConfirmPassword,
                       Balance
                       );

                switch (registrationResult)
                {
                    case RegistrationResult.Success:
                        _registerRenavigator.Execute("Login");
                        break;
                    case RegistrationResult.PasswordDoNotMatch:
                        _registerViewModel.ErrorMessage = "Пароли не совпадают";
                        break;
                    case RegistrationResult.UsernameAlreadyExist:
                        _registerViewModel.ErrorMessage = "Аккаунт с таким именем уже существует";
                        break;
                    
                    default:
                        _registerViewModel.ErrorMessage = "Не получилось зарегистрироваться";
                        break;
                }
            }
            catch(RegexException)
            {
                _registerViewModel.ErrorMessage = "Неверный ввод";
            }
            catch(FormatException)
            {
                _registerViewModel.ErrorMessage = "Не получилось конвертировать";
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
