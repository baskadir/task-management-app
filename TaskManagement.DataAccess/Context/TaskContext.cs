using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TaskManagement.DataAccess.Configurations;
using TaskManagement.DataAccess.SeedData;
using TaskManagement.Entities.Concrete;

namespace TaskManagement.DataAccess.Context
{
    public class TaskContext : IdentityDbContext<AppUser,AppRole,int>
    {
        public TaskContext(DbContextOptions<TaskContext> options):base(options)
        {
        }

        public DbSet<Document> Documents { get; set; }
        public DbSet<Duty> Duties { get; set; }
        public DbSet<Status> Statuses { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new AppUserConfiguration());
            builder.ApplyConfiguration(new DocumentConfiguration());
            builder.ApplyConfiguration(new DutyConfiguration());
            builder.ApplyConfiguration(new StatusConfiguration());
            builder.ApplyConfiguration(new StatusSeed());
            builder.ApplyConfiguration(new AppRoleSeed());
            base.OnModelCreating(builder);
        }
    }
}
