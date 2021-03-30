using Microsoft.EntityFrameworkCore;
using MoneyManager.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManager.Infrastructure.Repositories
{
    public class Repository<TEntity> where TEntity : Entity
    {
        protected readonly MoneyManagerContext Context;
        protected readonly DbSet<TEntity> DbSet;

        protected Repository()
        {
            Context = new MoneyManagerContext();
            DbSet = Context.Set<TEntity>();
        }
    }
}
