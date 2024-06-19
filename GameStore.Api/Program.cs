using GameStore.Data;
using GameStore.Extensions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    
    builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

    builder.Services
        .AddDataProject()
        .AddApplicationProject();
}


var app = builder.Build();
{
    app.MapControllers();
    
    app.Run();
}

