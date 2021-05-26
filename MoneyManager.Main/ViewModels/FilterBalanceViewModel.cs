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
using System.Windows.Input;
using MoneyManager.Main.Commands;

namespace MoneyManager.Main.ViewModels
{
    public class FilterBalanceViewModel : BaseViewModel
    {
        public List<History> Histories { get; set; }
        public HistoryRepository historyRepository { get; set; }
        private ICollectionView _historiesCollectionView { get; set; }
        public ICollectionView HistoriesCollectionView
        {
            get { return _historiesCollectionView; }
            set
            {
                _historiesCollectionView = value;
                OnPropertyChanged(nameof(HistoriesCollectionView));
            }
        }
        private ActivityType _activityTypeExpence { get; set; }

        public ActivityType ActivityTypeExpence
        {
            get { return _activityTypeExpence; }
            set
            {
                _activityTypeExpence = value;
                OnPropertyChanged(nameof(ActivityTypeExpence));
            }
        }

        private ActivityType _activityTypeEncome { get; set; }

        public ActivityType ActivityTypeEncome
        {
            get { return _activityTypeEncome; }
            set
            {
                _activityTypeEncome = value;
                OnPropertyChanged(nameof(ActivityTypeEncome));
            }
        }

        private double _encome { get; set; }
        public double Encome
        {
            get { return _encome; }
            set
            {
                _encome = value;
                OnPropertyChanged(nameof(Encome));
            }
        }

        private double _expense { get; set; }
        public double Expense
        {
            get { return _expense; }
            set
            {
                _expense = value;
                OnPropertyChanged(nameof(Expense));
            }
        }

        private double _difference { get; set; }
        public double Difference
        {
            get { return _difference; }
            set
            {
                _difference = value;
                OnPropertyChanged(nameof(Difference));
            }
        }
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
                UpdateProperties();
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
        private List<History> _filteredHistories { get; set; }
        public List<History> FilteredHistories
        {
            get { return _filteredHistories; }
            set
            {
                _filteredHistories = value;
                OnPropertyChanged(nameof(FilteredHistories));
                UpdateProperties();
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

        public ICommand ChangeRadioButtonCommand { get; set; }
        public FilterBalanceViewModel()
        {
            historyRepository = new HistoryRepository();

            Histories = new List<History>();

            FilteredHistories = new List<History>();
            Histories = historyRepository.List(x => x.Account.Id == SingleCurrentAccount.GetInstance().Account.Id && !x.IsRepeat).ToList();
            HistoriesCollectionView = CollectionViewSource.GetDefaultView(Histories);

            HistoriesCollectionView.Filter = FilterHistories;
            HistoriesCollectionView.GroupDescriptions.Add(new PropertyGroupDescription(nameof(History.Date), new DateTimeConverter()));

            ActivityTypeExpence = new ActivityTypeRepository().List().ToList()[0];
            ActivityTypeEncome = new ActivityTypeRepository().List().ToList()[1];

            ChangeRadioButtonCommand = new ChangeRadioButtonCommand(this);
            
            UpdateProperties();

        }
        public void RefreshHistoryCollectionView()
        {
            HistoriesCollectionView = CollectionViewSource.GetDefaultView(Histories);
            HistoriesCollectionView.GroupDescriptions.Add(new PropertyGroupDescription(nameof(History.Date), new DateTimeConverter()));

            HistoriesCollectionView.Refresh();

        }
        private bool FilterHistories(object obj)
        {

            if (obj is History history)
            {
                if (history.Activity.Title.ToUpper().Contains(HistoriesFilter.ToUpper()) && history.Date >= TbFrom && history.Date <= TbTo)
                {
                    FilteredHistories.Add(history);
                    return true;
                }
                else
                    return false;
            
            }

            return false;
        }

        private void UpdateProperties()
        {
            FilteredHistories.Clear();

            if (HistoriesCollectionView != null)
            {
                foreach (var o in HistoriesCollectionView)
                {
                    FilteredHistories.Add((History)o);
                }
            }
            Encome = GetHistoriesByType("Доходы");
            Expense = GetHistoriesByType("Расходы");
            Difference = GetDifference();
        }

        private double GetHistoriesByType(string Type)
        {
            double sum = 0;

            List<History> histories = new List<History>();
            histories = FilteredHistories.Where(x => x.Activity.ActivityType.Title == Type).ToList();

            foreach (History history in histories)
            {
                sum += history.Amount;
            }
            return sum;
        }

        private double GetDifference()
        {
            return GetHistoriesByType("Доходы") - GetHistoriesByType("Расходы");
        }
    }
}
