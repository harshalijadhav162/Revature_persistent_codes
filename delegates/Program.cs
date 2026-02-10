namespace DelegatesDemo;

class Program
{
    static void Main(string[] args)
    {
        DelegatesDemoApp app = new DelegatesDemoApp();
        app.Run();
    }
}

delegate int MathOperation(int a, int b);

delegate void GenericTwoParameterAtion<TFirst, TSecond>(TFirst a, TSecond b);

class DelegatesDemoApp
{

    void PrintMessage(string message)
    {
        Console.WriteLine(message);
    }

    bool IsEven(int number)
    {
        return number % 2 == 0;
    }

    public void Run()
    {
        
        Func<int, int, int> genericOperation = Add;

        Action<string> action = PrintMessage;
        action("Hello from Action delegate!");

        Predicate<int> predicate = IsEven;
        int testNumber = 4;

        Console.WriteLine($"Is {testNumber} even? {predicate(testNumber)}");

        Func<string, string, string> stringOperation = Concatenate;

        var x = stringOperation("Hello, ", "World!");
        Console.WriteLine($"Concatenation result: {x}");

        
        genericOperation += Subtract;
        genericOperation += Multiply;
        genericOperation += Divide;

        genericOperation -= Subtract;
        int result = genericOperation(10, 5);
        Console.WriteLine($"Final result: {result}");
    }

    public string Concatenate(string a, string b)
    {
        string result = a + b;
        Console.WriteLine($"Concatenating '{a}' and '{b}' results in: '{result}'");
        return result;
    }

    public int Add(int a, int b)
    {
        Console.WriteLine($"The sum of {a} and {b} is: {a + b}");
        return a + b;
    }

    public int Subtract(int a, int b)
    {
        Console.WriteLine($"The difference between {a} and {b} is: {a - b}");
        return a - b;
    }

    public int Multiply(int a, int b)
    {
        Console.WriteLine($"The product of {a} and {b} is: {a * b}");
        return a * b;
    }

    public int Divide(int a, int b)
    {
        if (b != 0)
        {
            Console.WriteLine($"The quotient of {a} and {b} is: {a / b}");
            return a / b;
        }
        else
        {
            Console.WriteLine("Cannot divide by zero.");
        }
        return 0;
    }
    public void LambdaExpression
}