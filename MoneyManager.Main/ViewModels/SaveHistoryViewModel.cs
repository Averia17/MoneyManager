using MoneyManager.Core.Models;
using MoneyManager.Infrastructure.Repositories;
using MoneyManager.Main.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MoneyManager.Main.ViewModels
{
    public abstract class SaveHistoryViewModel : BaseViewModel
    {
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

        public SaveHistoryViewModel()
        {
            History = new History();
            activityTypes = new List<ActivityType>();

            activityTypeRepository = new ActivityTypeRepository();
            activityRepository = new ActivityRepository();

            ItemChangedCommand = new ItemChangedCommand(this);

            GetActivityTypes();
            GetActivities();
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
