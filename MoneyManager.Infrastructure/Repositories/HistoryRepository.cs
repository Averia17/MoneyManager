using Microsoft.EntityFrameworkCore;
using MoneyManager.Core.Models;
using MoneyManager.Core.RepositoryIntarfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace MoneyManager.Infrastructure.Repositories
{
    public class HistoryRepository : Repository<History>, IHistoryRepository
    {

        public History Find(Guid id) => MakeInclusions().SingleOrDefault(x => x.Id == id);

        public IEnumerable<History> List(Expression<Func<History, bool>> predicate = null)
        {
            var query = MakeInclusions().OrderByDescending(x => x.Date).ThenByDescending(x => x.Amount).AsQueryable();
            if (predicate != null)
            {
                query = query.Where(predicate);
            }
            return query;
        }

        public void Delete(Guid id)
        {
            History history = DbSet.Find(id);
            DbSet.Remove(history);
            Context.SaveChanges();
        }
        //возможно надо по-другому хз
        public void Edit(History history)
        {
            //ПРАБЛЕМЫ!ЫЫЫЫЫ!!
            History History = DbSet.Find(history.Id);
/*            History.AccountId = history.Account.Id;
            History.ActivityId = history.Activity.Id;
            History.Amount = history.Amount;
            History.Date = history.Date;
            History.Description = history.Description;
            History.IsRepeat = History.IsRepeat;*/
            Context.Entry(History).CurrentValues.SetValues(history);
            /*Delete(history.Id);
            
            Create(history);*/
            Context.SaveChanges();
        }
        public void Create(History history)
        {
            //Context.Histories.Add(history);
            DbSet.Add(history);

            Context.SaveChanges();
        }
        private IQueryable<History> MakeInclusions() =>
            DbSet.Include(x => x.Activity).ThenInclude(x => x.ActivityType).Include(x => x.Account);
    }
}
