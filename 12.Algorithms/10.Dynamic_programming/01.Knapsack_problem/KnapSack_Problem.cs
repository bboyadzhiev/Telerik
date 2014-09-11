namespace _01.Knapsack_problem
{
    using System;
    using System.Collections.Generic;

    internal class Item
    {
        public int Cost { get; set; }

        public string Name { get; set; }

        public int Weight { get; set; }

        public Item(string name, int weight, int cost)
        {
            this.Name = name;
            this.Cost = cost;
            this.Weight = weight;
        }
    }

    internal class Knapsack_Problem
    {
        private static Item[] items;

        private static int[,] tableValues;

        private static int[,] tableKeep;

        private static int knapsackSpace;

        private static List<Item> finalItemsList = new List<Item>();

        private static void Main()
        {
            items = new Item[]
            {
                new Item("beer", 3, 2),
                new Item("vodka", 8, 12),
                new Item("cheese", 4, 5),
                new Item("nuts", 1, 4),
                new Item("ham", 2, 3),
                new Item("whiskey", 8, 13)
            };

            // http://www.youtube.com/watch?v=EH6h7WA7sDw
            // The 0/1 Knapsack Problem - Dynamic Programming Method 

            Console.Write("Enter knapsacksack capacity: ");
            knapsackSpace = int.Parse(Console.ReadLine());
            tableValues = new int[items.Length + 1, knapsackSpace + 1];
            tableKeep = new int[items.Length + 1, knapsackSpace + 1];

            EvaluateItemsAndBuildTables();

            BuildSolution();

            PrintAnswer();
        }

        private static void EvaluateItemsAndBuildTables()
        {
            for (int i = 1; i <= items.Length; i++)
            {
                for (int j = 1; j <= knapsackSpace; j++)
                {
                    if (items[i - 1].Weight <= j)
                    {
                        if (items[i - 1].Cost + tableValues[i - 1, j - items[i - 1].Weight] > tableValues[i - 1, j])
                        {
                            tableValues[i, j] = items[i - 1].Cost + tableValues[i - 1, j - items[i - 1].Weight];
                            tableKeep[i, j] = 1;
                        }
                        else
                        {
                            tableValues[i, j] = tableValues[i - 1, j];
                        }
                    }
                }
            }
        }

        private static void BuildSolution()
        {
            var itemsCount = items.Length;
            var spaceLeft = knapsackSpace;

            while (itemsCount > 0)
            {
                if (tableKeep[itemsCount, spaceLeft] != 0)
                {
                    finalItemsList.Add(items[itemsCount - 1]);
                    spaceLeft = spaceLeft - items[itemsCount - 1].Weight;
                }

                itemsCount--;
            }
        }

        private static void PrintAnswer()
        {
            Console.WriteLine(string.Format("Solution for knapsack of capacity {0}:", knapsackSpace));
            foreach (var item in finalItemsList)
            {
                Console.WriteLine(" - Add item: {0} with weight {1} and cost {2}", item.Name, item.Weight, item.Cost);
            }
        }
    }
}