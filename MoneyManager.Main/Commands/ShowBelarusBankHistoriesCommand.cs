using MoneyManager.Main.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MoneyManager.Main.Commands
{
    public class ShowBelarusBankHistoriesCommand :ICommand
    {
        SettingsViewModel SettingsViewModel { get; set; }
        public ShowBelarusBankHistoriesCommand(SettingsViewModel settingsViewModel)
        {
            SettingsViewModel = settingsViewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            SettingsViewModel.ErrorMessage = string.Empty;
            BelarusBankInformation BelarusBankInformation = new BelarusBankInformation();

            try
            {
                BelarusBankInformation.GetBelarusBankHistories();
                SettingsViewModel.HistoriesFromBelarusBank = BelarusBankInformation.Histories;
                BelarusBankInformation.driver.Quit();

            }
            catch (Exception)
            {
                SettingsViewModel.ErrorMessage = "Не получилось получить данные из карты";
                BelarusBankInformation.driver.Quit();
            }
        }
    }
}
