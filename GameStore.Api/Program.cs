using GameStore;
using GameStore.Application.AutoMapperProfiles;
using GameStore.Data;
using GameStore.Extensions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    
    builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

    builder.Services.AddAutoMapper(typeof(PublisherProfile).Assembly);
    
    builder.Services
        .AddRepositories()
        .AddServices()
        .AddExceptionHandler<GlobalExceptionHandler>();
}


var app = builder.Build();
{
    app.MapControllers();
    app.UseExceptionHandler(_ => { });
    
    app.Run();
}

