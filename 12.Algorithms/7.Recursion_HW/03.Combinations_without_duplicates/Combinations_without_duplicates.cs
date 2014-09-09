using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Combinations_without_duplicates
{
    class Combinations_without_duplicates
    {
        //2.Write a recursive program for generating and printing 
        //  all the combinations with duplicates of k elements from n-element set. Example:
        //  n=3, k=2 : (1 1), (1 2), (1 3), (2 2), (2 3), (3 3)
        // Modify the previous program to skip duplicates:
        // n=4, k=2 : (1 2), (1 3), (1 4), (2 3), (2 4), (3 4)

        static void Main(string[] args)
        {
            int n = 4;
            int k = 2;
            int elementsCount = n;
            int combinationLength = k;

            int[] arr = new int[k];
            Rec(arr, 1, 1, elementsCount, combinationLength);
        }

        static void Rec(int[] array, int index, int nextElement, int elementsCount, int combinationLength)
        {
            if (index > combinationLength)
            {
                return;
            }

            for (int j = nextElement; j <= elementsCount; j++)
            {
                array[index - 1] = j;
                if (index == combinationLength)
                {
                    Print(index, array);
                }
                Rec(array, index + 1, j+1, elementsCount, combinationLength);
            }
        }

        static void Print(int i, int[] arr)
        {
            for (int j = 0; j < i; j++)
            {
                Console.Write("{0} ", arr[j]);
            }
            Console.WriteLine();
        }
    }
}
