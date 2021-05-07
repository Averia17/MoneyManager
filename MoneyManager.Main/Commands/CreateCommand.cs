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
            if (History.Activity != null)
                return true;
            else
                return false;
        }

        public void Execute(object parameter)
        {
           
            History.Id = Guid.NewGuid();
            
            History.AccountId = SingleCurrentAccount.GetInstance().Account.Id;
            History.Account = null;
            History.ActivityId = History.Activity.Id;
            History.Activity = null;
            historyRepository.Create(History);
            //balanceViewModel.GetHistories();
        }
    }
}
