using GameStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameStore.Data.Configurations;

public class PublisherConfiguration : IEntityTypeConfiguration<Publisher>
{
    public void Configure(EntityTypeBuilder<Publisher> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Name)
            .HasMaxLength(50)
            .IsRequired();
        
        builder.HasMany(p => p.Games)
            .WithOne(g => g.Publisher)
            .HasForeignKey(g => g.PublisherId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}