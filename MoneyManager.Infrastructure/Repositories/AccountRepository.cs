using Microsoft.EntityFrameworkCore;
using MoneyManager.Core.Models;
using MoneyManager.Core.RepositoryIntarfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;


namespace MoneyManager.Infrastructure.Repositories
{
    public class AccountRepository : Repository<Account>, IAccountRepository
    {
        public Account Find(Guid id) => DbSet.SingleOrDefault(x => x.Id == id);


        public Account GetByEmail(string email) => DbSet.SingleOrDefault(x => x.Email == email);

        public IEnumerable<Account> List(Expression<Func<Account, bool>> predicate = null)
        {
            var query = DbSet.OrderByDescending(x => x.Username).AsQueryable();
            if (predicate != null)
            {
                query = query.Where(predicate);
            }
            return query.ToList();
        }
        public void Create(Account account)
        {
            DbSet.Add(account);
            Context.SaveChanges();
        }
        
    }
}
