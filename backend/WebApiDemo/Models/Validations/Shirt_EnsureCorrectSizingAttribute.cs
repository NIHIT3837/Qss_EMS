using System.ComponentModel.DataAnnotations;

namespace WebApiDemo.Models.Validations
{
    public class Shirt_EnsureCorrectSizingAttribute:ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var shirt=validationContext.ObjectInstance as Shirt;

            if (shirt != null && !string.IsNullOrWhiteSpace(shirt.Gender))
            {
                if(shirt.Gender.Equals("men",StringComparison.OrdinalIgnoreCase) && shirt.Size < 8)
                {
                    return new ValidationResult("FOR MEN SHIRT SIZE SHOULD BE GREATER THAN 8");
                }
                else if(shirt.Gender.Equals("Women", StringComparison.OrdinalIgnoreCase) && shirt.Size < 6)
                {
                    return new ValidationResult("FOR WOMEN SHIRT SIZE SHOULD BE GREATER THAN 6");

                }
            }

            return ValidationResult.Success;
        }
    }
}
