using AutoSpot.Domain.Base;
using AutoSpot.Domain.Exceptions;
using AutoSpot.ValueObjects;

namespace AutoSpot.Domain.Entities;

public class Seller(Guid id, Username username) : Entity<Guid>(id)
{
    private readonly ICollection<CarLot> _carLots = [];
    
    public Username Username { get; private set; } = username ?? throw new ArgumentNullValueException(nameof(username));
    
    public IReadOnlyCollection<CarLot> ActiveCarLots =>
        _carLots.Where(lot => lot.IsActive).ToList().AsReadOnly();
    
    internal bool ChangeUsername(Username newUsername)
    {
        if (Username == newUsername) return false;
        Username = newUsername;
        return true;
    }
    
    public bool CancelLot(CarLot lot)
    {
        var ownedLot = _carLots.FirstOrDefault(l => l == lot)
                       ?? throw new CarLotDoesNotBelongToSellerException(this, lot);

        return ownedLot.SetCancel(this);
    }
}