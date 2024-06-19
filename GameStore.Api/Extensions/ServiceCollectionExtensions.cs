using GameStore.Application.AutoMapperProfiles;
using GameStore.Application.Services.Implementations;
using GameStore.Application.Services.Interfaces;
using GameStore.Data.Repositories;

namespace GameStore.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDataProject(this IServiceCollection services)
    {
        services.AddScoped<IGameRepository, GameRepository>();
        services.AddScoped<IPublisherRepository, PublisherRepository>();

        return services;
    }
    
    public static IServiceCollection AddApplicationProject(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(PublisherProfile).Assembly);
        
        services.AddScoped<IPublisherService, PublisherService>();

        return services;
    }
}