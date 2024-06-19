using GameStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameStore.Data.Configurations;

public class GameConfiguration : IEntityTypeConfiguration<Game>
{
    public void Configure(EntityTypeBuilder<Game> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Title)
            .HasMaxLength(50)
            .IsRequired();
        
        builder.Property(c => c.PublisherId)
            .IsRequired();
    }
}