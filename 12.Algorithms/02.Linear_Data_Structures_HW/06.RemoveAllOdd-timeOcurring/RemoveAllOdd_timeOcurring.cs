namespace _06.RemoveAllOdd_timeOcurring
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class RemoveAllOdd_timeOcurring
    {
        private static void Main(string[] args)
        {
            var sequence = new List<int>() { 6, 8, -8, 1, -1, -1, -2, 3, 4, 4, 4, 4, -5, 6, 6, 6 };

            sequence = sequence
                .GroupBy(i => i)
                .ToDictionary(d => d.Key, d => d.Count())
                .Where(w => w.Value % 2 == 0)
                .Select(k => k.Key)
                .ToList();

            Console.WriteLine("All even-times occuring elements: ");
            Console.Write(string.Join(", ", sequence));
            Console.WriteLine();
        }
    }
}