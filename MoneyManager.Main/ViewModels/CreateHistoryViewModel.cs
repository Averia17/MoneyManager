using MoneyManager.Core.Models;
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
            History = new History();
            ItemChangedCommand = new ItemChangedCommand(this);
            ActivityTypeRepository activityTypeRepository = new ActivityTypeRepository();
            CreateCommand = new CreateCommand(History);
            ItemChangedCommand.Execute(Expense);

        }

    }
    public class BooleanToStringValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (System.Convert.ToString(((ActivityType)value).Title).Equals(System.Convert.ToString(parameter)))
            {
                return true;
            }
            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (System.Convert.ToBoolean(value))
            {
                return parameter;
            }
            return null;
        }
    }
}
