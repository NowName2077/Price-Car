using AutoSpot.Application.Models.Base;
using AutoSpot.Application.Models.CarLot;

namespace AutoSpot.Application.Models.Seller;

public record class SellerModel(Guid Id, string Username) : UserModel(Id, Username) 
{
    public IEnumerable<CarLotModel> ActiveCarLots { get; init; }
}