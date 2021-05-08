using Itenso.TimePeriod;
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
            if (History.IsRepeat)
            {
                History.IsRepeat = false;
                historyRepository.Create(History);
                CheckRepeatHistories();
            }
            //balanceViewModel.GetHistories();
        }
        public void CheckRepeatHistories()
        {
            List<History> RepeatHistoriesList = new List<History>();
            RepeatHistoriesList = historyRepository.List(x => x.Account.Id == SingleCurrentAccount.GetInstance().Account.Id && x.IsRepeat).ToList();
            DateTime datenow = new DateTime();
            datenow = DateTime.Now;
            //идея в том чтобы добавить в отдельный список все хистори с isrepeat и их не показывать в обычных хистори
            //            var RepeatHistoris = RepeatHistoriesList.GroupBy(x => x.Id).ToList();

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
                    /*  bool flag = false;

                      foreach (History ContainingHistory in Histories)
                      {
                          if (copiedHistory.Date == ContainingHistory.Date && copiedHistory.ActivityId == ContainingHistory.ActivityId)
                              flag = true;
                      }

                      if (flag)
                          continue;*/
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
