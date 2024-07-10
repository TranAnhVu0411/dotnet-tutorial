// See https://aka.ms/new-console-template for more information
using System;

namespace Array
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] myNumbers = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            Console.WriteLine($"Length of myNumbers: {myNumbers.Length}");
            Console.WriteLine($"First index value of myNumbers: {myNumbers[0]}");

            int[] myNumbers2;
            myNumbers2 = new int[10];
            myNumbers2[0] = 10;
            Console.WriteLine($"First index value of myNumbers2: {myNumbers2[0]}");
            Console.WriteLine($"Second index value of myNumbers2: {myNumbers2[1]}");
        }
    }
}
