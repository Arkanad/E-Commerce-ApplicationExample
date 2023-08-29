using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using E_Commerce_application.Models;

namespace E_Commerce_application.CustomValidators
{
    public class InvoicePriceValidator : ValidationAttribute
    {
        public string DefaultErrorMessage { get; set; } = "Invoice Price should be equal to the total cost of all products (i.e. {0}) in the order.";
        public InvoicePriceValidator()
        {

        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value != null)
            {
                PropertyInfo? OtherProperty = validationContext.ObjectType.GetProperty(nameof(Order.Products));

                if (OtherProperty != null)
                {
                    List<Product> products = (List<Product>)OtherProperty.GetValue(validationContext.ObjectInstance);

                    double totalPrice = 0;
                    foreach (Product product in products)
                    {
                        totalPrice += (product.Price * product.Quantity);
                    }

                    double actualPriceValue = (double)value;


                    if (totalPrice > 0){
                        if (totalPrice != actualPriceValue)
                        {
                            return new ValidationResult(string.Format(ErrorMessage ?? DefaultErrorMessage, totalPrice),
                                new string[] { nameof(validationContext.MemberName) });
                        }
                    }
                    else
                    {
                        return new ValidationResult("No product with that invoice price was found!",
                            new String[] { validationContext.MemberName });
                    }
                    return ValidationResult.Success;
                }
                return null;
            }
            return null;
        }
    }
}
