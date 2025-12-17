using AutoSpot.Domain.Entities;

namespace AutoSpot.Domain.Exceptions
{
    public class CarLotDoesNotBelongToSellerException(Seller seller, CarLot lot)
        : InvalidOperationException($"The auction lot {lot.Title} is not in the seller's lot sequence (seller {seller.Username}, lot id = {lot.Id}).")
    {
        public Seller Seller => seller;
        public CarLot Lot => lot;
    }
}
