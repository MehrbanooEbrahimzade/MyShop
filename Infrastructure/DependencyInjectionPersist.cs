using Infrastructure.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{

    public static class DependencyInjectionPersist
    {
        public static void ConfigureInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DatabaseContext>(x =>
            {
                x.UseSqlServer(configuration.GetConnectionString("MyShopConnection"));
            });
        }
    }

}

