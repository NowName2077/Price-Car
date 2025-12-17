using AutoSpot.Domain.Base;
using AutoSpot.Domain.Enums;
using AutoSpot.Domain.Exceptions;
using AutoSpot.ValueObjects;

namespace AutoSpot.Domain.Entities;

public class Customer(Guid id, Username username) : Entity<Guid>(id)
    {
        private readonly ICollection<CarLot> _observableCarLots = new List<CarLot>(); 
        
        public Username Username { get; private set; } = username ?? throw new ArgumentNullValueException(nameof(username));
        
        public IReadOnlyCollection<CarLot> ObservableCarLots =>
            _observableCarLots.Where(lot => lot.IsActive).ToList().AsReadOnly();
        
        internal bool ChangeUsername(Username newUsername)
        {
            if (Username == newUsername) return false;
            Username = newUsername;
            return true;
        }
        
        public void AddObservableLot(CarLot lot)
        {
            if (_observableCarLots.Contains(lot))
                return;
            _observableCarLots.Add(lot);
        }
        
        public bool BuyCarLot(CarLot carLot)
        {
            if (!carLot.IsActive)
                throw new InvalidOperationException("The lot is not available for purchase.");

            return carLot.Complete(this);
        }
    }