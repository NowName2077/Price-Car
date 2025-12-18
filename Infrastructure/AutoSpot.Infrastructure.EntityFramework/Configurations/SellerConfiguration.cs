using AutoSpot.Domain.Entities;
using AutoSpot.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutoSpot.Infrastructure.EntityFramework.Configurations;


public class SellerConfiguration : IEntityTypeConfiguration<Seller>
{
    public void Configure(EntityTypeBuilder<Seller> builder)
    {
        builder.HasKey(u => u.Id);
        builder.Property(u => u.Id).IsRequired();

        builder.Property(u => u.Username)
            .IsRequired()
            .HasConversion(username => username!.Value, value => new Username(value))
            .HasMaxLength(30);

        builder.HasMany(u => u.ActiveCarLots)
            .WithOne(l => l.Seller)
            .HasForeignKey("SellerId")
            .HasPrincipalKey(u => u.Id);
    }
}