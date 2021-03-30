using System;
using System.ComponentModel;

namespace MoneyManager.Core.Models
{
    public class History : Entity<Guid>, INotifyPropertyChanged
    {
        private string _description { get; set; }
        public string Description {
            get { return _description; }
            set
            {
                _description = value;
                OnPropertyChanged(nameof(Description));
            }
        }

        private double _amount { get; set; }
        public double Amount
        {
            get { return _amount; }
            set
            {
                _amount = value;
                OnPropertyChanged(nameof(Amount));
            }
        }
        private DateTime _date = DateTime.Now;
        public DateTime Date
        {
            get { return _date; }
            set
            {
                _date = value;
                OnPropertyChanged(nameof(Date));
            }
        }
        private bool _isRepeat { get; set; }
        public bool IsRepeat
        {
            get { return _isRepeat; }
            set
            {
                _isRepeat = value;
                OnPropertyChanged(nameof(IsRepeat));
            }
        }
        private Account _account { get; set; }
        public Account Account
        {
            get { return _account; }
            set
            {
                _account = value;
                OnPropertyChanged(nameof(Account));
            }
        }
        private Activity _activity { get; set; }
        public Activity Activity
        {
            get { return _activity; }
            set
            {
                _activity = value;
                OnPropertyChanged(nameof(Activity));
            }
        }
       
        //public double Amount { get; set; }

        //public DateTime Date { get; set; }

        //public bool IsRepeat { get; set; }

        public Guid AccountId { get; set; }

        //public Account Account { get; set; }

        public Guid ActivityId { get; set; }

       // public Activity Activity { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    

}
