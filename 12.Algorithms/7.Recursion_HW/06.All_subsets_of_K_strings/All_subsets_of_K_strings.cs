using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.All_subsets_of_K_strings
{
    class All_subsets_of_K_strings
    {
    // Write a program for generating and printing all subsets of k strings from given set of strings.
    // Example: s = {test, rock, fun}, k=2
    // (test rock),  (test fun),  (rock fun)

        static void Main(string[] args)
        {
            string[] strings = new string[] { "test", "rock", "fun" };
            string[] taken = new string[strings.Length];
            int k = 2;
            Recursion(strings, taken, 1, 0, strings.Length, k);
        }

        static void Recursion(string[] array, string[] taken, int index, int nextElement, int elementsCount, int combinationLength)
        {
            if (index > combinationLength)
            {
                return;
            }

            for (int j = nextElement; j < elementsCount; j++)
            {
                taken[index - 1] = array[j];
                if (index == combinationLength)
                {
                    Print(index, taken);
                }
                Recursion(array, taken, index + 1, j + 1, elementsCount, combinationLength);
            }

        }
        static void Print(int i, string[] array)
        {
            for (int j = 0; j < i; j++)
            {
                Console.Write("{0} ", array[j]);
            }
            Console.WriteLine();
        }
    }
}
