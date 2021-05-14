using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManager.Core.Exceptions
{
    public class AmountLessThanZeroException:Exception
    {
        public double Amount { get; set; }
        public AmountLessThanZeroException(double amount)
        {
            Amount = amount;
        }

        public AmountLessThanZeroException(string message, double amount) : base(message)
        {
            Amount = amount;
        }

        public AmountLessThanZeroException(string message, Exception innerException, double amount) : base(message, innerException)
        {
            Amount = amount;
        }
    }
}
