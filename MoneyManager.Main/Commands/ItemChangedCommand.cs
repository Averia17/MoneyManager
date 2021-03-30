using MoneyManager.Core.Models;
using MoneyManager.Infrastructure.Repositories;
using MoneyManager.Main.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MoneyManager.Main.Commands
{
    public class ItemChangedCommand : ICommand, INotifyPropertyChanged
    {
       
        public event PropertyChangedEventHandler PropertyChanged;
        
        public CreateHistoryViewModel createHistoryViewModel { get; set; }

        public ItemChangedCommand(CreateHistoryViewModel createHistoryViewModel)
        {
            this.createHistoryViewModel = createHistoryViewModel;
        }

        ActivityRepository activityRepository = new ActivityRepository();

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            ActivityType activityType = (ActivityType)parameter;
            //Console.WriteLine(parameter);
            createHistoryViewModel.activities = (List<Activity>)activityRepository.List(x => x.ActivityType.Id == activityType.Id);
            /*if (parameter.ToString() == "доходы")
            {
                createHistoryViewModel.activities = (List<Activity>)activityRepository.List(x => x.ActivityType.Title == "доходы");
            }
            else if (parameter.ToString() == "расходы")
            {
                createHistoryViewModel.activities = (List<Activity>)activityRepository.List(x => x.ActivityType.Title == "расходы");

            }*/
        }
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }
}
