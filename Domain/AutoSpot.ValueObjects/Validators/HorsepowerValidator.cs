using AutoSpot.ValueObjects.Base;

namespace AutoSpot.ValueObjects.Validators;

public class HorsepowerValidator: IValidator<int>
{
    public void Validate(int value)
    {
        if (value <= 0) 
            throw new ArgumentOutOfRangeException(nameof(value), "Horsepower must be positive.");
    }
}