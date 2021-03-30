using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManager.Core.Models
{
    //доход расход
    public class ActivityType : Entity<Guid>
    {
        public string Title { get; set; }

        public ICollection<Activity> Activities { get; set; }

    }
}
