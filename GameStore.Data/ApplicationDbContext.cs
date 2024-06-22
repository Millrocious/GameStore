using GameStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Publisher> Publishers { get; init; }
    public DbSet<Game> Games { get; init; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}