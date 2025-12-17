using AutoSpot.Application.Models.CarLot;

namespace AutoSpot.Application.Services.Abstractions;

public interface ICarLotApplicationService
{
    Task<CarLotModel?> GetCarLotByIdAsync(Guid id, CancellationToken cancellationToken);
    
    Task<IEnumerable<CarLotModel>> GetCarLotsAsync(CancellationToken cancellationToken );
    
    //Task<bool> CancelCarLotAsync(Guid id, Guid sellerId, CancellationToken cancellationToken = default);
    
    Task<IEnumerable<CarLotModel>> GetCarLotsByEndDateAsync(DateTime endDateUtc, CancellationToken cancellationToken);

    Task<CarLotModel?> CreateCarLotAsync(CreateCarLotModel carLotInformation, CancellationToken cancellationToken);

    Task<bool> UpdateCarLotAsync(CarLotModel carLot, CancellationToken cancellationToken);

    Task<bool> DeleteCarLotAsync(Guid id, CancellationToken cancellationToken);
}