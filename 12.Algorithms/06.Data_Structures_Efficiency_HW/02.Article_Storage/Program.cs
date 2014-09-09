namespace _02.Article_Storage
{
    using System;
    using Wintellect.PowerCollections;

    internal class Program
    {
        private static void Main(string[] args)
        {
            var seed = new Random();

            var articlesStorage = new OrderedMultiDictionary<double, Article>(true);
            for (int i = 0; i < 100; i++)
            {
                var article = new Article(seed.Next(100000, 999999), "Vendor " + i, "Title " + i, seed.Next(1, 50));
                articlesStorage.Add(article.Price, article);
            }

            var minPrice = 30;
            var maxPrice = 50;

            var selected = articlesStorage.Range(minPrice, true, maxPrice, true);

            foreach (var article in selected)
            {
                foreach (var item in article.Value)
                {
                    Console.WriteLine("Price: {0}, barcode: {1}, vendor{2}, title:{3}", item.Price, item.Barcode, item.Vendor, item.Title);
                }
            }
        }
    }
}