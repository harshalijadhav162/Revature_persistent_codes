using System;
using System.Collections.Generic;
using System.Linq;

var unitOfWork = new UnitOfWork();

// Add customers
var customer1 = new Customer { Id = 1, Name = "Alice" };
var customer2 = new Customer { Id = 2, Name = "Bob" };

unitOfWork.Customers.Add(customer1);
unitOfWork.Customers.Add(customer2);

// Fetch customer
var customer = unitOfWork.Customers.GetById(1);

if (customer != null)
{
    Console.WriteLine($"Customer 1 Name: {customer.Name}");
}

// Update customer
if (customer != null)
{
    customer.Name = "Zia";
    Console.WriteLine($"Updated Customer Name: {customer.Name}");
}

// Remove customer
unitOfWork.Customers.Remove(2);

// Add order
var order = new Order
{
    Id = 1,
    ProductName = "Laptop",
    Quantity = 2
};

unitOfWork.Orders.Add(order);

// Commit changes
unitOfWork.Commit();

Console.WriteLine("Program completed.");

public class Customer
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
}