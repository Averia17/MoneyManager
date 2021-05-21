using MoneyManager.Core.Models;
using System;

namespace MoneyManager.Core.RepositoryIntarfaces
{
    public interface IHistoryRepository : IRepository<History, Guid>
    {
        void Edit(History history);
        void Delete(Guid id);
        void Create(History activity);
    }
}
