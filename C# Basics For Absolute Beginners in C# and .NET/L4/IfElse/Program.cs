// See https://aka.ms/new-console-template for more information
using System;

namespace IfElse
{
    class Program
    {
        static void Main(string[] args)
        {
            char ch;

            Console.WriteLine("Enter you favourite subject option: ");
            ch = (char)Console.Read();

            if (ch == 'e')
            {
                Console.WriteLine("English");
            }
            else if (ch == 'm')
            {
                Console.WriteLine("Math");
            }
            else if (ch == 's')
            {
                Console.WriteLine("Science");
            }
            else
            {
                Console.WriteLine("Other");
            }
        }
    }
}
