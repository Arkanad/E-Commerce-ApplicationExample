using Microsoft.AspNetCore.Mvc;
using E_Commerce_application.Models;

namespace E_Commerce_application.Controllers
{
    public class HomeController : Controller
    {
        [Route("/order")]
        public IActionResult Index([FromForm]Order order)
        {
            if (Request.Method == "POST")
            {
                order.OrderNumber = new Random().Next(1, 10000);
                if (!ModelState.IsValid)
                {
                //foreach (var value in ModelState.Values)
                //{
                //    foreach (var error in value.Errors)
                //    {
                //        errorList.Add(error.ErrorMessage);
                //    }
                //}

                     string errors = string.Join("\n", ModelState.Values.SelectMany( /*object of collection*/value => /* by */ value.Errors)
                       .Select(err => err.ErrorMessage));
                     return BadRequest(errors);
                }
                return Content($"Order number:{order.OrderNumber.ToString()}");
            }
            return Content(order.ToString());
        }
    }   
}
