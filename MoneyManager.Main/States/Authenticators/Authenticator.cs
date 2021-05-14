using MoneyManager.Core.Models;
using MoneyManager.Core.RepositoryIntarfaces.AuthenticationRepository;
using MoneyManager.Main.States.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MoneyManager.Core.RepositoryIntarfaces.AuthenticationRepository.AuthenticationRepository;

namespace MoneyManager.Main.States.Authenticators
{
    public class Authenticator : IAuthenticator
    {
        private readonly AuthenticationRepository _authenticationRepository;
        private readonly IAccountStore _accountStore;

        public Authenticator(AuthenticationRepository authenticationRepository, IAccountStore accountStore)
        {
            _authenticationRepository = authenticationRepository;
            _accountStore = accountStore;
        }

        public Account CurrentAccount
        {
            get
            {
                return _accountStore.CurrentAccount;
            }
            private set
            {
                _accountStore.CurrentAccount = value;
                StateChanged?.Invoke();
            }
        }
        public bool IsLoggedIn => CurrentAccount != null;
        public event Action StateChanged;

        public void Login(string email, string password)
        {
            CurrentAccount = _authenticationRepository.Login(email, password);
        }

        public void Logout()
        {
            CurrentAccount = null;
        }

        public RegistrationResult Register(string email, string username, string password, string confirmPassword, double balance)
        {
            return _authenticationRepository.Register(email, username, password, confirmPassword, balance);
        }
    }
}
