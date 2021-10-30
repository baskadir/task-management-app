using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaskManagement.Business.Interfaces;
using TaskManagement.Business.Services;
using TaskManagement.DataAccess.Context;
using TaskManagement.DataAccess.UnitOfWork;
using TaskManagement.Entities.Concrete;

namespace TaskManagement.Business.Extensions
{
    public static class DependecyExtension
    {
        public static void AddDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddIdentity<AppUser, AppRole>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 1;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
            }).AddEntityFrameworkStores<TaskContext>();

            services.AddDbContext<TaskContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("SqlConnectionString"));
            });

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IDutyService, DutyService>();
            services.AddTransient<IEmailService, EmailService>();
        }
    }
}
