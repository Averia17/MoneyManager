using MoneyManager.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MoneyManager.Core.RepositoryIntarfaces.AuthenticationRepository.AuthenticationRepository;

namespace MoneyManager.Main.States.Authenticators
{
    public interface IAuthenticator
    {
        Account CurrentAccount { get; }
        bool IsLoggedIn { get; }

        event Action StateChanged;
        RegistrationResult Register(string email, string username, string password, string confirmPassword, double balance);
        bool Login(string username, string password);
        void Logout();
    }
}
