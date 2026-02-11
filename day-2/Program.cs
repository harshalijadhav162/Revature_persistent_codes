using System;
using System.Text;

namespace Day2Basics
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = "Harshali";
            Console.WriteLine(name);

            var city = "Nashik";
            var number = 100;

            StringBuilder sb = new StringBuilder();
            sb.Append("Welcome ");
            sb.Append("to ");
            sb.Append(".NET");

            Console.WriteLine(sb.ToString());
            Console.WriteLine(city);
            Console.WriteLine(number);
        }
    }
}
