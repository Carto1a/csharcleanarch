namespace CSharpCleanArch.Infrastructure.Filter;
public static class ExceptionFilterInitialize
{
    public static void AddExceptionFilter(this IServiceCollection services)
    {
        services.AddControllers(options =>
        {
            options.Filters.Add<ExceptionFilter>();
        });
    }
}