using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.N_nested_loops
{
    class N_nested_loops
    {
        // Write a recursive program that simulates the execution 
        // of n nested loops from 1 to n. 

        static void Main(string[] args)
        {
            int n = 3;
            int startNum = 1;
            int endNum = n;

            int[] arr = new int[n];
            GenerateCombinations(arr, 0, startNum, endNum);

        }

        static void GenerateCombinations(int[] arr, int index, int startNum, int endNum)
        {
            if (index >= arr.Length)
            {
                // A combination was found --> print it
                Console.WriteLine("(" + String.Join(", ", arr) + ")");
            }
            else
            {
                for (int i = startNum; i <= endNum; i++)
                {
                    arr[index] = i;
                    GenerateCombinations(arr, index + 1, startNum, endNum);
                }
            }
        }

    }
}
