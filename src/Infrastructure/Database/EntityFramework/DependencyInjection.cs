using CSharpCleanArch.Application;
using CSharpCleanArch.Application.Repository;
using CSharpCleanArch.Infrastructure.Database.EntityFramework.Repository;
using Microsoft.EntityFrameworkCore;

namespace CSharpCleanArch.Infrastructure.Database.EntityFramework;
public static class DependencyInjection
{
    public static IServiceCollection AddEntityFramework(
        this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<DataContext>(options =>
            /* options.UseInMemoryDatabase("InMemoryDatabase")); */
            options.UseSqlite(configuration.GetConnectionString("Sqlite")));
            /* options.UseSqlServer(configuration.GetConnectionString("SqlServerConnection"))); */

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IUsuarioRepository, UsuarioRepository>();

        return services;
    }
}