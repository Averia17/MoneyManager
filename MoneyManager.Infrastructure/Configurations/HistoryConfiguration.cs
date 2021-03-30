using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoneyManager.Core.Models;

namespace MoneyManager.Infrastructure.Configurations
{
    internal sealed class HistoryConfiguration : IEntityTypeConfiguration<History>
    {

        public void Configure(EntityTypeBuilder<History> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Amount);
            builder.Property(e => e.Date);
            builder.Property(e => e.Description);
            builder.Property(e => e.IsRepeat);
            builder.HasOne(e => e.Activity).WithMany(e => e.Histories).HasForeignKey(e => e.ActivityId);
            builder.HasOne(e => e.Account).WithMany(e => e.Histories).HasForeignKey(e => e.AccountId);
        }
    }
}
