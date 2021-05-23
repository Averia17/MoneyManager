using Microsoft.EntityFrameworkCore;
using MoneyManager.Core.RepositoryIntarfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManager.Infrastructure.Repositories
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private MoneyManagerContext _context;
        private IAccountRepository _accountRepository;
        private IHistoryRepository _historyRepository;
        private IActivityRepository _activityRepository;
        private IActivityTypeRepository _activityTypeRepository;


        private MoneyManagerContext Context
        {
            get
            {
                return _context;
            }
            set
            {
                _context = new MoneyManagerContext();
            }
         }

        public IHistoryRepository HistoryRepository
        {
            get
            {
                if (_historyRepository == null)
                    _historyRepository = new HistoryRepository();
                return _historyRepository;
            }
        }

        public IAccountRepository AccountRepository
        {
            get
            {
                if (_accountRepository == null)
                    _accountRepository = new AccountRepository();
                return _accountRepository;
            }
        }
        public IActivityTypeRepository ActivityTypeRepository
        {
            get
            {
                if (_activityTypeRepository == null)
                    _activityTypeRepository = new ActivityTypeRepository();
                return _activityTypeRepository;
            }
        }
        public IActivityRepository ActivityRepository
        {
            get
            {
                if (_activityRepository == null)
                    _activityRepository = new ActivityRepository();
                return _activityRepository;
            }
        }



        public UnitOfWork()
        {
            var optionsBuilder = new DbContextOptionsBuilder<MoneyManagerContext>();
        }

        public void Commit()
        {
            if (_isDisposed)
            {
                throw new ObjectDisposedException("UnitOfWork");
            }

            Context.SaveChanges();
        }

        private bool _isDisposed;

        public void Dispose()
        {
            if (_context == null)
            {
                return;
            }

            if (!_isDisposed)
            {
                Context.Dispose();
            }

            _isDisposed = true;
        }
    }
}
