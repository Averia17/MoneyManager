using MoneyManager.Core.Models;
using MoneyManager.Main.ViewModels;
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
                SingleCurrentAccount singleCurrentAccount = SingleCurrentAccount.GetInstance();
                singleCurrentAccount.Account = currentAccount;
                MainWindow.MainView.CheckLoggin();
                StateChanged?.Invoke();
            }
        }
        public event Action StateChanged;
    }

    public sealed class SingleCurrentAccount
    {
        public Account Account { get; set; }
        private static SingleCurrentAccount _instance;
        private SingleCurrentAccount()
        {
            Account = new Account();
        }

        public static SingleCurrentAccount GetInstance()
        {
            return _instance ?? (_instance = new SingleCurrentAccount());
        }
    }
}
