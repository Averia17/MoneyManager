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
        private bool _isExpenseChecked { get; set; }
        public bool IsExpenseChecked
        {
            get
            {
                
                return _isExpenseChecked;
            }
            set
            {
                _isExpenseChecked = value;
                OnPropertyChanged(nameof(IsExpenseChecked));

            }
        }
        private bool _isEncomeChecked { get; set; }

        public bool IsEncomeChecked
        {
            get
            {
                return _isEncomeChecked;

            }
            set
            {
                _isEncomeChecked = value;
                OnPropertyChanged(nameof(IsEncomeChecked));
            }
        }
        private History _history { get; set; }

      

        public EditHistoryViewModel()
        {

            ItemChangedCommand = new ItemChangedCommand(this);
            History = LinkToEditCommand.History;
            EditCommand = new EditCommand(History);
            if (History?.Activity?.ActivityType?.Title == "Доходы")
                IsEncomeChecked = true;
            else
                IsExpenseChecked = true;
            if (History != null)
            { 
                SelectedActivity = History.Activity;
                if (IsExpenseChecked)
                    ItemChangedCommand.Execute(Expense);
                else if (IsEncomeChecked)
                    ItemChangedCommand.Execute(Encome);
            
                Activity activity = new Activity();
                activity = activities.Find(x => x.Id == History.ActivityId);
                History.Activity = activity;
            }

        }
    }
}
