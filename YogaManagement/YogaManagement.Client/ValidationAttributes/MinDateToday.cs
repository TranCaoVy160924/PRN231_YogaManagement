using System.ComponentModel.DataAnnotations;

namespace YogaManagement.Client.ValidationAttributes;

public class MinDateToday : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        ErrorMessage = ErrorMessageString;
        var currentValue = (DateTimeOffset)value;

        if (currentValue < (DateTimeOffset)DateTime.Today)
            return new ValidationResult(ErrorMessage);

        return ValidationResult.Success;
    }
}
