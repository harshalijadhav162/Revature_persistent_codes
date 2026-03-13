using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/v1/[controller]")]
public class CustomerController : ControllerBase
{
    private readonly AppDbContext dbContext;

    public CustomerController(AppDbContext context)
    {
        dbContext = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAsync()
    {
        var customers = await dbContext.Customers.ToListAsync();
        return Ok(customers);
    }
}