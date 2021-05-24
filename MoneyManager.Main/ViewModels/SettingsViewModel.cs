using MoneyManager.Core.Models;
using MoneyManager.Infrastructure.Repositories;
using MoneyManager.Main.Commands;
using MoneyManager.Main.States.Accounts;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace MoneyManager.Main.ViewModels
{
    public class SettingsViewModel: BaseViewModel
    {
        public List<History> Histories { get; set; }
        private List<History> _repeatedHistories { get; set; }

        public List<History> RepeatedHistories
        {
            get { return _repeatedHistories; }
            set
            {
                _repeatedHistories = value;
                OnPropertyChanged(nameof(RepeatedHistories));
            }
        }
        public HistoryRepository historyRepository { get; set; }
        public Account CurrentAccount { get; set; }
        public double Balance { get; set; }

        public History History { get; set; }
        public ICommand UpdateViewCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand LinkToEditCommand { get; set; }
        public ICommand ShowBelarusBankHistoriesCommand { get; set; }
        public ICommand AddHistoryToDatabaseCommand { get; set; }
        private List<History> _historiesFromBelarusBank { get; set; }
        public List<History> HistoriesFromBelarusBank
        {
            get { return _historiesFromBelarusBank; }
            set
            {
                _historiesFromBelarusBank = value;
                OnPropertyChanged(nameof(HistoriesFromBelarusBank));
            }
        }

        public SettingsViewModel()
        {
            historyRepository = new HistoryRepository();
            Histories = new List<History>();
            RepeatedHistories = new List<History>();
            History = new History();
            UpdateViewCommand = new UpdateViewCommand(MainWindow.MainView);
            DeleteCommand = new DeleteCommand(this);
            LinkToEditCommand = new LinkToEditCommand();
            AddHistoryToDatabaseCommand = new AddHistoryToDatabaseCommand(this);
            ShowBelarusBankHistoriesCommand = new ShowBelarusBankHistoriesCommand(this);
            CurrentAccount = new Account();
            CurrentAccount = SingleCurrentAccount.GetInstance().Account;
            GetHistories();
            Balance = BalanceViewModel.GetBalance(Histories);

        }
        public override void GetHistories()
        {
            Histories = historyRepository.List(x => x.Account.Id == CurrentAccount.Id && !x.IsRepeat).ToList();

            RepeatedHistories = historyRepository.List(x => x.Account.Id == CurrentAccount.Id && x.IsRepeat).ToList();

        }
    }
}
