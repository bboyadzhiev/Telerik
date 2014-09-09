namespace _04.SubsequenceOfEqualNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class SubsequenceOfEqualNumbers
    {
        private static List<int> GetLongestSubsequenceOfEquals(List<int> sequence)
        {
            var subsequence = new List<int>();
            var bestMatch = sequence.First();
            var equals = 1;
            var maxEqual = 0;
            for (int i = 1; i < sequence.Count - 1; i++)
            {
                if (sequence[i] == sequence[i + 1])
                {
                    equals += 1;
                }
                else
                {
                    equals = 1;
                }
                if (equals > maxEqual)
                {
                    maxEqual = equals;
                    bestMatch = sequence[i];
                }
            }
            for (int i = 0; i < maxEqual; i++)
            {
                subsequence.Add(bestMatch);
            }
            return subsequence;
        }

        private static void Main(string[] args)
        {
            var sequence = new List<int>() { 8, 8, 1, 1, 1, 2, 3, 4, 4, 4, 4, 5, 6, 6, 6, };
            var subsequence = GetLongestSubsequenceOfEquals(sequence);

            Console.Write("Found sequence: ");
            foreach (var item in subsequence)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
    }
}