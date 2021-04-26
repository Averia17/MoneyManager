using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManager.Core.Exceptions
{
    public class AccountNotFoundException : Exception
    {
        public string Username { get; set; }
        public AccountNotFoundException(string username)
        {
            Username = username;
        }

        public AccountNotFoundException(string message, string username) : base(message)
        {
            Username = username;
        }

        public AccountNotFoundException(string message, Exception innerException, string username) : base(message, innerException)
        {
            Username = username;
        }
    }
}
