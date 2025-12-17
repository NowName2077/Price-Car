using AutoSpot.ValueObjects.Base;
using AutoSpot.ValueObjects.Exceptions;

namespace AutoSpot.ValueObjects.Validators;

public class TitleValidator : IValidator<string>
{
    public static int MAX_LENGTH => 50;
    
    public void Validate(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentNullOrWhiteSpaceException(nameof(value));

        if (value.Length > MAX_LENGTH)
            throw new ArgumentLongValueException(nameof(value), value, MAX_LENGTH);
    }
}