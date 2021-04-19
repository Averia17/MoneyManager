using MoneyManager.Core.Models;
using MoneyManager.Infrastructure.Repositories;
using PieChart;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManager.Main.ViewModels
{
    public class StatisticsViewModel : BaseViewModel
    {
        public ObservableCollection<PieCharItem> PieCharList { get; set; }

        public HistoryRepository historyRepository { get; set; }

        public StatisticsViewModel()
        {
            PieCharList = new ObservableCollection<PieCharItem>();
            historyRepository = new HistoryRepository();
            GetPieCharList();
        }


        public void GetPieCharList()
        {
            var histories = historyRepository.List(x => x.Activity.ActivityType.Title == "расходы")
                                                .GroupBy(x => x.Activity.Title).
                                                Select(g => new
                                                {
                                                    g.Key,
                                                    Sum = g.Sum(s => s.Amount),
                                                }).ToList();
            foreach (var item in histories)
            {
                PieCharList.Add(new PieCharItem() { TypeName = item.Key, TypeNumber = (int)item.Sum});
            }
        }
    }
}
