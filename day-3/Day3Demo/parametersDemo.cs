namespace MethodsDemo
{
    public class ParametersDemo
    {
        public void Configure(int timeout = 30, bool verbose = false)
        {
            Console.WriteLine($"Timeout set to: {timeout} seconds");
            Console.WriteLine($"Verbose mode: {verbose}");
        }

        public void SetCount(out int count)
        {
            count = 42;
        }

        public int ParamsDemo(params int[] numbers)
        {
            int sum = 0;
            foreach (var n in numbers)
                sum += n;
            return sum;
        }
    }
}
