using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoneyManager.Core.Models;

namespace MoneyManager.Infrastructure.Configurations
{
    internal sealed class ActivityConfiguration : IEntityTypeConfiguration<Activity>
    {
        public void Configure(EntityTypeBuilder<Activity> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Title);
            builder.HasOne(e => e.ActivityType).WithMany(e => e.Activities).HasForeignKey(e => e.ActivityTypeId);
        }
    }
}
