using MoneyManager.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManager.Main.States.Accounts
{
    public class AccountStore : IAccountStore
    {
        
        private Account currentAccount;
        public Account CurrentAccount
        {
            get
            {
                return currentAccount;
            }
            set
            {
                currentAccount = value;
                StateChanged?.Invoke();
            }
        }
        public event Action StateChanged;
    }
}
