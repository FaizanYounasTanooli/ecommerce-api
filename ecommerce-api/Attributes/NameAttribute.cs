using System.ComponentModel.DataAnnotations;

namespace ecommerce_api.Attributes
{
    public class NameAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var propertyValue = value as string;

            // Create instances of MinLength, MaxLength, and Required attributes
            var requiredAttribute = new RequiredAttribute();
            var minLengthAttribute = new MinLengthAttribute(1);
            var maxLengthAttribute = new MaxLengthAttribute(100);

            // Validate Required
            var requiredResult = requiredAttribute.GetValidationResult(propertyValue, validationContext);
            if (requiredResult != ValidationResult.Success)
            {
                return requiredResult;
            }

            // Validate MinLength
            var minLengthResult = minLengthAttribute.GetValidationResult(propertyValue, validationContext);
            if (minLengthResult != ValidationResult.Success)
            {
                return minLengthResult;
            }

            // Validate MaxLength
            var maxLengthResult = maxLengthAttribute.GetValidationResult(propertyValue, validationContext);
            if (maxLengthResult != ValidationResult.Success)
            {
                return maxLengthResult;
            }

            return ValidationResult.Success;
        }
    }
}
