using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManager.Core.RepositoryIntarfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IHistoryRepository HistoryRepository { get; }
        IAccountRepository AccountRepository { get; }
        IActivityRepository ActivityRepository { get; }
        IActivityTypeRepository ActivityTypeRepository { get; }
        void Commit();
    }
}
