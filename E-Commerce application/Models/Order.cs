using System.ComponentModel.DataAnnotations;
using E_Commerce_application.CustomValidators;


namespace E_Commerce_application.Models
{
    public class Order
    {
        public int? OrderNumber { get; set; }

        [Required(ErrorMessage = "Must be entered")]
        [DateRangeValidator("2020/01/01T00:00:00")]        
        public DateTime OrderDate { get; set; }

        [Required(ErrorMessage = "Price should be between a valid number")]
        [InvoicePriceValidator]
        public double InvoicePrice { get; set; }

        [Required(ErrorMessage = "Product quantity should be between a valid number")]
        public List<Product> Products { get; set; }

        public override string ToString()
        {
            return $"{OrderNumber} by {OrderDate}\n Price:{InvoicePrice}";
        }
    }
}
