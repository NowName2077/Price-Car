using Microsoft.EntityFrameworkCore;
using AutoSpot.Domain.Entities;
using AutoSpot.Domain.Repositories.Abstractions;

namespace AutoSpot.Infrastructure.EntityFramework.RepositoriesEF;

public class CarLotRepository(ApplicationDbContext context) : EFRepository<CarLot, Guid>(context), ICarLotRepository
{
    private readonly DbSet<CarLot> _carLots = context.Set<CarLot>();
    

    public override Task<CarLot?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        => _carLots.Include(c => c.Seller)
            .Include(c => c.Buyer)
            .FirstOrDefaultAsync(cl => cl.Id == id, cancellationToken);

    public Task<IEnumerable<CarLot>> GetAllByEndDateAsync(DateTime endDateUtc, CancellationToken cancellationToken, bool asNoTracking = false)
        => Task.FromResult(
            asNoTracking
                ? _carLots.AsNoTracking().Where(cl => cl.StartDate <= endDateUtc).AsEnumerable()
                : _carLots.Where(cl => cl.StartDate <= endDateUtc).AsEnumerable()
        );
}