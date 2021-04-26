using MoneyManager.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManager.Main.States.Accounts
{
    public interface IAccountStore
    {
        Account CurrentAccount { get; set; }
        
        event Action StateChanged;
    }
}
