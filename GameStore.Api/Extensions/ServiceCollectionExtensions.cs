using GameStore.Application.AutoMapperProfiles;
using GameStore.Application.Services.Implementations;
using GameStore.Application.Services.Interfaces;
using GameStore.Data.Repositories;
using GameStore.Domain.Interfaces.Repositories;

namespace GameStore.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IGameRepository, GameRepository>();
        services.AddScoped<IPublisherRepository, PublisherRepository>();

        return services;
    }
    
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IPublisherService, PublisherService>();

        return services;
    }
}