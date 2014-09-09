namespace _01.SequenceToList
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class SequenceToList
    {
        private static void Main(string[] args)
        {
            var input = 0;
            var intSequence = new List<int>();
            Console.Write("Enter first positive integer: ");
            while (int.TryParse(Console.ReadLine(), out input) && input > 0)
            {
                intSequence.Add(input);
                Console.Write("\nEnter next positive integer: ");
            }
            Console.WriteLine();

            Console.WriteLine("Sequence count is {0} elements", intSequence.Count);
            Console.WriteLine("The sum of the elements is {0}", intSequence.Sum());
            Console.WriteLine("The average value of the elements is {0}", intSequence.Average());
        }
    }
}