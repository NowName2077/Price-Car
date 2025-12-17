using AutoSpot.Domain.Entities;
using AutoSpot.Domain.Repositories.Abstractions.Base;

namespace AutoSpot.Domain.Repositories.Abstractions;

public interface ICustomersRepository : IRepository<Customer, Guid>
{
    Task<Customer?> GetCustomerByUsernameAsync(string username, CancellationToken cancellationToken);
}