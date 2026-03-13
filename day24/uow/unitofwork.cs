using System;
using System.Collections.Generic;
using System.Linq;

public class DatabaseContext
{
    public List<Customer> Customers { get; set; } = new();
    public List<Order> Orders { get; set; } = new();
}

public class CustomerRepository
{
    private readonly DatabaseContext _context;

    public CustomerRepository(DatabaseContext context)
    {
        _context = context;
    }

    public void Add(Customer customer)
    {
        _context.Customers.Add(customer);
    }

    public IEnumerable<Customer> GetAll()
    {
        return _context.Customers;
    }

    public Customer? GetById(int id)
    {
        return _context.Customers.FirstOrDefault(c => c.Id == id);
    }

    public void Remove(int id)
    {
        var customer = _context.Customers.FirstOrDefault(c => c.Id == id);
        if (customer != null)
        {
            _context.Customers.Remove(customer);
        }
    }
}

public class OrderRepository
{
    private readonly DatabaseContext _context;

    public OrderRepository(DatabaseContext context)
    {
        _context = context;
    }

    public void Add(Order order)
    {
        _context.Orders.Add(order);
    }

    public IEnumerable<Order> GetAll()
    {
        return _context.Orders;
    }

    public Order? GetById(int id)
    {
        return _context.Orders.FirstOrDefault(o => o.Id == id);
    }

    public void Remove(int id)
    {
        var order = _context.Orders.FirstOrDefault(o => o.Id == id);
        if (order != null)
        {
            _context.Orders.Remove(order);
        }
    }
}

public class UnitOfWork
{
    private readonly DatabaseContext _context;

    public CustomerRepository Customers { get; }
    public OrderRepository Orders { get; }

    public UnitOfWork()
    {
        _context = new DatabaseContext();
        Customers = new CustomerRepository(_context);
        Orders = new OrderRepository(_context);
    }

    public void Commit()
    {
        Console.WriteLine("Changes committed to database.");
    }
}

public class Order
{
    public int Id { get; set; }
    public string ProductName { get; set; } = "";
    public int Quantity { get; set; }
}