using MoneyManager.Core.RepositoryIntarfaces.AuthenticationRepository;
using MoneyManager.Infrastructure.Repositories;
using MoneyManager.Main.States.Accounts;
using MoneyManager.Main.States.Authenticators;
using MoneyManager.Main.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MoneyManager.Main.Commands
{
    public class UpdateViewCommand : ICommand
    {
        private MainViewModel viewModel;

        public UpdateViewCommand(MainViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter.ToString() == "Balance")
            {
                viewModel.SelectedViewModel = new BalanceViewModel();
            }
            else if (parameter.ToString() == "Schedule")
            {
                viewModel.SelectedViewModel = new ScheduleViewModel();
            }
            else if (parameter.ToString() == "CreateHistory")
            {
                viewModel.SelectedViewModel = new CreateHistoryViewModel();

            }
            else if (parameter.ToString() == "EditHistory")
            {
                viewModel.SelectedViewModel = new EditHistoryViewModel();

            }
            else if (parameter.ToString() == "FilterBalance")
            {
                viewModel.SelectedViewModel = new FilterBalanceViewModel();

            }
            else if (parameter.ToString() == "Statistics")
            {
                viewModel.SelectedViewModel = new StatisticsViewModel();

            }
            else if (parameter.ToString() == "Settings")
            {
                viewModel.SelectedViewModel = new SettingsViewModel();
            }
            
            else if (parameter.ToString() == "Login")
            {
                viewModel.SelectedViewModel  = (new LoginViewModel(new Authenticator(new AuthenticationRepository(new AccountRepository(), new Microsoft.AspNet.Identity.PasswordHasher()), new AccountStore())));
            }
            else if (parameter.ToString() == "Register")
            {
                viewModel.SelectedViewModel  = (new RegisterViewModel(new Authenticator(new AuthenticationRepository(new AccountRepository(), new Microsoft.AspNet.Identity.PasswordHasher()), new AccountStore())));
            }
        }
    }
}
