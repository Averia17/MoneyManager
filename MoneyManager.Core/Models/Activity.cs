using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManager.Core.Models
{
    public class Activity : Entity<Guid>
    {
        public string Title { get; set; }

        public Guid ActivityTypeId { get; set; }

        public ActivityType ActivityType { get; set; }

        public ICollection<History> Histories { get; set; }

        // public string Image { get; set; }

        public override string ToString()
        {
            return Title;
        }
    }
    
}
