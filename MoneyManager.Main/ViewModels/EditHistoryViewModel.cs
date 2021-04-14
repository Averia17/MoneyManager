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
    public class EditHistoryViewModel : SaveHistoryViewModel
    {
        public ICommand EditCommand { get; set; }

        public ICommand ItemChangedCommand { get; set; }

        private Activity _selectedActivity { get; set; }

        public Activity SelectedActivity
        {
            get { return _selectedActivity; }
            set
            {
                _selectedActivity = value;
                OnPropertyChanged(nameof(SelectedActivity));
            }
        }

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
      

        public EditHistoryViewModel()
        {
            History = new History();

            ItemChangedCommand = new ItemChangedCommand(this);
            History = LinkToEditCommand.History;
            EditCommand = new EditCommand(History);
            if(History != null)
                SelectedActivity = History.Activity;

        }
    }
}
