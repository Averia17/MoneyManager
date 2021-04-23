using MoneyManager.Core.Models;
using MoneyManager.Infrastructure.Repositories;
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
            History.Id = Guid.NewGuid();
            History.AccountId = Guid.Parse("B9AEC1FD-4B04-43D1-AE07-33E0ACBE4AB9");
            History.ActivityId = History.Activity.Id;
            History.Activity = null;
            historyRepository.Create(History);
            //balanceViewModel.GetHistories();
        }
    }
}
