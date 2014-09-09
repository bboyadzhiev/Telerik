using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Ordered_K_element_subset_from_N_element_set
{
    class Ordered_K_element_subset_from_N_element_set
    {
    // Write a recursive program for generating and printing all ordered k-element subsets 
    // from n-element set (variations Vkn).
	// Example: n=3, k=2, set = {hi, a, b} =>
	// (hi hi), (hi a), (hi b), (a hi), (a a), (a b), (b hi), (b a), (b b)

        static void Main()
        {
            var k = 2;
            var set = new string[] { "hi", "a", "b" };
            var variationIndexes = new int[set.Length];
            Variate(0, k, set.Length, set, variationIndexes);
        }
        static void Variate(int index, int subsetLength, int setLength, string[] set, int[] varIndexes)
        {
            if (index >= subsetLength)
            {
                Print(subsetLength, set, varIndexes);
                return;
            }
            for (int i = 0; i < setLength; i++)
            {
                varIndexes[index] = i;
                Variate(index + 1, subsetLength, setLength, set, varIndexes);
            }
        }
        static void Print(int setLength, string[] set, int[] varIndexes)
        {
            for (int i = 0; i < setLength; i++)
            {
                Console.Write("{0} ", set[varIndexes[i]]);
            }
            Console.WriteLine();
        }
    }
}
