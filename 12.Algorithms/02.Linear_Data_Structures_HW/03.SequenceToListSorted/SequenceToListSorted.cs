using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.SequenceToListSorted
{
    class SequenceToListSorted
    {
        private static void Main(string[] args)
        {
            var input = 0;
            var intSequence = new List<int>();
            Console.Write("Enter first positive integer: ");
            while (int.TryParse(Console.ReadLine(), out input))
            {
                intSequence.Add(input);
                Console.Write("\nEnter next positive integer: ");
            }
            Console.WriteLine();

            intSequence.Sort();

            Console.Write("Sorted sequence: ");
            foreach (var item in intSequence)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
    }
}
