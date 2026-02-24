using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System;

using var context = new CrmContext();

context.Database.EnsureCreated();

Console.WriteLine("Database ready...");

// ------------------ SAMPLE INSERT ------------------

// 1️⃣ One-to-One
var customer = new Customer
{
    Name = "Harshali",
    Age = 23,
    Profile = new CustomerProfile
    {
        PAN = "ABCDE1234F"
    }
};

context.Customers.Add(customer);
context.SaveChanges();

// 2️⃣ One-to-Many
var order1 = new Order { Product = "Laptop", Price = 60000, CustomerId = customer.Id };
var order2 = new Order { Product = "Mobile", Price = 20000, CustomerId = customer.Id };

context.Orders.AddRange(order1, order2);
context.SaveChanges();

// 3️⃣ Many-to-Many
var student = new Student { Name = "Ravi" };
var course1 = new Course { Title = "Maths" };
var course2 = new Course { Title = "Science" };

student.Courses = new List<Course> { course1, course2 };

context.Students.Add(student);
context.SaveChanges();

Console.WriteLine("Data inserted successfully.");


// ------------------ DbContext ------------------

class CrmContext : DbContext
{
    public DbSet<Customer> Customers { get; set; }
    public DbSet<CustomerProfile> Profiles { get; set; }
    public DbSet<Order> Orders { get; set; }

    public DbSet<Student> Students { get; set; }
    public DbSet<Course> Courses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            "Server=localhost\\SQLEXPRESS;Database=CustomerManagementDB;Trusted_Connection=True;TrustServerCertificate=True");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // 1️⃣ One-to-One
        modelBuilder.Entity<Customer>()
            .HasOne(c => c.Profile)
            .WithOne(p => p.Customer)
            .HasForeignKey<CustomerProfile>(p => p.CustomerId);

        // 2️⃣ One-to-Many
        modelBuilder.Entity<Order>()
            .HasOne(o => o.Customer)
            .WithMany(c => c.Orders)
            .HasForeignKey(o => o.CustomerId);

        // 3️⃣ Many-to-Many (Auto Junction Table)
        modelBuilder.Entity<Student>()
            .HasMany(s => s.Courses)
            .WithMany(c => c.Students);
    }
}


// ------------------ MODELS ------------------

// ---------- One-to-One ----------
public class Customer
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }

    public CustomerProfile Profile { get; set; }
    public ICollection<Order> Orders { get; set; }
}

public class CustomerProfile
{
    public int Id { get; set; }
    public string PAN { get; set; }

    public int CustomerId { get; set; }
    public Customer Customer { get; set; }
}

// ---------- One-to-Many ----------
public class Order
{
    public int Id { get; set; }
    public string Product { get; set; }
    public decimal Price { get; set; }

    public int CustomerId { get; set; }
    public Customer Customer { get; set; }
}

// ---------- Many-to-Many ----------
public class Student
{
    public int Id { get; set; }
    public string Name { get; set; }

    public ICollection<Course> Courses { get; set; }
}

public class Course
{
    public int Id { get; set; }
    public string Title { get; set; }

    public ICollection<Student> Students { get; set; }
}
