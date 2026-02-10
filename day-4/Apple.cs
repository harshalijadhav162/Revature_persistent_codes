public class Apple : Fruit
{
    public Apple()
    {
        Name = "Apple";
    }

    public override void ApplyDiscount()
    {
        Console.WriteLine("Apple discount applied: 10%");
    }

    public override void Display()
    {
        Console.WriteLine("This is an Apple");
    }
}
