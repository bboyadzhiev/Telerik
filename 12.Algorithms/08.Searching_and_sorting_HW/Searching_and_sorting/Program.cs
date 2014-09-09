namespace SortingHomework
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;

    internal class Program
    {
        internal static void Main(string[] args)
        {
            var sw = new Stopwatch();
            var elementsCount = 500;
            var randomCollection = new List<int>();

            Random rnd = new Random();
            for (int i = 0; i < elementsCount; i++)
            {
                randomCollection.Add(rnd.Next(0, 9999));
            }

            var linearSearchItem = randomCollection.Max();
            //var collection = new SortableCollection<int>(new[] { 22, 11, 101, 33, 0, 101 });

            Console.WriteLine("All items before sorting:");
            PrintRandomIntsCollection(randomCollection);
            Console.WriteLine();

            var collection = new SortableCollection<int>(randomCollection);
            sw.Restart();
            Console.WriteLine("SelectionSorter result:");
            collection.Sort(new SelectionSorter<int>());
            sw.Stop();
            collection.PrintAllItemsOnConsole();
            Console.WriteLine(sw.Elapsed);
            Console.WriteLine();

            collection = new SortableCollection<int>(randomCollection);
            Console.WriteLine("Quicksorter result:");
            sw.Restart();
            collection.Sort(new Quicksorter<int>());
            sw.Stop();
            collection.PrintAllItemsOnConsole();
            Console.WriteLine(sw.Elapsed);
            Console.WriteLine();

            collection = new SortableCollection<int>(randomCollection);
            Console.WriteLine("MergeSorter result:");
            sw.Restart();
            collection.Sort(new MergeSorter<int>());
            sw.Stop();
            collection.PrintAllItemsOnConsole();
            Console.WriteLine(sw.Elapsed);
            Console.WriteLine();

            Console.WriteLine("Linear search {0}:", linearSearchItem);
            sw.Restart();
            Console.WriteLine(collection.LinearSearch(linearSearchItem));
            sw.Stop();
            Console.WriteLine(sw.Elapsed);
            Console.WriteLine();

            Console.WriteLine("Binary search {0}:", linearSearchItem);
            sw.Restart();
            Console.WriteLine(collection.BinarySearch(linearSearchItem));
            sw.Stop();
            Console.WriteLine(sw.Elapsed);
            Console.WriteLine();

            Console.WriteLine("Shuffle:");
            collection.Shuffle();
            collection.PrintAllItemsOnConsole();
            Console.WriteLine();

            Console.WriteLine("Shuffle again:");
            collection.Shuffle();
            collection.PrintAllItemsOnConsole();
        }

        public static void PrintRandomIntsCollection(List<int> items)
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (i == 0)
                {
                    Console.Write(items[i]);
                }
                else
                {
                    Console.Write(" " + items[i]);
                }
            }

            Console.WriteLine();
        }
    }
}