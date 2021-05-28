using MoneyManager.Core.Exceptions;
using MoneyManager.Core.Models;
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
    public class EditCommand : ICommand
    {
        public History History { get; set; }
        private readonly EditHistoryViewModel _editHistoryViewModel;

        public EditCommand(History history, EditHistoryViewModel editHistoryViewModel)
        {
            History = history;
            _editHistoryViewModel = editHistoryViewModel;

        }
        HistoryRepository historyRepository = new HistoryRepository();

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return _editHistoryViewModel.CanCreate;

        }

        public void Execute(object parameter)
        {
            _editHistoryViewModel.ErrorMessage = string.Empty;
            try
            {
                double Amount = double.Parse(_editHistoryViewModel.Amount.Replace('.', ','));
                if (Amount <= 0)
                {
                    throw new AmountLessThanZeroException(History.Amount);
                }
                History.AccountId = History.Account.Id;
                History.ActivityId = History.Activity.Id;
                History.Amount = Amount;


                historyRepository.Edit(History);
                new UpdateViewCommand(MainWindow.MainView).Execute("Balance");

            }
            catch (FormatException)
            {
                _editHistoryViewModel.ErrorMessage = "Вы что-то ввели не так";

            }
            catch (AmountLessThanZeroException)
            {
                _editHistoryViewModel.ErrorMessage = "Нужно вводить положительную сумму";
            }
            catch (Exception)
            {
                _editHistoryViewModel.ErrorMessage = "Не получилось создать...";
            }

        }
    }
}
