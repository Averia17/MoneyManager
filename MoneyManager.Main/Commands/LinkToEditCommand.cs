using MoneyManager.Core.Models;
using MoneyManager.Main.ViewModels;
using System;
using System.Windows.Input;

namespace MoneyManager.Main.Commands
{
    public class LinkToEditCommand : BaseViewModel, ICommand
    {
        BalanceViewModel balanceViewModel { get; set; }
        public static History History { get; set; }

        public LinkToEditCommand(BalanceViewModel balanceViewModel)
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
            balanceViewModel.UpdateViewCommand.Execute("EditHistory");

            History = (History)parameter;
        }
    }
}
