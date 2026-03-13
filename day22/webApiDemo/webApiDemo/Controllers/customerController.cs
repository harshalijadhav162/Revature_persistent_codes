using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;

[ApiController]
[Route("api/v1/[controller]")]
public class CustomerController : ControllerBase
{
    // In memory caching
    // IMemoryCache _cache;

    // Redis Caching
    IDistributedCache _cache;
    ICustomerService customerService;
    IMapper mapper;

    IValidator<CreateCustomerDTO> createCustomerDTOValidator;

    public CustomerController(ICustomerService customerService, IMapper mapper, IValidator<CreateCustomerDTO> createCustomerDTOValidator, IDistributedCache cache)
    {
        this.customerService = customerService;
        this.mapper = mapper;
        this.createCustomerDTOValidator = createCustomerDTOValidator;
        this._cache = cache;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var customers = customerService.GetAllCustomers();

        // DRY -
        // Violation of Single Responsibility
        // Remove Manual mapping and replace with Automapper
        // var customerDTOs = customers.Select(c => new CustomerDTO
        // {
        //     FullName = c.Name
        // }).ToList();
        // Refactoring -

        // AutoMapper
        var customerDTOs = mapper.Map<List<CustomerDTO>>(customers);

        return Ok(customerDTOs);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCustomerById(int id)
    {
        // Try to get the customer from cache
        var cachedCustomer = await _cache.GetStringAsync($"customer_{id}");
        if (cachedCustomer != null)
        {
            return Ok(cachedCustomer);
        }

        await Task.Delay(500); // Simulate a delay for database access

        var customer = customerService.GetCustomerById(id);
        if (customer == null)
        {
            return NotFound();
        }

        // Cache the customer data for future requests
        if (!string.IsNullOrEmpty(customer.Name))
        {
            await _cache.SetStringAsync($"customer_{id}", customer.Name, new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5)
            });
        }

        return Ok(customer);
    }


    [HttpPost]
    public IActionResult Post(CreateCustomerDTO createCustomerDTO)
    {
        var validationResult = createCustomerDTOValidator.Validate(createCustomerDTO);

        if (validationResult.IsValid == false)
        {
            return BadRequest(validationResult.Errors);
        }

        try
        {
            var customer = customerService.CreateCustomer(createCustomerDTO);
            var customerDTO = mapper.Map<CustomerDTO>(customer);
            return CreatedAtAction(nameof(GetCustomerById), new { id = customer.Id }, customerDTO);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Error creating customer", detail = ex.Message });
        }
    }
}