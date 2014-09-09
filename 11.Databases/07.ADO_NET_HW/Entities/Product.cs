namespace Northwind.Entities
{
    public class Product
    {
        public string ProductName { get; set; }

        public int? SupplierID { get; set; }

        public int? CategoryID { get; set; }

        public int QuantityPerUnit { get; set; }

        public decimal UnitPrice { get; set; }

        public int UnitsInStock { get; set; }

        public int UnitsOnOrder { get; set; }

        public int ReorderLevel { get; set; }

        public bool Discontinued { get; set; }

        public Product(string productName, bool discontinued)
        {
            this.ProductName = productName;
            this.Discontinued = discontinued;
            this.CategoryID = null;
            this.SupplierID = null;
        }
    }
}