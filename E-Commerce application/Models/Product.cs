using System.ComponentModel.DataAnnotations;
using E_Commerce_application.CustomValidators;

namespace E_Commerce_application.Models
{
    public class Product
    {
        [Required(ErrorMessage = ("Product code can`t be empty"))]
        [MinimumValueValidator(0,"Product code")]
        public int ProductCode { get; set; }

        [Required(ErrorMessage = "ErrorMessage = Product price can`t be empty")]
        [MinimumValueValidator(0,"Price")]
        public double Price { get; set; }

        [Required(ErrorMessage = "Products quantity can`t be empty")]
        [Range(1,20,ErrorMessage = "Products quantity should be between valid number")]
        public int Quantity { get; set; }
    }
}
