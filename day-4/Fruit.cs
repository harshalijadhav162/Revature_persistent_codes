public abstract class Fruit
{
    public string Name { get; set; }

    public abstract void ApplyDiscount();

    public virtual void Display()
    {
        Console.WriteLine("This is a fruit");
    }
}
