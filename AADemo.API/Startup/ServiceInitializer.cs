using AADemo.Domain.Entities;
using AADemo.Infrastructure.Services;

namespace AADemo.API.Startup;

public static class ServiceInitializer
{
	public static IServiceCollection RegisterLocalServices(this IServiceCollection services)
	{
        RegisterDemoServices(services);

        return services;
    }

    private static void RegisterDemoServices(IServiceCollection services)
    {
        services.AddScoped<ICreditDataService, CreditDataService>();
    }
}


