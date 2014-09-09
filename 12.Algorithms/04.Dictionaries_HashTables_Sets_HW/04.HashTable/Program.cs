using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.HashTable
{
    class Program
    {
        static void Main(string[] args)
        {
            var hs = new HashTable<int, string>();

            hs.Add(1, "A");
            hs.Add(2, "B");
            hs.Add(3, "C");
            hs.Add(4, "D");
            hs.Add(5, "E");
            hs.Add(6, "F");

            hs.Remove(1);

            foreach (var item in hs)
            {
                Console.WriteLine(item.Value);
            }
        }
    }
}
