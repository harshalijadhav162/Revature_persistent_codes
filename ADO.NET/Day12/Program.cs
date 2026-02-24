using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.Extensions.Configuration;


Console.WriteLine("Program Started...");

using var context = new CrmContext();

if (!context.Customers.Any())
{
    var customer = new Customer
    {
        CustomerName = "Test Customer",
        Email = "test@gmail.com",
        Phone = "9012345678",
        SegmentId = 1,
        IsDeleted = false
    };

    context.Customers.Add(customer);
    context.SaveChanges();

    Console.WriteLine("Customer inserted.");
}

if (!context.Orders.Any())
{
    var order1 = new Order
    {
        Product = "Laptop",
        Price = 50000,
        CustomerId = 1
    };

    var order2 = new Order
    {
        Product = "Mobile",
        Price = 20000,
        CustomerId = 1
    };

    context.Orders.AddRange(order1, order2);
    context.SaveChanges();

    Console.WriteLine("Orders inserted successfully!");
}
//fetching
var customers = context.Customers
                       .Include(c => c.Orders)
                       .ToList();
//printing
foreach (var customer in customers)
{
    Console.WriteLine($"Id: {customer.CustomerId}, Name: {customer.CustomerName}, Email: {customer.Email}");

    foreach (var order in customer.Orders)
    {
        Console.WriteLine($"   OrderId: {order.OrderId}, Product: {order.Product}, Price: {order.Price}");
    }
}

Console.WriteLine("Program Finished.");


//dbcontext--inheriting from dbcontext
class CrmContext : DbContext
{
    public DbSet<Customer> Customers { get; set; }
   public DbSet<Customer> Customers { get; set; }
public DbSet<Segment> Segments { get; set; }
public DbSet<ContactPerson> ContactPersons { get; set; }
public DbSet<CustomerAddress> CustomerAddresses { get; set; }
public DbSet<CustomerInteraction> CustomerInteractions { get; set; }
public DbSet<CustomerAudit> CustomerAudits { get; set; }

   protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
{
    if (!optionsBuilder.IsConfigured)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        var connectionString = configuration.GetConnectionString("DefaultConnection");

        optionsBuilder.UseSqlServer(connectionString);
    }
}


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
       
        modelBuilder.Entity<Customer>().ToTable("Customer");

                    .HasQueryFilter(c => !c.IsDeleted);

        
        modelBuilder.Entity<Order>()
            .HasOne(o => o.Customer)
            .WithMany(c => c.Orders)
            .HasForeignKey(o => o.CustomerId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}


class Customer
{
    public int CustomerId { get; set; }

    public string? CustomerName { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public int? SegmentId { get; set; }

    public bool IsDeleted { get; set; } = false;

    public ICollection<Order> Orders { get; set; } = new List<Order>();
}


class Order
{
    public int OrderId { get; set; }

    public string? Product { get; set; }

    public decimal Price { get; set; }

    public int CustomerId { get; set; }

    public Customer? Customer { get; set; }
}
