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
    public class AddHistoryToDatabaseCommand : ICommand, INotifyPropertyChanged
    {
        private SettingsViewModel _settingsViewModel { get; set; }
        public SettingsViewModel SettingsViewModel
        {
            get { return _settingsViewModel; }
            set
            {
                _settingsViewModel = value;
                OnPropertyChanged(nameof(SettingsViewModel));
            }
        }
        public AddHistoryToDatabaseCommand(SettingsViewModel settingsViewModel)
        {
            SettingsViewModel = settingsViewModel;
        }
        public event EventHandler CanExecuteChanged;
        public event PropertyChangedEventHandler PropertyChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            History history = (History)parameter;
            SettingsViewModel.HistoriesFromBelarusBank.Remove(history);

            history.Account = null;
            history.Activity = null;
            new HistoryRepository().Create(history);
            SettingsViewModel.RefreshHistoryCollectionView();
        }
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
