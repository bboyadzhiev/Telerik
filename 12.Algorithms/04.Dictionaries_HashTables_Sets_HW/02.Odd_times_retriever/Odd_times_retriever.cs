namespace _02.Odd_times_retriever
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Odd_times_retriever
    {
        private static void Main(string[] args)
        {
            var array = new string[] { "C#", "SQL", "PHP", "PHP", "SQL", "SQL" };
            var list = OddTimesRetriever(array);
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }

        private static List<T> OddTimesRetriever<T>(T[] elementsArray)
        {
            var elementsCount = new Dictionary<T, int>();

            foreach (var item in elementsArray)
            {
                if (elementsCount.ContainsKey(item))
                {
                    elementsCount[item]++;
                }
                else
                {
                    elementsCount.Add(item, 1);
                }
            }

            return elementsCount.Where(kvp => kvp.Value % 2 != 0).Select(kvp => kvp.Key).ToList();
        }
    }
}