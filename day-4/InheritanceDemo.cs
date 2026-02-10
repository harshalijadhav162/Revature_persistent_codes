public class Vehicle
{
    public Vehicle()
    {
        Console.WriteLine("Vehicle constructor");
    }

    public virtual void Start()
    {
        Console.WriteLine("Vehicle starting");
    }
}

public class Car : Vehicle
{
    public Car() : base()
    {
        Console.WriteLine("Car constructor");
    }

    public override void Start()
    {
        Console.WriteLine("Car starting");
    }
}
