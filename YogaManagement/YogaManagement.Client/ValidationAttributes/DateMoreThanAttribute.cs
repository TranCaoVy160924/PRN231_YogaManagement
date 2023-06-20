using System.ComponentModel.DataAnnotations;

namespace YogaManagement.Client.ValidationAttributes;

public class DateMoreThanAttribute : ValidationAttribute
{
    private readonly string _comparisonProperty;

    public DateMoreThanAttribute(string comparisonProperty)
    {
        _comparisonProperty = comparisonProperty;
    }

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        ErrorMessage = ErrorMessageString;
        var currentValue = (DateTimeOffset)value;

        var property = validationContext.ObjectType.GetProperty(_comparisonProperty);

        if (property == null)
            throw new ArgumentException("Property with this name not found");

        var comparisonValue = (DateTimeOffset)property.GetValue(validationContext.ObjectInstance);

        if (currentValue < comparisonValue)
            return new ValidationResult(ErrorMessage);

        return ValidationResult.Success;
    }
}
