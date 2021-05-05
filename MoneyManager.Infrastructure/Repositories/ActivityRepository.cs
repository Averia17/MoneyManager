using Microsoft.EntityFrameworkCore;
using MoneyManager.Core.Models;
using MoneyManager.Core.RepositoryIntarfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

using System.Threading.Tasks;

namespace MoneyManager.Infrastructure.Repositories
{
    public class ActivityRepository : Repository<Activity>, IActivityRepository
    {

        public Activity Find(Guid id) => MakeInclusions().SingleOrDefault(x => x.Id == id);

        public IEnumerable<Activity> List(Expression<Func<Activity, bool>> predicate = null)
        {
            /*using (var transaction = Context.Database.BeginTransaction())
            {
                try
                { 
                }
                catch (Exception ex)
                {
                    Context.Database.RollbackTransaction();
                }
            }*/

            var query = MakeInclusions().OrderByDescending(x => x.Title).AsQueryable();
            if (predicate != null)
            {
                query = query.Where(predicate);
            }
            return query.ToList();
        }

        public void Delete(Guid id)
        {
            Activity activity = DbSet.Find(id);
            DbSet.Remove(activity);
            Context.SaveChanges();
        }
        public void Create(Activity activity)
        {
            DbSet.Add(activity);
            Context.SaveChanges();
        }
        private IQueryable<Activity> MakeInclusions() =>
            DbSet.Include(x => x.ActivityType);
    }
}
