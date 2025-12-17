using AutoSpot.Domain.Entities;

namespace AutoSpot.Domain.Exceptions
{
    public class CancelNotActiveCarLotException(CarLot lot)
        : InvalidOperationException($"Can't cancel an inactive lot {lot.Title} (id = {lot.Id}).")
    {
        public CarLot Lot => lot;
    }
}
