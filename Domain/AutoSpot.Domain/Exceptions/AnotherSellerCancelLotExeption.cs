using AutoSpot.Domain.Entities;

namespace AutoSpot.Domain.Exceptions
{
    public class AnotherSellerCancelLotException(CarLot auctionLot, Seller seller)
        : InvalidOperationException($"The seller {seller.Username} can't cancel the {auctionLot.Title} auction lot owned by the seller  {auctionLot.Seller.Username} (lot id = {auctionLot.Id}).")
    {
        public CarLot AuctionLot => auctionLot;
        public Seller Seller => seller;
    }
}
