// See https://aka.ms/new-console-template for more information
using System;

namespace IterationStatement
{
    class Program
    {
        static void Main(string[] args)
        {
            // WHILE
            int i = 0, MAX = 5;
            while (i < MAX) {
                Console.WriteLine(i);
                i++;
            }

            // DO WHILE
            i = 0; 
            do
            {
                Console.WriteLine(i);
                i++;
            } while (i < MAX);

            // FOR
            for (int j=0; j<MAX; j++) {
                Console.WriteLine(j);
            }

            // FOR EACH
            int[] arr = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            foreach (int k in arr) {
                Console.WriteLine(k);
            }
        }
    }
}
