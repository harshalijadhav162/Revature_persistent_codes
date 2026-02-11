using System;
using System.Collections.Generic;
using System.Linq;

namespace CustomerOrderJoin
{
    class Customer
    {
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
    }

    class Order
    {
        public int OrderID { get; set; }
        public int CustomerID { get; set; }
        public int EmpID { get; set; }
        public double OrderAmount { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Customer> customers = new List<Customer>
            {
                new Customer { CustomerID = 1, CustomerName = "Alice" },
                new Customer { CustomerID = 2, CustomerName = "Bob" },
                new Customer { CustomerID = 3, CustomerName = "Charlie" },
                new Customer { CustomerID = 4, CustomerName = "David" }
            };

            List<Order> orders = new List<Order>
            {
                new Order { OrderID = 101, CustomerID = 1, EmpID = 201, OrderAmount = 250 },
                new Order { OrderID = 102, CustomerID = 1, EmpID = 202, OrderAmount = 150 },
                new Order { OrderID = 103, CustomerID = 2, EmpID = 203, OrderAmount = 300 },
                new Order { OrderID = 104, CustomerID = 3, EmpID = 201, OrderAmount = 200 },
                new Order { OrderID = 105, CustomerID = 2, EmpID = 202, OrderAmount = 100 }
            };

            var customerOrders = from c in customers
                                 join o in orders on c.CustomerID equals o.CustomerID
                                 group o by c.CustomerName into g
                                 select new
                                 {
                                     CustomerName = g.Key,
                                     Orders = g.ToList(),
                                     TotalOrders = g.Count(),
                                     TotalAmount = g.Sum(x => x.OrderAmount)
                                 };

            foreach (var co in customerOrders)
            {
                Console.WriteLine($"Customer: {co.CustomerName}");
                Console.WriteLine($"Number of Orders: {co.TotalOrders}");
                Console.WriteLine($"Total Order Amount: {co.TotalAmount}");
                Console.WriteLine("Orders:");
                foreach (var order in co.Orders)
                {
                    Console.WriteLine($"  OrderID: {order.OrderID}, Amount: {order.OrderAmount}, EmpID: {order.EmpID}");
                }
               
            }

            Console.ReadLine();
        }
    }
}
