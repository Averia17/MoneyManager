using MoneyManager.Core.Models;
using MoneyManager.Main.ViewModels;
using System;
using System.Windows.Input;

namespace MoneyManager.Main.Commands
{
    public class LinkToEditCommand : BaseViewModel, ICommand
    {
        public static History History { get; set; }


        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            ICommand UpdateViewCommand = new UpdateViewCommand(MainWindow.MainView);
            UpdateViewCommand.Execute("EditHistory");

            History = (History)parameter;
        }
    }
}
