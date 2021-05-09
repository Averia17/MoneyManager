using MoneyManager.Core.Models;
using MoneyManager.Infrastructure.Repositories;
using MoneyManager.Main.States.Accounts;
using PieChart;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManager.Main.ViewModels
{
    public class StatisticsViewModel : BaseViewModel
    {
        public ObservableCollection<PieCharItem> PieCharListExpenses { get; set; }
        public ObservableCollection<PieCharItem> PieCharListEncomes { get; set; }
        public HistoryRepository historyRepository { get; set; }

        Account account { get; set; }

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
        private DateTime _tbFrom = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
        public DateTime TbFrom
        {
            get { return _tbFrom; }
            set
            {
                _tbFrom = value;
                OnPropertyChanged(nameof(PieCharListExpenses));
                StartUp();
            }
        }

        private DateTime _tbTo = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month));
        public DateTime TbTo
        {
            get { return _tbTo; }
            set
            {

                _tbTo = value;
                OnPropertyChanged(nameof(PieCharListExpenses));

                StartUp();
            }
        }
        public StatisticsViewModel()
        {
            PieCharListExpenses = new ObservableCollection<PieCharItem>();
            PieCharListEncomes = new ObservableCollection<PieCharItem>();
            historyRepository = new HistoryRepository();
            SingleCurrentAccount currentAccount = SingleCurrentAccount.GetInstance();
            account = currentAccount.Account;
            StartUp();
        }
        public void StartUp()
        {
            GetPieCharExpensesList();
            //GetPieCharEncomesList();
            Encome = GetHistoriesByType("Доходы");
            Expense = GetHistoriesByType("Расходы");
            Difference = GetDifference();
        }
        public double GetHistoriesByType(string Type)
        {
            double sum = 0;

            List<History> histories = new List<History>();
            histories = historyRepository.List(x => x.Activity.ActivityType.Title == Type && !x.IsRepeat
                                                && x.Date >= TbFrom && x.Date <= TbTo && x.Account.Id == account.Id)
                                                .ToList();

            foreach (History history in histories)
            {
                sum += history.Amount;
            }
            return sum;
        }
       
        public double GetDifference()
        {
            return GetHistoriesByType("Доходы") - GetHistoriesByType("Расходы");
        }
        public void GetPieCharExpensesList()
        {
            PieCharListExpenses.Clear();

            var histories = historyRepository.List(x => x.Activity.ActivityType.Title == "Расходы" && x.Date >= TbFrom && x.Date <= TbTo && x.Account.Id == account.Id && !x.IsRepeat)
                                                .GroupBy(x => x.Activity.Title).
                                                Select(g => new
                                                {
                                                    g.Key,
                                                    Sum = g.Sum(s => s.Amount),
                                                }).ToList();
            foreach (var item in histories)
            {
                PieCharListExpenses.Add(new PieCharItem() { TypeName = item.Key, TypeNumber = (int)item.Sum });
            }
        }
        /*public void GetPieCharEncomesList()
        {
            PieCharListEncomes.Clear();

            var histories = historyRepository.List(x => x.Activity.ActivityType.Title == "Доходы" && x.Date >= TbFrom && x.Date <= TbTo && x.Account.Id == account.Id && !x.IsRepeat)
                                                    .GroupBy(x => x.Activity.Title).
                                                    Select(g => new
                                                    {
                                                        g.Key,
                                                        Sum = g.Sum(s => s.Amount),
                                                    }).ToList();
            foreach (var item in histories)
            {
                PieCharListExpenses.Add(new PieCharItem() { TypeName = item.Key, TypeNumber = (int)item.Sum });
            }
        }*/
    }
}
