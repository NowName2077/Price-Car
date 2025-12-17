namespace AutoSpot.ValueObjects.Validators;

public class EngineVolumeValidator: AbstractValidator<decimal>
{
    public EngineVolumeValidator()
    {
        RuleFor(volume => volume)
            .GreaterThan(0).WithMessage("Engine volume must be positive")
            .LessThanOrEqualTo(20).WithMessage("Engine volume cannot exceed 20 liters");
    }
}