using AutoSpot.Application.Models.CarLot;
using AutoSpot.Application.Models.Customer;
using AutoSpot.Application.Models.Seller;
using AutoSpot.Domain.Entities;
using AutoSpot.ValueObjects;

namespace AutoSpot.Application.Services.Mapping;
using AutoMapper;
public class ApplicationProfile: Profile
{
    public ApplicationProfile()
    {
        CreateMap<Money, decimal>().ConvertUsing(x => x.Value);
        CreateMap<CarLot, CarLotModel>()
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title.Value))
            .ForMember(dest => dest.Color, opt => opt.MapFrom(src => src.Color.Value))
            .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price.Value))
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()))
            .ForMember(dest => dest.SellerId, opt => opt.MapFrom(src => src.Seller.Id))
            .ForMember(dest => dest.BuyerId, opt => opt.MapFrom(src => src.Buyer != null ? src.Buyer.Id : (Guid?)null));

        CreateMap<Seller, SellerModel>()
            .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.Username.Value))
            .ForMember(dest => dest.ActiveCarLots, opt => opt.MapFrom(src => src.ActiveCarLots));

        CreateMap<Customer, CustomerModel>()
            .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.Username.Value))
            .ForMember(dest => dest.ObservedCarLots, opt => opt.MapFrom(src => src.ObservableCarLots));
    }
}
