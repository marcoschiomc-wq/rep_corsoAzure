namespace WebApplication_API.ExtensionServices;

public static class ApplicationServices
{
    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddSwaggerGen();
        services.AddScoped<ITodoItems, MockItems>();
        services.AddScoped<IProducts, ProductService>();
        services.AddDbContext<tempdbContext>(x => x.UseSqlServer("Data Source=(localdb)\\mssqllocaldb;Initial Catalog=tempdb;Integrated Security=True"));

    }
}
