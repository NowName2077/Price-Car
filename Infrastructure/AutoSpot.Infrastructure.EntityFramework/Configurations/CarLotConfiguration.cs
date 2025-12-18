using AutoSpot.Domain.Entities;
using AutoSpot.Domain.Enums;
using AutoSpot.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutoSpot.Infrastructure.EntityFramework.Configurations;

public class CarLotConfiguration : IEntityTypeConfiguration<CarLot>
{
    public void Configure(EntityTypeBuilder<CarLot> builder)
    {
        // Основной ключ
        builder.HasKey(cl => cl.Id);
        builder.Property(cl => cl.Id).IsRequired();

        // Свойство Title
        builder.Property(cl => cl.Title)
            .IsRequired()
            .HasConversion(
                title => title!.Value, 
                value => new Title(value))
            .HasMaxLength(50);

        // Цвет автомобиля
        builder.Property(cl => cl.Color)
            .IsRequired()
            .HasConversion(
                color => color!.Value, 
                value => new Color(value))
            .HasMaxLength(50);
        
        // Цена
        builder.Property(cl => cl.Price)
            .IsRequired()
            .HasConversion(
                price => price!.Value, 
                value => new Money(value));

        // Объем двигателя
        builder.Property(cl => cl.EngineVolume)
            .IsRequired()
            .HasConversion(
                ev => ev!.Value, 
                value => new EngineVolume(value));

        // Лошадиные силы двигателя
        builder.Property(cl => cl.Horsepower)
            .IsRequired()
            .HasConversion(
                hp => hp!.Value, 
                value => new Horsepower(value));

        // Крутящий момент
        builder.Property(cl => cl.Torque)
            .IsRequired()
            .HasConversion(
                torque => torque!.Value, 
                value => new Torque(value));

        // Тип топлива
        builder.Property(cl => cl.FuelType)
            .IsRequired()
            .HasConversion(
                ft => ft.ToString(), 
                value => Enum.Parse<FuelType>(value));

        // Надув двигателя (Aspiration)
        builder.Property(cl => cl.Aspiration)
            .IsRequired()
            .HasConversion(
                aspiration => aspiration.ToString(),
                value => Enum.Parse<Aspiration>(value));

        // Конфигурация двигателя
        builder.Property(cl => cl.EngineConfiguration)
            .IsRequired()
            .HasConversion(
                ec => ec.ToString(),
                value => Enum.Parse<EngineConfiguration>(value));

        // Тип привода
        builder.Property(cl => cl.TypeOfDrive)
            .IsRequired()
            .HasConversion(
                tod => tod.ToString(),
                value => Enum.Parse<TypeOfDrive>(value));

        // Тип трансмиссии
        builder.Property(cl => cl.TransmissionType)
            .IsRequired()
            .HasConversion(
                tt => tt.ToString(),
                value => Enum.Parse<TransmissionType>(value));

        // Тип кузова
        builder.Property(cl => cl.BodyType)
            .IsRequired()
            .HasConversion(
                bt => bt.ToString(),
                value => Enum.Parse<BodyType>(value));

        // Дата начала аукционного лота
        builder.Property(cl => cl.StartDate)
            .IsRequired()
            .HasConversion(
                date => DateTime.SpecifyKind(date, DateTimeKind.Utc),
                date => DateTime.SpecifyKind(date, DateTimeKind.Utc));

        // Статус лота
        builder.Property(cl => cl.Status)
            .IsRequired()
            .HasConversion(
                status => status.ToString(),
                value => Enum.Parse<LotStatus>(value));

        // Связи с продавцом и покупателем
        builder.HasOne(cl => cl.Seller)
            .WithMany(s => s.ActiveCarLots)
            .HasForeignKey("SellerId")
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(cl => cl.Buyer)
            .WithMany()
            .HasForeignKey("BuyerId")
            .OnDelete(DeleteBehavior.Restrict);
    }
}