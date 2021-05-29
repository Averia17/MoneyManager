using MoneyManager.Core.Models;
using MoneyManager.Core.RepositoryIntarfaces;
using MoneyManager.Infrastructure.Repositories;
using MoneyManager.Main.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace MoneyManager.Main.ViewModels
{
    public class CreateHistoryViewModel : SaveHistoryViewModel
    {
        public ICommand CreateCommand { get; set; }

        private bool _isChecked { get; set; }
        public bool IsChecked
        {
            get { return _isChecked; }
            set
            {
                if (value != _isChecked)
                {
                    _isChecked = value;
                    OnPropertyChanged(nameof(IsChecked));

                }
            }
        }
       
        private ActivityType _SelectedItem { get; set; }
        public ActivityType SelectedItem
        {
            get { return _SelectedItem; }

            set
            {
                _SelectedItem = value;
                OnPropertyChanged("SelectedItem");
            }
        }
        public CreateHistoryViewModel()
        {
            ErrorMessageViewModel = new MessageViewModel();

            History = new History();
            ItemChangedCommand = new ItemChangedCommand(this);
            CreateCommand = new CreateCommand(History, this);
            ItemChangedCommand.Execute(Expense);

        }

    }

}
