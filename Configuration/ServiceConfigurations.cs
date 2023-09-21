using Database;
using Manager.Contracts;
using ManagerAbstructions.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repository.Contracts;
using RepositoryAbstruction.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configuration
{
    public class ServiceConfigurations
    {
        public static void Configuration(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(opts =>
                opts.UseSqlServer(configuration.GetConnectionString("AppConnectionString"),
                x => x.MigrationsAssembly("Database")
            ));

         

            //Product
            services.AddTransient<IProductManager, ProductManager>();
            services.AddTransient<IProductRepo, ProductRepo>();
        }

    }
}
