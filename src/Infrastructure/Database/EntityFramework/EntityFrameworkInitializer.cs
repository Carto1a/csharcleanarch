using CSharpCleanArch.Application;
using CSharpCleanArch.Application.Repository;
using CSharpCleanArch.Infrastructure.Database.EntityFramework.Repository;
using Microsoft.EntityFrameworkCore;

namespace CSharpCleanArch.Infrastructure.Database.EntityFramework;
public static class EntityFrameworkInitializer
{
    public static IServiceCollection AddEntityFramework(
        this IServiceCollection services, IConfiguration configuration)
    {
        var basePath = AppDomain.CurrentDomain.BaseDirectory;
        var fullPath = Path.Combine(basePath, "app.sqlite");

        services.AddDbContext<DataContext>(options =>
            /* options.UseInMemoryDatabase("InMemoryDatabase")); */
            options.UseSqlite($"Data Source={fullPath}"));
            /* options.UseSqlServer(configuration.GetConnectionString("SqlServerConnection"))); */

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IUsuarioRepository, UsuarioRepository>();

        return services;
    }

    public static void MigrateDatabase(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        var services = scope.ServiceProvider;
        var context = services.GetRequiredService<DataContext>();
        if (!context.Database.IsSqlite())
            return;

        var basePath = AppDomain.CurrentDomain.BaseDirectory;
        var fullPath = Path.Combine(basePath, "app.sqlite");
        if (File.Exists(fullPath))
            return;

        context.Database.Migrate();
    }
}