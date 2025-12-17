using AutoSpot.Domain.Entities;
using AutoSpot.Domain.Repositories.Abstractions.Base;

namespace AutoSpot.Domain.Repositories.Abstractions;

public interface ISellersRepository: IRepository<Seller, Guid>
{
    Task<Seller?> GetSellerByUsernameAsync(string username, CancellationToken cancellationToken);
}