using System.ComponentModel.DataAnnotations;
using AutoMapper;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

public class CrmDbContext : DbContext
{
    public CrmDbContext(DbContextOptions<CrmDbContext> options) : base(options)
    {
    }
    public DbSet<Customer> Customers { get; set; }
}
public class Customer
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
}
public interface ICustomerService
{
    IEnumerable<Customer> GetAllCustomers();
    Customer? GetCustomerById(int id);
    Customer CreateCustomer(CreateCustomerDTO createCustomerDTO);
}
public class CustomerService : ICustomerService
{
    private readonly CrmDbContext dbContext;

    public CustomerService(CrmDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public IEnumerable<Customer> GetAllCustomers()
    {
        return dbContext.Customers.ToList();
    }

    public Customer? GetCustomerById(int id)
    {
        return dbContext.Customers.FirstOrDefault(c => c.Id == id);
    }

    public Customer CreateCustomer(CreateCustomerDTO createCustomerDTO)
    {
        var customer = new Customer
        {
            Name = createCustomerDTO.Name,
            Email = createCustomerDTO.Email
        };

        dbContext.Customers.Add(customer);
        dbContext.SaveChanges();

        return customer;
    }
}

public class CustomerDTO
{
    public string? FullName { get; set; }
}

// Model for Crate Customer
public class CreateCustomerDTO
{
    // [Required]
    // [StringLength(100)]
    // [MinLength(2)]
    // [MaxLength(100)]
    // [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Name can only contain letters and spaces.")]
    public string? Name { get; set; }
    public string? Email { get; set; }

    public int Age { get; set; }
}

public class CustomerProfile : Profile
{
    public CustomerProfile()
    {
        CreateMap<Customer, CustomerDTO>()
            .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.Name));

        CreateMap<CreateCustomerDTO, Customer>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email));
    }
}