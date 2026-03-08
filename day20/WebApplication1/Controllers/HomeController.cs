using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public HomeController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet("/")]
        public IActionResult Get()
        {
            try
            {
                var customers = _customerService.GetAllCustomers();
                return Ok(customers);
            }
            catch (Exception ex)
            {
                return Ok(new[] { new { message = "Database not available", error = ex.Message } });
            }
        }

        [HttpGet("api/home")]
        public IActionResult GetFromApi()
        {
            try
            {
                var customers = _customerService.GetAllCustomers();
                return Ok(customers);
            }
            catch (Exception ex)
            {
                return Ok(new[] { new { message = "Database not available", error = ex.Message } });
            }
        }
    }
}