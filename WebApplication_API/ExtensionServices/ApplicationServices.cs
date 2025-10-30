using WebApplication_API.Configuration;

namespace WebApplication_API.ExtensionServices;

public static class ApplicationServices
{
    public static void RegisterServices(this IServiceCollection services, IConfiguration config)
    {
        var constring = config.GetConnectionString("MyConString");
        services.AddSwaggerGen();
        services.AddScoped<ITodoItems, MockItems>();
        services.AddScoped<IProducts, ProductService>();
        services.AddDbContext<tempdbContext>(x => x.UseSqlServer(config.GetConnectionString("MyConString")));
        services.Configure<AppSettings>(config.GetSection("AppSettings"));
    }
}
