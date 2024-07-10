// See https://aka.ms/new-console-template for more information
using System;

namespace SwitchCase
{
    class Program
    {
        static void Main(string[] args)
        {
            int month;
            Console.WriteLine("Enter you favourite month: ");
            month = int.Parse(Console.ReadLine());
            switch ((month<=12) && (month>=1)) {
                case true:{
                    switch (month/4) {
                        case 0:{
                            Console.WriteLine("Quater 1");
                            break;
                        }
                        case 1:{
                            Console.WriteLine("Quater 2");
                            break;
                        }
                        case 2:{
                            Console.WriteLine("Quater 3");
                            break;
                        }
                        default:{
                            Console.WriteLine("Quater 4");
                            break;
                        }
                    }
                    break;
                }
                default: {
                    Console.WriteLine("Not a valid month");
                    break;
                }
            }
        }
    }
}
