using Microsoft.EntityFrameworkCore;
using MoneyManager.Core.Models;
using MoneyManager.Infrastructure.Configurations;

namespace MoneyManager.Infrastructure
{
    public class MoneyManagerContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<History> Histories { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<ActivityType> ActivityTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["EFBDConnection"].ConnectionString;
            optionsBuilder.UseSqlServer(@"Server=(local);Database=MoneyManager.Db;Integrated Security=True");
           // optionsBuilder.UseSqlServer(@"Server=tcp:averiatest.database.windows.net,1433;Initial Catalog=MoneyManager.Db;Persist Security Info=False;User ID=artyom;Password=Somehard1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new HistoryConfiguration());
            modelBuilder.ApplyConfiguration(new AccountConfiguration());
            modelBuilder.ApplyConfiguration(new ActivityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ActivityConfiguration());

            base.OnModelCreating(modelBuilder);
        }

    }
}
