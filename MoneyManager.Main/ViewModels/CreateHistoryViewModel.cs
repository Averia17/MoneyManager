using MoneyManager.Core.Models;
using MoneyManager.Infrastructure.Repositories;
using MoneyManager.Main.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MoneyManager.Main.ViewModels
{
    public class CreateHistoryViewModel : SaveHistoryViewModel
    {
        public ICommand CreateCommand { get; set; }

        public ICommand ItemChangedCommand { get; set; }

        public CreateHistoryViewModel()
        {
            History = new History();
            ItemChangedCommand = new ItemChangedCommand(this);
            
            CreateCommand = new CreateCommand(History);

        }

    }
}
