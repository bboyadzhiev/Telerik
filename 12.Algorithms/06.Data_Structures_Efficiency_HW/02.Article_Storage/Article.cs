namespace _02.Article_Storage
{
    using System;

    public class Article : IComparable<Article>
    {
        public int Barcode { get; set; }

        public string Vendor { get; set; }

        public string Title { get; set; }

        public double Price { get; set; }

        public Article(int barcode, string vendor, string title, double price)
        {
            this.Barcode = barcode;
            this.Vendor = vendor;
            this.Title = title;
            this.Price = price;
        }

        public int CompareTo(Article article)
        {
            return this.Price.CompareTo(article.Price);
        }
    }
}