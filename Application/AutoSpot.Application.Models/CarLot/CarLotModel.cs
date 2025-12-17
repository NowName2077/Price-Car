using AutoSpot.Application.Models.Base;

namespace AutoSpot.Application.Models.CarLot;

public record class CarLotModel(
    Guid Id,
    string Title,
    decimal EngineVolume,
    int Horsepower,
    int Torque,
    string FuelType,
    string Aspiration,
    string EngineConfiguration,
    string TransmissionType,
    string TypeOfDrive,
    string BodyType,
    string Color,
    decimal Price,
    DateTime StartDate,
    string Status,
    Guid SellerId,
    Guid? BuyerId): IModel<Guid>;