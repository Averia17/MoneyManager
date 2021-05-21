using MoneyManager.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManager.Core.RepositoryIntarfaces
{
    public interface IActivityRepository : IRepository<Activity, Guid>
    {
        void Delete(Guid id);
        void Create(Activity activity);

    }
}
