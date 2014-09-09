namespace _01.Count_doubles_in_array
{
    using System;
    using System.Collections.Generic;

    internal class Count_doubles_in_array
    {
        private static void Main(string[] args)
        {
            var doublesArray = new double[] { 3, 4, 4, -2.5, 3, 3, 4, 3, -2.5 };
            var doublesCount = DoublesArrayToDictionary(doublesArray);

            foreach (var item in doublesCount)
            {
                Console.WriteLine("{0} -> {1}", item.Key, item.Value);
            }
        }

        private static Dictionary<double, int> DoublesArrayToDictionary(double[] doublesArray)
        {
            var doublesCount = new Dictionary<double, int>();

            foreach (var item in doublesArray)
            {
                if (doublesCount.ContainsKey(item))
                {
                    doublesCount[item]++;
                }
                else
                {
                    doublesCount.Add(item, 1);
                }
            }
            return doublesCount;
        }
    }
}