using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.RemoveNegativesFromSequence
{
    class RemoveNegativesFromSequence
    {
        static void Main(string[] args)
        {
            var sequence = new List<int>() 
                { 8, -8, 1, -1, -1, -2, 3, 4, 4, 4, 4, -5, 6, 6, 6, }
                .Where(x => x >= 0);

            Console.Write("Positives: ");
            foreach (var item in sequence)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
    }
}
