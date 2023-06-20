using System.ComponentModel.DataAnnotations;

namespace YogaManagement.Client.ValidationAttributes;
public class StringMatchAttribute : ValidationAttribute
{
    private readonly string _comparisonProperty;

    public StringMatchAttribute(string comparisonProperty)
    {
        _comparisonProperty = comparisonProperty;
    }

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        ErrorMessage = ErrorMessageString;
        var currentValue = (string)value;

        var property = validationContext.ObjectType.GetProperty(_comparisonProperty);

        if (property == null)
            throw new ArgumentException("Property with this name not found");

        var comparisonValue = (string)property.GetValue(validationContext.ObjectInstance);

        if (currentValue != comparisonValue)
            return new ValidationResult(ErrorMessage);

        return ValidationResult.Success;
    }
}
