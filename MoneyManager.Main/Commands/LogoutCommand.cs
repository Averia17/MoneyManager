using MoneyManager.Core.Models;
using MoneyManager.Infrastructure.Repositories;
using MoneyManager.Main.States.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MoneyManager.Main.Commands
{
    public class LogoutCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            SingleCurrentAccount currentAccount = SingleCurrentAccount.GetInstance();
            currentAccount.Account = new Account();
            MainWindow.MainView.IsLoggin = false;
            new UpdateViewCommand(MainWindow.MainView).Execute("Login");
        }
    }
}
