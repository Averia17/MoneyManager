using MoneyManager.Core.Models;
using MoneyManager.Infrastructure.Repositories;
using MoneyManager.Main.States.Accounts;
using MoneyManager.Main.ViewModels;
using System;
using System.Windows.Input;

namespace MoneyManager.Main.Commands
{
    public class CreateCommand : ICommand
    {
        //BalanceViewModel balanceViewModel { get; set; }
        public History History { get; set; }
        public CreateCommand(History history)
        {
            History = history;
        }
        HistoryRepository historyRepository = new HistoryRepository();

        public event EventHandler CanExecuteChanged;

       /* public CreateCommand(BalanceViewModel balanceViewModel)
        {
            this.balanceViewModel = balanceViewModel;
        }*/
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            //History history = (History)parameter;
            /* History = new History()
             {
                 Id = Guid.NewGuid(),
                 Date = 

ц
             };*/
            SingleCurrentAccount currentAccount = SingleCurrentAccount.GetInstance();
            Account account = currentAccount.Account;
            History.Id = Guid.NewGuid();
            History.AccountId = account.Id;
            History.ActivityId = History.Activity.Id;
            History.Activity = null;
            historyRepository.Create(History);
            //balanceViewModel.GetHistories();
        }
    }
}
