using AutoSpot.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AutoSpot.Infrastructure.EntityFramework;

public class ApplicationDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Seller> Sellers { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<CarLot> CarLots { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.EnableSensitiveDataLogging();
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}