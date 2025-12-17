using AutoSpot.Application.Models.Base;

namespace AutoSpot.Application.Models.CarLot;

public record class CreateCarLotModel (
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
    Guid SellerId): ICreateModel;