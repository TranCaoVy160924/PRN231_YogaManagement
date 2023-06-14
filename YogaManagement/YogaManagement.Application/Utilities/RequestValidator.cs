using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace YogaManagement.Application.Utilities;

public static class RequestValidator
{
    public static void ValidateRequest(this ModelStateDictionary modelState)
    {
        if (!modelState.IsValid)
        {
            var errorMessages = modelState.Values
            .SelectMany(v => v.Errors)
            .Select(e => e.ErrorMessage)
            .ToList();

            throw new Exception($"Invalid input format. Errors: {string.Join(", ", errorMessages)}");
        }

    }
}
