using System;

namespace DelegatesDemo
{
    class DelegatesDemoApp
    {
        delegate int MathOperation(int a, int b);

        public void Run()
        {
            MathOperation operation = Add;

            operation += Subtract;
            operation += Multiply;
            operation += Divide;

            var result = operation(5, 3);
            Console.WriteLine($"Final result: {result}");
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
            Console.WriteLine($"The quotient of {a} and {b} is: {a / b}");
            return a / b;
        }
    }

    class Program
    {
        static void Main()
        {
            DelegatesDemoApp app = new DelegatesDemoApp();
            app.Run();
        }
    }
}
