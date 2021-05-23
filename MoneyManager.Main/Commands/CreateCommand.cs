using Itenso.TimePeriod;
using MoneyManager.Core.Exceptions;
using MoneyManager.Core.Models;
using MoneyManager.Infrastructure.Repositories;
using MoneyManager.Main.States.Accounts;
using MoneyManager.Main.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace MoneyManager.Main.Commands
{
    public class CreateCommand : ICommand
    {
        public History History { get; set; }
        private readonly CreateHistoryViewModel _createHistoryViewModel;
        public CreateCommand(History history, CreateHistoryViewModel createHistoryViewModel)
        {
            History = history;
            _createHistoryViewModel = createHistoryViewModel;
        }
        HistoryRepository historyRepository = new HistoryRepository();

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return _createHistoryViewModel.CanCreate;
        }

        public void Execute(object parameter)
        {

            _createHistoryViewModel.ErrorMessage = string.Empty;
            try
            {
                double Amount = double.Parse(_createHistoryViewModel.Amount.Replace('.',','));
                if (Amount <= 0)
                {
                    throw new AmountLessThanZeroException(History.Amount);
                }
                History.Id = Guid.NewGuid();
                
                History.AccountId = SingleCurrentAccount.GetInstance().Account.Id;
                History.Account = null;
                History.ActivityId = History.Activity.Id;
                History.Activity = null;
                History.Amount = Amount;
                historyRepository.Create(History);

                if (History.IsRepeat)
                {
                    History.IsRepeat = false;
                    History.Id = Guid.NewGuid();
                    historyRepository.Create(History);
                    CheckRepeatHistories();
                }
            }
            catch(FormatException)
            {
                _createHistoryViewModel.ErrorMessage = "Вы что-то ввели не так";

            }
            catch (AmountLessThanZeroException)
            {
                _createHistoryViewModel.ErrorMessage = "Нужно вводить положительную сумму";
            }
            catch (Exception)
            {
                _createHistoryViewModel.ErrorMessage = "Не получилось создать...";
            }
            
            
        }
        public static void CheckRepeatHistories()
        {
            List<History> RepeatHistoriesList = new List<History>();
            HistoryRepository historyRepository = new HistoryRepository();
            RepeatHistoriesList = historyRepository.List(x => x.Account.Id == SingleCurrentAccount.GetInstance().Account.Id && x.IsRepeat).ToList();
            DateTime datenow = new DateTime();
            datenow = DateTime.Now;
            //идея в том чтобы добавить в отдельный список все хистори с isrepeat и их не показывать в обычных хистори

            foreach (History history in RepeatHistoriesList)
            {
                DateTime historyDate = history.Date;
                DateDiff dateDiff = new DateDiff(history.Date, datenow);
                History copiedHistory = new History()
                {
                    Id = Guid.NewGuid(),
                    AccountId = history.AccountId,
                    ActivityId = history.ActivityId,
                    Date = history.Date,
                    Amount = history.Amount,
                    Description = history.Description,
                    IsRepeat = false
                };
                int i = 0;
                while (i < dateDiff.Months)
                {
                    i++;
                    copiedHistory.Id = Guid.NewGuid();
                    copiedHistory.Date = copiedHistory.Date.AddMonths(1);

                    historyRepository.Create(copiedHistory);

                }
                history.Date = history.Date.AddMonths(dateDiff.Months);
                historyRepository.Edit(history);
            }
        }
    }
}
