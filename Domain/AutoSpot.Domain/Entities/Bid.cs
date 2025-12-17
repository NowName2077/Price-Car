using AutoSpot.Domain.Base;
using AutoSpot.ValueObjects;

namespace AutoSpot.Domain.Entities;

public class Bid : Entity<Guid>
{
    public DateTime CreationTime { get; }
    
    public Money Amount { get; }
    
    public CarLot CarLot { get; }
    
    public Customer Customer { get; }
}