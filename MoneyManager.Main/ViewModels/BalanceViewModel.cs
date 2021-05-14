using MoneyManager.Core.Models;
using MoneyManager.Core.RepositoryIntarfaces;
using MoneyManager.Main;
using MoneyManager.Infrastructure.Repositories;
using MoneyManager.Main.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;
using MoneyManager.Main.States.Accounts;
using Itenso.TimePeriod;

namespace MoneyManager.Main.ViewModels
{
    public class BalanceViewModel : BaseViewModel
    {
        public ICommand DeleteCommand { get; set; }

        public Account _currentAccount { get; set; }

        public Account CurrentAccount
        {
            get { return _currentAccount; }
            set
            {
                _currentAccount = value;
               
                OnPropertyChanged(nameof(CurrentAccount));
             
            }
        }
        public static ICommand LinkToEditCommand { get; set; }
        
        public ICommand UpdateViewCommand { get; set; }

        private ICollectionView _historyCollectionView { get; set; }
        public ICollectionView HistoryCollectionView
        {
            get { return _historyCollectionView; }
            set
            {
                _historyCollectionView = value;
                OnPropertyChanged(nameof(HistoryCollectionView));
            }
        }
        private List<History> _histories { get; set; }
        public List<History> Histories
        {
            get { return _histories; }
            set
            {
                _histories = value;
                OnPropertyChanged(nameof(Histories));
                if(HistoryCollectionView != null)
                    RefreshHistoryCollectionView();
            }
        }

        public double _balance { get; set; }
        public double Balance
        {
            get { return _balance; }
            set
            {
                _balance = value;
                OnPropertyChanged(nameof(Balance));
            }
        }

        private HistoryRepository historyRepository;

        public BalanceViewModel()
        {
            SingleCurrentAccount currentAccount = SingleCurrentAccount.GetInstance();
            CurrentAccount = currentAccount.Account;
            historyRepository = new HistoryRepository();
            Histories = new List<History>();
            GetHistories();

            CheckRepeatHistories();

            Balance = GetBalance(Histories);
            UpdateViewCommand = new UpdateViewCommand(MainWindow.MainView);
            RefreshHistoryCollectionView();
            DeleteCommand = new DeleteCommand(this);
            LinkToEditCommand = new LinkToEditCommand();

        }
        public override void GetHistories()
        {
            Histories = historyRepository.List(x => x.Account.Id == CurrentAccount.Id && !x.IsRepeat).ToList();
            Balance = GetBalance(Histories);

        }
        public static double GetBalance(List<History> histories)
        {
            double SumOfHistories = SingleCurrentAccount.GetInstance().Account.Balance;
            foreach (History history in histories)
            {
                if (history.Activity.ActivityType.Title == "Доходы")
                    SumOfHistories += history.Amount;
                else if (history.Activity.ActivityType.Title == "Расходы")
                    SumOfHistories -= history.Amount;
            }

            return SumOfHistories;
        }
        public void RefreshHistoryCollectionView()
        {
            HistoryCollectionView = CollectionViewSource.GetDefaultView(Histories);
            HistoryCollectionView.GroupDescriptions.Add(new PropertyGroupDescription(nameof(History.Date), new DateTimeConverter()));

            HistoryCollectionView.Refresh();
        }

        public void CheckRepeatHistories()
        {
            List<History> RepeatHistoriesList = new List<History>();
            RepeatHistoriesList = historyRepository.List(x => x.Account.Id == CurrentAccount.Id && x.IsRepeat).ToList();
            DateTime datenow = new DateTime();
            datenow = DateTime.Now;
            //идея в том чтобы добавить в отдельный список все хистори с isrepeat и их не показывать в обычных хистори
            //            var RepeatHistoris = RepeatHistoriesList.GroupBy(x => x.Id).ToList();

            foreach (History history in RepeatHistoriesList)
            {
                DateTime historyDate = history.Date;
                DateDiff dateDiff = new DateDiff(history.Date, datenow);
                int i = 0;
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

                    //history.Date = historyDate;

                }
                history.Date = history.Date.AddMonths(dateDiff.Months);
                historyRepository.Edit(history);
            }
        }
    }
    public class DateTimeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
            {
                throw new NullReferenceException("value can not be null");
            }
            DateTime date = (DateTime)value;
            return date.ToString("dd/MM/yyyy");
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
}
