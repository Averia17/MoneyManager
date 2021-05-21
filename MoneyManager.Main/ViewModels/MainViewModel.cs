using MoneyManager.Core.Models;
using MoneyManager.Main.Commands;
using MoneyManager.Main.States.Accounts;
using MoneyManager.Main.States.Authenticators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MoneyManager.Main.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private BaseViewModel _selectedViewModel;
        public BaseViewModel SelectedViewModel
        {
            get { return _selectedViewModel; }
            set
            {
                _selectedViewModel = value;
                
                OnPropertyChanged(nameof(SelectedViewModel));
            }
        }

        public UpdateViewCommand UpdateViewCommand { get; set; }
        public Account CurrentAccount { get; set; }

        public bool _isLoggin { get; set; }
        public bool IsLoggin {
            get { return _isLoggin; }
            set
            {
                _isLoggin = value;

                OnPropertyChanged(nameof(IsLoggin));
            }
        }

        public MainViewModel()
        {
            UpdateViewCommand = new UpdateViewCommand(this);
            //UpdateViewCommand.Execute("Login");
          
            CheckLoggin();
        }

        public void CheckLoggin()
        {
            SingleCurrentAccount currentAccount = SingleCurrentAccount.GetInstance();
            CurrentAccount = currentAccount.Account;
            if (CurrentAccount.Username == null)
                IsLoggin = false;
            else
                IsLoggin = true;
        }
    }
}
