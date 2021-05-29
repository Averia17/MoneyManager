using MoneyManager.Core.Models;
using MoneyManager.Core.RepositoryIntarfaces;
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
        
        public SaveHistoryViewModel saveHistoryViewModel { get; set; }

        public ItemChangedCommand(SaveHistoryViewModel saveHistoryViewModel)
        {
            this.saveHistoryViewModel = saveHistoryViewModel;
        }

        IUnitOfWork unitOfWork = new UnitOfWork();

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            ActivityType activityType = (ActivityType)parameter;
            saveHistoryViewModel.activities = (List<Activity>)unitOfWork.ActivityRepository.List(x => x.ActivityType.Id == activityType.Id);
            saveHistoryViewModel.History.Activity = saveHistoryViewModel.activities[0];

        }
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }
}
