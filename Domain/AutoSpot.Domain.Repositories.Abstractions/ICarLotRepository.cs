using AutoSpot.Domain.Entities;
using AutoSpot.Domain.Repositories.Abstractions.Base;

namespace AutoSpot.Domain.Repositories.Abstractions;

public interface ICarLotRepository : IRepository<CarLot, Guid>
{
    Task<IEnumerable<CarLot>> GetAllByEndDateAsync(
        DateTime endDateUtc,
        CancellationToken cancellationToken,
        bool asNoTracking = false);
}