namespace _04.All_permutations_of_N
{
    using System;

    internal class All_permutations_of_N
    {
        // Write a recursive program for generating and printing all permutations
        // of the numbers 1, 2, ..., n for given integer number n. Example:
        // n=3 : {1, 2, 3}, {1, 3, 2}, {2, 1, 3}, {2, 3, 1}, {3, 1, 2},{3, 2, 1}

        private static void Main(string[] args)
        {
            int n = 3;
            int[] mainArray = new int[n];
            bool[] usedNumsArray = new bool[n];
            Permutate(0, n, mainArray, usedNumsArray);
        }

        private static void Permutate(int index, int n, int[] mainArray, bool[] usedNumsArray)
        {
            if (index >= n)
            {
                Print(n, mainArray);
                return;
            }
            for (int j = 0; j < n; j++)
            {
                if (usedNumsArray[j] == false) // not used number yet
                {
                    usedNumsArray[j] = true; // mark current number as used
                    mainArray[index] = j;
                    Permutate(index + 1, n, mainArray, usedNumsArray);
                    usedNumsArray[j] = false; // unmark current number
                }
            }
        }

        private static void Print(int n, int[] mainArray)
        {
            for (int i = 0; i < n; i++)
            {
                Console.Write("{0} ", mainArray[i] + 1);
            }
            Console.WriteLine();
        }
    }
}