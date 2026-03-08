using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

var builder = WebApplication.CreateBuilder(args);

// add appsettings.json
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

builder.Services.AddControllers();

// register DbContext and CustomerService
builder.Services.AddScoped<CrmDbContext>();
builder.Services.AddScoped<ICustomerService, CustomerService>();

// Add Sql Server
builder.Services.AddDbContext<CrmDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("CrmDbConnection")));

var app = builder.Build();

// Apply migrations and seed data
try
{
    using (var scope = app.Services.CreateScope())
    {
        var dbContext = scope.ServiceProvider.GetRequiredService<CrmDbContext>();
        dbContext.Database.Migrate();

        // Seed sample data
        if (!dbContext.Customers.Any())
        {
            dbContext.Customers.AddRange(
                new Customer { Name = "Harshali", Email = "harshali@example.com" },
                new Customer { Name = "Ankita", Email = "ankita@example.com" }
            );
            dbContext.SaveChanges();
        }
    }
}
catch (Exception ex)
{
    Console.WriteLine($"Database migration failed: {ex.Message}");
    Console.WriteLine("Continuing without database...");
}

app.UseRouting();

app.MapControllers();

app.Run();