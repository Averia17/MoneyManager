using System;
using System.Collections.ObjectModel;
using System.Windows.Media;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.EventCalendar;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Windows.Controls;
using MoneyManager.Core.Models;
using MoneyManager.Infrastructure.Repositories;
using MoneyManager.Main.States.Accounts;

namespace MoneyManager.Main.ViewModels
{
    public class ScheduleViewModel : BaseViewModel
    {

        public List<History> Encomes { get; set; }

        public List<History> Expenses { get; set; }

        public HistoryRepository historyRepository { get; set; }

        public List<ICalendarEvent> _events;

        public event PropertyChangedEventHandler PropertyChanged;

        public List<ICalendarEvent> Events
        {
            get { return _events; }
            set
            {
                if (_events != value)
                {
                    _events = value;
                    OnPropertyChanged(() => Events);

                    // redraw days with events when Events property changes
                    // Calendar.DrawDays();
                }
            }
        }
        public ScheduleViewModel()
        {
            historyRepository = new HistoryRepository();

            Encomes = new List<History>();
            Expenses = new List<History>();
            Encomes = GetHistoriesByType("Доходы");
            Expenses = GetHistoriesByType("Расходы");
            DateTime startDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 15);

            Events = new List<ICalendarEvent>();
            SetEvents();
        }
        public List<History> GetHistoriesByType(string Type)
        {
            return historyRepository.List(x => x.Activity.ActivityType.Title == Type && !x.IsRepeat
                                            && x.Account.Id == SingleCurrentAccount.GetInstance().Account.Id)
                                            .ToList();
        }
       
        public void SetEvents()
        {
            foreach (History history in Encomes)
            {
                Events.Add(new ScheduleCustomEvent() { DateFrom = history.Date, DateTo = history.Date, Label = $"{history.Activity.Title}", Color = "Green" , IsRepeat = history.IsRepeat, Amount=history.Amount}) ;
            }
            foreach (History history in Expenses)
            {
                Events.Add(new ScheduleCustomEvent() { DateFrom = history.Date, DateTo = history.Date, Label = $"{history.Activity.Title}", Color = "Red", IsRepeat = history.IsRepeat, Amount=history.Amount });
            }
        }
        public void OnPropertyChanged<T>(Expression<Func<T>> exp)
        {
            var memberExpression = (MemberExpression)exp.Body;
            var propertyName = memberExpression.Member.Name;

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
