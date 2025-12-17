using AutoSpot.Domain.Entities;

namespace AutoSpot.Domain.Exceptions
{
    public class CompletedNotActiveCarLotException(CarLot lot)
        : InvalidOperationException($"Can't completed an inactive lot {lot.Title} (id = {lot.Id}).")
    {
        public CarLot Lot => lot;
    }
}
