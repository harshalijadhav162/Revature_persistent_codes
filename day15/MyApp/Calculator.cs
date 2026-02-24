using MyApp;
namespace MyApp;


public class Calculator
{
    public int Add(int a, int b)
    {
        return a + b;
    }

    public int Subtract(int a, int b)
    {
        return a - b;
    }
}

class Program
{
    static void Main(string[] args)
    {
        var calculator = new Calculator();

        Console.WriteLine("Addition Result: " + calculator.Add(10, 20));
        Console.WriteLine("Subtraction Result: " + calculator.Subtract(20, 5));
    }
}