using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.OccuranceCount
{
    class OccuranceCount
    {
        static void Main(string[] args)
        {
            var sequence = new List<int>() { 6, 8, -8, 1, -1, -1, -2, 3, 4, 4, 4, 4, -5, 6, 6, 6 };

            var occurances = sequence
                .GroupBy(i => i)
                .ToDictionary(d => d.Key, d => d.Count());

            Console.WriteLine("Occurances : ");
            foreach (var item in occurances.Keys)
            {
                Console.WriteLine("{0} -> {1}", item, occurances[item]);
            }
            
            Console.WriteLine();
        }
    }
}
