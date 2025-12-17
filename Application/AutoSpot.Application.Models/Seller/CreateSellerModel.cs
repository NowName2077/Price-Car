using AutoSpot.Application.Models.Base;

namespace AutoSpot.Application.Models.Seller;

public record class CreateSellerModel(Guid Id, string Username)
    : UserCreateModel(Id, Username);