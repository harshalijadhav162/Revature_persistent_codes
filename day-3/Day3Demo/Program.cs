using MethodsDemo;
using EmployeeDemo;
using ExtensionMethodsDemo;

namespace MethodsDemo
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("=== Student Demo ===");
            StudentDemo();

            Console.WriteLine("\n=== Parameters Demo ===");
            ParametersDemoDemo();

            Console.WriteLine("\n=== Calculator Demo ===");
            CalculatorDemo();

            Console.WriteLine("\n=== Extension / Employee Demo ===");
            ExtnsionMethodDemo();
        }

        static void StudentDemo()
        {
            var alice = new Student("Alice", 20);
            alice.Print();

            var bob = new Student("Bob", 22);
            bob.Print();

            var charlie = new Student("Charlie", 24);
            charlie.Print();
        }

        static void ParametersDemoDemo()
        {
            var demo = new ParametersDemo();

            demo.Configure();
            demo.Configure(60, true);

            int count;
            demo.SetCount(out count);
            Console.WriteLine($"Count from SetCount: {count}");

            Console.WriteLine($"Params sum: {demo.ParamsDemo(1,2,3,4,5)}");
        }

        static void CalculatorDemo()
        {
            var calc = new Calculator(5, 10);
            Console.WriteLine($"Instance Add: {calc.Add()}");
            Console.WriteLine($"Static Add: {Calculator.Add(7, 3)}");
        }

        static void ExtnsionMethodDemo()
        {
            var dave = new Employee(1, "Dave", "Smith", 30);
            dave.Print();
            dave.DoubleTheAge();
            dave.Print();

            string text = "Hello world from C#";
            Console.WriteLine($"Word count (extension): {text.WordCount()}");
        }
    }
}
