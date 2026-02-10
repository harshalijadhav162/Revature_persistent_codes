namespace MethodsDemo
{
    class Calculator
    {
        public int a { get; set; }
        public int b { get; set; }

        public Calculator(int a, int b)
        {
            this.a = a;
            this.b = b;
        }

        public int Add() => this.a + this.b;
        public static int Add(int a, int b) => a + b;
    }
}
