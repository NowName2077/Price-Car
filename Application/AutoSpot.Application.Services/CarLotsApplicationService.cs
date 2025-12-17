using AutoMapper;
using AutoSpot.Application.Models.CarLot;
using AutoSpot.Application.Services.Abstractions;
using AutoSpot.Domain.Entities;
using AutoSpot.Domain.Repositories.Abstractions;
using AutoSpot.ValueObjects;

namespace AutoSpot.Application.Services;

public class CarLotsApplicationService(ICarLotRepository lotRepository, ISellersRepository sellersRepository,IMapper mapper): ICarLotApplicationService
{
    public async Task<IEnumerable<CarLotModel>> GetCarLotsAsync(CancellationToken cancellationToken = default)
        => (await lotRepository.GetAllAsync(cancellationToken, true)).Where(l => l.IsActive).Select(mapper.Map<CarLotModel>);
        
    public async Task<IEnumerable<CarLotModel>> GetCarLotsByEndDateAsync(DateTime endDateUtc, CancellationToken cancellationToken = default)
        => (await lotRepository.GetAllByEndDateAsync(endDateUtc, cancellationToken, true)).Select(mapper.Map<CarLotModel>);
    
    public async Task<CarLotModel?> GetCarLotByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var carLot = await lotRepository.GetByIdAsync(id, cancellationToken);
        return carLot is null ? null : mapper.Map<CarLotModel>(carLot);
    }

    public async Task<CarLotModel?> CreateCarLotAsync(CreateCarLotModel carLotInformation,
        CancellationToken cancellationToken = default)
    {
        var seller = await sellersRepository.GetByIdAsync(carLotInformation.SellerId, cancellationToken);
        if (seller is null)
            return null;

        if (await lotRepository.GetByIdAsync(carLotInformation.SellerId, cancellationToken) is not null)
            return null;

        CarLot carLot = new(
            new Title(carLotInformation.Title),
            new EngineVolume(carLotInformation.EngineVolume),
            new Horsepower(carLotInformation.Horsepower),
            new Torque(carLotInformation.Torque),
            Enum.Parse<FuelType>(carLotInformation.FuelType),
            Enum.Parse<Aspiration>(carLotInformation.Aspiration),
            Enum.Parse<EngineConfiguration>(carLotInformation.EngineConfiguration),
            Enum.Parse<TypeOfDrive>(carLotInformation.TypeOfDrive),
            Enum.Parse<TransmissionType>(carLotInformation.TransmissionType),
            Enum.Parse<BodyType>(carLotInformation.BodyType),
            new Color(carLotInformation.Color),
            new Money(carLotInformation.Price),
            carLotInformation.StartDate,
            seller
        );
        var cteatedLot = await lotRepository.AddAsync(carLot, cancellationToken);
        return cteatedLot is null ? null : mapper.Map<CarLotModel>(cteatedLot);
    }

    public async Task<bool> UpdateCarLotAsync(CarLotModel carLot, CancellationToken cancellationToken = default)
        {
            var entity = await lotRepository.GetByIdAsync(carLot.Id, cancellationToken);
            if (entity is null)
                return false;

            entity = mapper.Map<CarLot>(carLot);
            return await lotRepository.UpdateAsync(entity, cancellationToken);
        }
        

        public async Task<bool> DeleteCarLotAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var lot = await lotRepository.GetByIdAsync(id, cancellationToken);
            return lot is null ? false : await lotRepository.DeleteAsync(lot, cancellationToken);
        }
    }

