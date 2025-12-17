using AutoSpot.Application.Models.Base;
using AutoSpot.Application.Models.CarLot;

namespace AutoSpot.Application.Models.Customer;

public record class CustomerModel(Guid Id, string Username) : UserModel(Id, Username)
{
    public IEnumerable<CarLotModel> ObservedCarLots { get; init; }
}