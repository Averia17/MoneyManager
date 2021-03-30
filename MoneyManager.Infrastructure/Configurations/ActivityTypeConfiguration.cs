using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoneyManager.Core.Models;

namespace MoneyManager.Infrastructure.Configurations
{
    internal sealed class ActivityTypeConfiguration : IEntityTypeConfiguration<ActivityType>
    {
        public void Configure(EntityTypeBuilder<ActivityType> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Title);
        }
    }
}
