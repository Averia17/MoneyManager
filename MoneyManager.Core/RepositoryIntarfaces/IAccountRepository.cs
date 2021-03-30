using MoneyManager.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManager.Core.RepositoryIntarfaces
{
    public interface IAccountRepository : IRepository<Account, Guid>
    {
    }
}
