using MoneyManager.Core.Models;
using MoneyManager.Core.RepositoryIntarfaces;
using MoneyManager.Infrastructure.Repositories;
using MoneyManager.Main.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MoneyManager.Main.Commands
{
    public class DeleteCommand : ICommand
    {
        BaseViewModel balanceViewModel { get; set; }

        IUnitOfWork unitOfWork = new UnitOfWork();
        public DeleteCommand(BaseViewModel balanceViewModel)
        {
            this.balanceViewModel = balanceViewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            History history = (History)parameter;
            unitOfWork.HistoryRepository.Delete(history.Id);
            balanceViewModel.GetHistories();

            
        }
    }
}
