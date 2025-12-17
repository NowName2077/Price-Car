using AutoSpot.Application.Models.Base;

namespace AutoSpot.Application.Models.Customer;

public record class CreateCustomerModel(Guid Id, string Username)
    : UserCreateModel(Id, Username);