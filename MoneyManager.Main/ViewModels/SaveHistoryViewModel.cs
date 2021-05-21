using MoneyManager.Core.Models;
using MoneyManager.Infrastructure.Repositories;
using MoneyManager.Main.Commands;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;

namespace MoneyManager.Main.ViewModels
{
    public abstract class SaveHistoryViewModel : BaseViewModel
    {
        public ActivityType Expense { get; set; }
        public ActivityType Encome { get; set; }
        public List<ActivityType> activityTypes { get; set; }

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

        public ActivityTypeRepository activityTypeRepository { get; set; }

        public ActivityRepository activityRepository { get; set; }

        public ICommand ItemChangedCommand { get; set; }


        private History _history { get; set; }

        public History History
        {
            get { return _history; }
            set
            {
                _history = value;
                OnPropertyChanged(nameof(History));
            }
        }
        double a;
        public bool CanCreate => History.Activity != null;

        public MessageViewModel ErrorMessageViewModel { get; set; }

        public string ErrorMessage
        {
            set => ErrorMessageViewModel.Message = value;
        }
        public string _amount { get; set; }
        public string Amount
        {
            get { return _amount; }
            set
            {
                _amount = value;
                OnPropertyChanged(nameof(Amount));
            }
        }
        public SaveHistoryViewModel()
        {
            History = new History();
            activityTypes = new List<ActivityType>();

            activityTypeRepository = new ActivityTypeRepository();
            activityRepository = new ActivityRepository();

            ItemChangedCommand = new ItemChangedCommand(this);

            GetActivityTypes();
            GetActivities();

            Expense = activityTypes[0];
            Encome = activityTypes[1];
        }
        public void GetActivityTypes()
        {
            activityTypes = (List<ActivityType>)activityTypeRepository.List();
        }
        public void GetActivities()
        {
            activities = (List<Activity>)activityRepository.List();
        }

    }
   
}
