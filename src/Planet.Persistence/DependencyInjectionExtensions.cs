using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Planet.Application.Services.Repositories;
using Planet.Application.Services.SqlConnection;
using Planet.Domain.SharedKernel;
using Planet.Persistence.Contexts;
using Planet.Persistence.Interceptors;
using Planet.Persistence.Repositories;
using Planet.Persistence.SqlConnection;

namespace Planet.Persistence
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<ISqlConnectionFactory, SqlServerConnectionFactory>();

            services.AddScoped<DomainEventInterceptor>();
            services.AddDbContext<PlanetContext>((sp, options) =>
            {
                options.UseSqlServer(configuration.GetConnectionString("SqlServer"));
                options.AddInterceptors(sp.GetRequiredService<DomainEventInterceptor>());
            });
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IBoardRepository, BoardRepository>();
            services.AddScoped<ICardRepository, CardRepository>();

            return services;
        }
    }
}
