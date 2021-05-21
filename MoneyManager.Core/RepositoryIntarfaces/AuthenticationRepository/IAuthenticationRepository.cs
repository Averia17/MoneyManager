using MoneyManager.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManager.Core.RepositoryIntarfaces.AuthenticationRepository
{
    public interface IAuthenticationRepository
    {
        Account Login(string username, string password);
    }
}
