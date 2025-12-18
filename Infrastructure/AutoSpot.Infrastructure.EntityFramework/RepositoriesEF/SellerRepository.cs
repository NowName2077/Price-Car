using Microsoft.EntityFrameworkCore;
using AutoSpot.Domain.Entities;
using AutoSpot.Domain.Repositories.Abstractions;
using AutoSpot.Infrastructure.EntityFramework;

namespace AutoSpot.Infrastructure.EntityFramework.RepositoriesEF;

public class SellerRepository(ApplicationDbContext context) : EFRepository<Seller, Guid>(context), ISellersRepository
{
    private readonly DbSet<Seller> _sellers = context.Set<Seller>();

    public override Task<Seller?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        => _sellers.Include(u => u.ActiveCarLots)
            .FirstOrDefaultAsync(u => u.Id == id, cancellationToken);

    public Task<Seller?> GetSellerByUsernameAsync(string username, CancellationToken cancellationToken)
        => _sellers.Include(u => u.ActiveCarLots)
            .FirstOrDefaultAsync(u => u.Username.Value == username, cancellationToken);
}