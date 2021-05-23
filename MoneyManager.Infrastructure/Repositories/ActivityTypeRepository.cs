using MoneyManager.Core.Models;
using MoneyManager.Core.RepositoryIntarfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManager.Infrastructure.Repositories
{
    public class ActivityTypeRepository : Repository<ActivityType>, IActivityTypeRepository
    {

        public ActivityType Find(Guid id) => DbSet.SingleOrDefault(x => x.Id == id);

        public IEnumerable<ActivityType> List(Expression<Func<ActivityType, bool>> predicate = null)
        {
            var query = DbSet.OrderByDescending(x => x.Title).AsQueryable();
            if (predicate != null)
            {
                query = query.Where(predicate);
            }
            return query.ToList();
        }

        public void Delete(Guid id)
        {
            ActivityType activityType = DbSet.Find(id);
            DbSet.Remove(activityType);
            Context.SaveChanges();
        }
        public void Create(ActivityType activityType)
        {
            DbSet.Add(activityType);
            Context.SaveChanges();
        }
        public ActivityType GetByTitle(string title) => DbSet.SingleOrDefault(x => x.Title == title);
    }
}
