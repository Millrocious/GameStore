using GameStore;
using GameStore.Data;
using GameStore.Extensions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    
    builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
    
    builder.Services.AddExceptionHandler<GlobalExceptionHandler>();

    builder.Services
        .AddRepositories()
        .AddServices()
        .AddMappers();
}


var app = builder.Build();
{
    app.MapControllers();
    app.UseExceptionHandler(_ => { });
    
    app.Run();
}

