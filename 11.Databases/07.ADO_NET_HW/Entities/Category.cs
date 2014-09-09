namespace Northwind.Entities
{
    public class Category
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public Category(string name, string description)
        {
            this.Name = name;
            this.Description = description;
        }
    }
}