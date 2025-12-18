using Microsoft.EntityFrameworkCore;
using AutoSpot.Domain.Entities;
using AutoSpot.Domain.Repositories.Abstractions;

namespace AutoSpot.Infrastructure.EntityFramework.RepositoriesEF;

public class CustomerRepository(ApplicationDbContext context) : EFRepository<Customer, Guid>(context), ICustomersRepository
{
    private readonly DbSet<Customer> _customers = context.Set<Customer>();
    

    public override Task<Customer?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        => _customers.Include(c => c.ObservableCarLots)
            .FirstOrDefaultAsync(c => c.Id == id, cancellationToken);

    public Task<Customer?> GetCustomerByUsernameAsync(string username, CancellationToken cancellationToken)
        => _customers.Include(c => c.ObservableCarLots)
            .FirstOrDefaultAsync(c => c.Username.Value == username, cancellationToken);
}