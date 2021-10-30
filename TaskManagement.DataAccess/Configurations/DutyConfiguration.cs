using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManagement.Entities.Concrete;

namespace TaskManagement.DataAccess.Configurations
{
    public class DutyConfiguration : IEntityTypeConfiguration<Duty>
    {
        public void Configure(EntityTypeBuilder<Duty> builder)
        {
            builder.Property(x => x.Title).HasMaxLength(300).IsRequired();
            builder.Property(x => x.Content).HasMaxLength(2000).IsRequired();
            builder.Property(x => x.CreatedDate).HasDefaultValueSql("getdate()");
            builder.Property(x => x.EndDate).IsRequired();

            builder.Property(x => x.StatusId).HasDefaultValueSql("1");

            builder.HasOne(x => x.Status).WithMany(x => x.Duties).HasForeignKey(x => x.StatusId);
            builder.HasOne(x => x.AppUser).WithMany(x => x.Duties).HasForeignKey(x => x.AppUserId);
        }
    }
}
