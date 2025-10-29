namespace WebApplication_API.ExtensionServices;

public static class GeneralHttpExtensions
{
    public static void RegisterHttpServices(this IServiceCollection service)
    {
        service.AddControllers();
        service.AddEndpointsApiExplorer();
        service.ConfigureHttpJsonOptions(options => {
            options.SerializerOptions.PropertyNamingPolicy = System.Text.Json.JsonNamingPolicy.CamelCase;
            options.SerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;
        });
    }
}
