using MoneyManager.Core.Models;
using MoneyManager.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using MoneyManager.Main.States.Accounts;

namespace MoneyManager.Main.ViewModels
{
    public class FilterBalanceViewModel : BaseViewModel
    {
        public List<History> Histories { get; set; }
        public HistoryRepository historyRepository { get; set; }
        public ICollectionView HistoriesCollectionView { get; set; }
        private string _historiesFilter = string.Empty;
        public string HistoriesFilter
        {
            get
            {
                return _historiesFilter;
            }
            set
            {
                _historiesFilter = value;
                OnPropertyChanged(nameof(HistoriesFilter));
                HistoriesCollectionView.Refresh();
            }
        }

        private DateTime _tbFrom = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
        public DateTime TbFrom
        {
            get { return _tbFrom; }
            set
            {
                _tbFrom = value;
                OnPropertyChanged(nameof(HistoriesFilter));
                HistoriesCollectionView.Refresh();
            }
        }

        private DateTime _tbTo = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month));
        public DateTime TbTo
        {
            get { return _tbTo; }
            set {
                _tbTo = value;
                OnPropertyChanged(nameof(HistoriesFilter));
                HistoriesCollectionView.Refresh();
            }
        }
        public FilterBalanceViewModel()
        {
            historyRepository = new HistoryRepository();

            Histories = new List<History>();
            SingleCurrentAccount currentAccount = SingleCurrentAccount.GetInstance();
            Account account = currentAccount.Account;

            Histories = (List<History>)historyRepository.List(x => x.Account.Id == account.Id);
            HistoriesCollectionView = CollectionViewSource.GetDefaultView(Histories);

            HistoriesCollectionView.Filter = FilterHistories;
            HistoriesCollectionView.GroupDescriptions.Add(new PropertyGroupDescription(nameof(History.Date), new DateTimeConverter()));

        }
        private bool FilterHistories(object obj)
        {
            if (obj is History history)
            {
                if(TbFrom != null && TbTo != null)
                    return history.Activity.Title.ToUpper().Contains(HistoriesFilter.ToUpper()) && history.Date >= TbFrom && history.Date <= TbTo;
                else
                    return history.Activity.Title.ToUpper().Contains(HistoriesFilter.ToUpper()) ;
            }
           
            return false;
        }
        
    }
}
