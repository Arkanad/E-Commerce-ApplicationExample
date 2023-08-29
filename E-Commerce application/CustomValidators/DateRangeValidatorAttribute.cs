using System.ComponentModel.DataAnnotations;

namespace E_Commerce_application.CustomValidators
{
    public class DateRangeValidatorAttribute : ValidationAttribute
    {
        public string DefaultErrorMessage { get; set; } = "IOrderDate can't be blank";
        public DateTime MinimumDate { get; set; }

        public DateRangeValidatorAttribute()
        {

        }

        public DateRangeValidatorAttribute(string minimumDate)
        {
            MinimumDate = Convert.ToDateTime(minimumDate);
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value != null)
            {

                DateTime currentDate =
                    Convert.ToDateTime(value);
                if (currentDate < Convert.ToDateTime(MinimumDate))
                {
                    return new ValidationResult(string.Format(ErrorMessage ?? DefaultErrorMessage, MinimumDate.ToString("yyyy-MM-dd")), new string[] { nameof(validationContext.MemberName) });
                }
                return ValidationResult.Success;
            }

            return null;
        }
    }
}

