using AutoSpot.Domain.Base;
using AutoSpot.Domain.Enums;
using AutoSpot.Domain.Exceptions;
using AutoSpot.ValueObjects;

namespace AutoSpot.Domain.Entities;

public class CarLot : Entity<Guid>
{

    public Title Title { get; }

    #region Engine

    public EngineVolume EngineVolume { get; }
    public Horsepower Horsepower { get; }
    public Torque Torque { get; }
    public FuelType FuelType { get; }
    public Aspiration Aspiration { get; }
    public EngineConfiguration EngineConfiguration { get; }

    #endregion //Engine

    #region Transmission

    public TransmissionType TransmissionType { get; }
    public TypeOfDrive TypeOfDrive { get; }

    #endregion //Transmission

    #region Body

    public BodyType BodyType { get; }
    public Color Color { get; }

    #endregion //Body

    public Money Price { get; }
    
    public DateTime StartDate { get; }

    public LotStatus Status { get; private set; }

    public Seller Seller { get; }
    public Customer? Buyer { get; private set; }
    
    public bool IsActive => Status == LotStatus.Active;
    
    public bool IsCompleted => Status == LotStatus.Completed;

    protected CarLot() { }

    public CarLot(
        Title title,
        EngineVolume engineVolume,
        Horsepower horsepower,
        Torque torque,
        FuelType fuelType,
        Aspiration aspiration,
        EngineConfiguration engineConfiguration,
        TypeOfDrive typeOfDrive,
        TransmissionType transmissionType,
        BodyType bodyType,
        Color color,
        Money price,
        DateTime startDate,
        Seller seller) 
        : this(Guid.NewGuid(), title, engineVolume, horsepower, torque, fuelType, aspiration,
            engineConfiguration, typeOfDrive, transmissionType, bodyType, color, price, startDate, LotStatus.Active, seller) { }


    protected CarLot(
        Guid id,
        Title title,
        EngineVolume engineVolume,
        Horsepower horsepower,
        Torque torque,
        FuelType fuelType,
        Aspiration aspiration,
        EngineConfiguration engineConfiguration,
        TypeOfDrive typeOfDrive,
        TransmissionType transmissionType,
        BodyType bodyType,
        Color color,
        Money price,
        DateTime startDate,
        LotStatus status,
        Seller seller) : base(id)
    {
        Title = title ?? throw new ArgumentNullException(nameof(title));
        EngineVolume = engineVolume;
        Horsepower = horsepower;
        Torque = torque;
        FuelType = fuelType;
        Aspiration = aspiration;
        EngineConfiguration = engineConfiguration;
        TypeOfDrive = typeOfDrive;
        TransmissionType = transmissionType;
        BodyType = bodyType;
        Color = color ?? throw new ArgumentNullException(nameof(color));
        Price = price ?? throw new ArgumentNullException(nameof(price));
        StartDate = startDate;
        Status = status;
        Seller = seller ?? throw new ArgumentNullException(nameof(seller));
    }
    
    public bool SetCancel(Seller seller)
    {
        if (Seller != seller)
            throw new AnotherSellerCancelLotException(this, seller);

        if (!IsActive)
            throw new CancelNotActiveCarLotException(this);

        Status = LotStatus.Canceled;
        return true;
    }
    
    
    public bool Complete(Customer buyer)
    {
        if (!IsActive)
            throw new CompletedNotActiveCarLotException(this);

        Buyer = buyer ?? throw new ArgumentNullValueException(nameof(buyer));
        Status = LotStatus.Completed;
        return true;
    }

    
}