using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MyApp.DataAccess
{
    public static class Ext
    {
        public static IServiceCollection AddData(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IUserRepository, UserRepository>();

            serviceCollection.AddDbContext<MyAppContext>(options =>
            {
                //var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
                options.UseNpgsql("Host=localhost;Database=MyApp;Username=postgres;Password=postgres");
            });

            return serviceCollection;
        }
    }
}
