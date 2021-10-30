using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Entities.Concrete;

namespace TaskManagement.DataAccess.SeedData
{
    public class AppRoleSeed : IEntityTypeConfiguration<AppRole>
    {
        public void Configure(EntityTypeBuilder<AppRole> builder)
        {
            builder.HasData(new AppRole()
            {
                Id = 1,
                Name = "Manager",
                NormalizedName = "MANAGER"
            },
            new AppRole()
            {
                Id = 2,
                Name = "Personel",
                NormalizedName = "PERSONEL"
            });
        }
    }
}
