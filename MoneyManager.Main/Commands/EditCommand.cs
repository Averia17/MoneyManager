using MoneyManager.Core.Models;
using MoneyManager.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MoneyManager.Main.Commands
{
    public class EditCommand : ICommand
    {
        public History History { get; set; }
        public EditCommand(History history)
        {
            History = history;
        }
        HistoryRepository historyRepository = new HistoryRepository();

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            if (History.Activity != null)
                return true;
            else
                return false;
        }

        public void Execute(object parameter)
        {
            History.AccountId = History.Account.Id;
            History.ActivityId = History.Activity.Id;

            historyRepository.Edit(History);
            
        }
    }
}
