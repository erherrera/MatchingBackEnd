using System;
using Domain;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace Persistence;


public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<IDataverseContext, DataverseContext>();
        services.AddScoped<IMentorRepository, DataverseMentorRepository>();
        services.AddScoped<IYERepository, DataverseYERepository>();
        return services;
    }
}

