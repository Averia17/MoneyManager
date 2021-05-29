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
using MoneyManager.Core.RepositoryIntarfaces;

namespace MoneyManager.Main.ViewModels
{
    public class FilterBalanceViewModel : BaseViewModel
    {
        public List<History> Histories { get; set; }
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
                UpdateProperties();
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
                UpdateProperties();

                HistoriesCollectionView.Refresh();
            }
        }
        private List<Activity> _activities;

        public List<Activity> activities
        {
            get { return _activities; }
            set
            {
                _activities = value;
                OnPropertyChanged(nameof(activities));
            }
        }
        public IUnitOfWork unitOfWork { get; set; }
        public ICommand ChangeRadioButtonCommand { get; set; }
        public FilterBalanceViewModel()
        {
            unitOfWork = new UnitOfWork();

            Histories = new List<History>();
            activities = new List<Activity>();
            Histories = unitOfWork.HistoryRepository.List(x => x.Account.Id == SingleCurrentAccount.GetInstance().Account.Id && !x.IsRepeat).ToList();
            HistoriesCollectionView = CollectionViewSource.GetDefaultView(Histories);

            HistoriesCollectionView.Filter = FilterHistories;
            HistoriesCollectionView.GroupDescriptions.Add(new PropertyGroupDescription(nameof(History.Date), new DateTimeConverter()));

            ActivityTypeExpence = unitOfWork.ActivityTypeRepository.List().ToList()[0];
            ActivityTypeEncome = unitOfWork.ActivityTypeRepository.List().ToList()[1];

            ChangeRadioButtonCommand = new ChangeRadioButtonCommand(this);
            
            UpdateProperties();

        }
        public void RefreshHistoryCollectionView()
        {
            HistoriesCollectionView = CollectionViewSource.GetDefaultView(Histories);
            HistoriesCollectionView.GroupDescriptions.Add(new PropertyGroupDescription(nameof(History.Date), new DateTimeConverter()));
            HistoriesCollectionView.Filter = FilterHistories;

            HistoriesCollectionView.Refresh();


        }
        private bool FilterHistories(object obj)
        {

            if (obj is History history)
            {
                return history.Activity.Title.ToUpper().Contains(HistoriesFilter.ToUpper()) && history.Date >= TbFrom && history.Date <= TbTo;
            
            }

            return false;
        }

        public void UpdateProperties()
        {
            List<History> histories = new List<History>();
            foreach (History history in HistoriesCollectionView)
            {
                histories.Add(history);
            }
            Encome = histories.Where(x => x.Activity.ActivityType.Title == "Доходы" && x.Date >= TbFrom &&x.Date <=TbTo).Sum(x => x.Amount);
            Expense = histories.Where(x => x.Activity.ActivityType.Title == "Расходы" && x.Date >= TbFrom && x.Date <= TbTo).Sum(x => x.Amount);
            Difference = Encome - Expense;
        }

    }
}
