using AutoSpot.ValueObjects.Base;

namespace AutoSpot.ValueObjects.Validators;

public class EngineVolumeValidator:  IValidator<decimal>
{
    public void Validate(decimal value)
    {
        if (value <= 0 || value > 20)
        {
            throw new ArgumentOutOfRangeException(nameof(value), "Engine volume must be between 0 and 20 liters.");
        }
    }
}