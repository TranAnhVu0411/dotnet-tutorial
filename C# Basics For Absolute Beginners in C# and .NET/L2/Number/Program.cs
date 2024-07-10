// See https://aka.ms/new-console-template for more information
using System;

namespace Number
{
    class Program
    {
        static void Main(string[] args)
        {
            // Whole Number
            // Integer
            int i = 10;
            Console.WriteLine($"Integer: {i}");
            int j = int.Parse(Console.ReadLine()); // Parse
            Console.WriteLine($"From Input type (String) to Integer: {j}");

            // Short
            short s = 10;
            Console.WriteLine($"Short: {s}");
            // Long
            long l = 20;
            Console.WriteLine($"Long: {l}");
            // Unsigned Integer
            uint ui = 2;
            Console.WriteLine($"Unsigned Interger: {ui}");

            // Convert to different type
            // int intNum = l; // Error: Cannot implicitly convert type 'long' to 'int'
            int intNum = (int)l;
            Console.WriteLine($"Convert Long to Integer: {intNum}");

            // Decimal Number
            float f = 10.5F; // Float
            double d = 123.99; // Double
            decimal dd = 345.09M; // Decimal
            Console.WriteLine($"Float: {f}");
            Console.WriteLine($"Double: {d}");
            Console.WriteLine($"Decimal: {dd}");
            decimal decimalNum = (decimal)f;

        }
    }
}
