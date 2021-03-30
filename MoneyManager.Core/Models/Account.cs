using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManager.Core.Models
{
    public class Account : Entity<Guid>
    {
        public string Name { get; set; }

        public int Balance { get; set; }

        public string Password { get; set; }

        public ICollection<History> Histories { get; set; }
    }
}
