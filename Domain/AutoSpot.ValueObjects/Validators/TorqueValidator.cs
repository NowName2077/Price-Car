using AutoSpot.ValueObjects.Base;

namespace AutoSpot.ValueObjects.Validators;

public class TorqueValidator : IValidator<int>
{
    public void Validate(int value)
    {
        if (value <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(value), "Torque must be positive.");
        }
    }
}