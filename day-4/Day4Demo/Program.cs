using System;

class Program
{
    static void Main()
    {
        
        Fruit fruit = new Apple();
        fruit.ApplyDiscount();
        fruit.Display();

        Console.WriteLine();

        IElectricityProvider supplier = new ElectricityOnlySupplier();
        GenerateBill(supplier);

        Console.WriteLine();

        Vehicle v = new Car();
        v.Start();
    }

    static void GenerateBill(IElectricityProvider electricityProvider)
    {
        electricityProvider.SupplyService();
    }
}
