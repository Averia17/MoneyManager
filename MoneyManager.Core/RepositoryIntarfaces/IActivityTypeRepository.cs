using MoneyManager.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManager.Core.RepositoryIntarfaces
{
    public interface IActivityTypeRepository : IRepository<ActivityType, Guid>
    {
        void Delete(Guid id);
    }
}
