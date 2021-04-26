﻿using MoneyManager.Core.Models;
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

namespace MoneyManager.Main.ViewModels
{
    public class BalanceViewModel : BaseViewModel
    {
        public ICommand DeleteCommand { get; set; }

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
           
            historyRepository = new HistoryRepository();
            Histories = new List<History>();
            GetHistories();
            Balance = GetBalance();
            UpdateViewCommand = new UpdateViewCommand(MainWindow.MainView);
            RefreshHistoryCollectionView();
            DeleteCommand = new DeleteCommand(this);
            LinkToEditCommand = new LinkToEditCommand(this);

        }
        public void GetHistories()
        {
            SingleCurrentAccount currentAccount = SingleCurrentAccount.GetInstance();
            Account account = currentAccount.Account;

            Histories = (List<History>)historyRepository.List(x => x.Account.Id == account.Id);
            Balance = GetBalance();

        }
        public double GetBalance()
        {
            double SumOfHistories = 0;
            foreach (History history in Histories)
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
            return date.ToString("MM/dd/yyyy");
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
}
