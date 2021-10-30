using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManagement.Entities.Concrete;

namespace TaskManagement.DataAccess.SeedData
{
    public class StatusSeed : IEntityTypeConfiguration<Status>
    {
        public void Configure(EntityTypeBuilder<Status> builder)
        {
            builder.HasData(new Status()
            {
                Id = 1,
                Definition = "Beklemede"
            },
            new Status()
            {
                Id = 2,
                Definition = "Devam Ediyor"
            },
            new Status()
            {
                Id = 3,
                Definition = "Tamamlandı"
            });
        }
    }
}
