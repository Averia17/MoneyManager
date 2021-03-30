using MoneyManager.Core.Models;
using System;

namespace MoneyManager.Core.RepositoryIntarfaces
{
    public interface IHistoryRepository : IRepository<History, Guid>
    {
    }
}
