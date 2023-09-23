using Database;
using Manager;
using ManagerAbstructions.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repository;
using RepositoryAbstruction.Contracts;

namespace Configuration
{
    public static class ServiceConfigurations
    {
        public static void Configuration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(opts =>
                opts.UseSqlServer(configuration.GetConnectionString("AppConnectionString"),
                x => x.MigrationsAssembly("Database")
            ));

            services.AddTransient<IStudentRepository, StudentRepository>();
            services.AddTransient<IStudentManager, StudentManager>();

            services.AddTransient<IClassRepository, ClassRepository>();
            services.AddTransient<IClassManager, ClassManager>();
        }

    }
}
