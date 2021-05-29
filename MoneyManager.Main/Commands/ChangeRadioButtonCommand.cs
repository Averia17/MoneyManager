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
    class ChangeRadioButtonCommand: ICommand, INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        public FilterBalanceViewModel FilterBalanceViewModel { get; set; }

        public ChangeRadioButtonCommand(FilterBalanceViewModel FilterBalanceViewModel)
        {
            this.FilterBalanceViewModel = FilterBalanceViewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            ActivityType activityType = (ActivityType)parameter;
            List<History> histories = new List<History>();
            histories = (List<History>)FilterBalanceViewModel.unitOfWork.HistoryRepository.List().ToList();
            histories = histories.Where(x => x.Activity.ActivityTypeId == activityType.Id && x.Date >= FilterBalanceViewModel.TbFrom && x.Date <= FilterBalanceViewModel.TbTo).ToList();
            FilterBalanceViewModel.Histories = histories;
            FilterBalanceViewModel.RefreshHistoryCollectionView();

            FilterBalanceViewModel.UpdateProperties();

        }
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }
}
