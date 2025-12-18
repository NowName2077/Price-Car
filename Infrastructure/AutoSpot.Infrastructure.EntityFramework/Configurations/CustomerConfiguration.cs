using AutoSpot.Domain.Entities;
using AutoSpot.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutoSpot.Infrastructure.EntityFramework.Configurations;

public class CustomerConfiguration: IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id).IsRequired();

        builder.Property(c => c.Username)
            .IsRequired()
            .HasConversion(username => username!.Value, value => new Username(value))
            .HasMaxLength(30);

        builder.HasMany(c => c.ObservableCarLots)
            .WithOne()
            .HasForeignKey("CustomerId")
            .HasPrincipalKey(c => c.Id);
    }
}