using System.ComponentModel.DataAnnotations;

namespace E_Commerce_application.CustomValidators
{
    public class MinimumValueValidator : ValidationAttribute
    {
        public string TitleForValue { get; set; }
        public int MinimumValue { get; set; }
        public MinimumValueValidator()
        {

        }

        public MinimumValueValidator(int minimumValue, string titleValue)
        {
            MinimumValue = minimumValue;
            TitleForValue = titleValue;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value != null)
            {
                if (Convert.ToInt32(value) <= 0)
                {
                    return new ValidationResult($"minimum {TitleForValue} should be between valid number");
                   
                }
                return ValidationResult.Success;
            }
            return new ValidationResult($"minimum {TitleForValue} should be between valid number");
        }
    }
}
