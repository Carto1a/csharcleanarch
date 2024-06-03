using CSharpCleanArch.Application.UseCases;

namespace CSharpCleanArch.Application;
public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<CreateUsuarioUseCase>();
        services.AddScoped<GetAllUsuariosUseCase>();
        /* services.AddScoped<GetUsuarioByCpfUseCase>(); */
        services.AddScoped<UpdateUsuarioByCpfUseCase>();
        services.AddScoped<DeleteUsuarioByCpfUseCase>();

        return services;
    }
}