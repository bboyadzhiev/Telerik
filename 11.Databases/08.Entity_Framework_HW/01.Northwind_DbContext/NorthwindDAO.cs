using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Northwind_DbContext
{
    public static class NorthwindDAO
    {

       // public NorthwindDAO(NorthwindEntities context)
       // {
       //     db = context;
       // }
        public static void InsertCustomer(string customerID, string companyName, string city)
        {
            NorthwindEntities db = new NorthwindEntities();
            using (db)
            {
                var newCustomer = new Customer
                {
                    CustomerID = customerID,
                    CompanyName = companyName,
                     ContactName = null,
                    ContactTitle = null,
                   Address = null,
                    City = city,
                    Region = null,
                    PostalCode = null,
                    Country = null,
                    Phone = null,
                    Fax = null
                };
                db.Customers.Add(newCustomer);
                db.SaveChanges();
            }
        }
        public static void DeleteCustomer(string customerID)
        {
            NorthwindEntities db = new NorthwindEntities();
            using (db)
            {
                var customerToRemove = db.Customers.Find(customerID);
                db.Customers.Remove(customerToRemove);
                db.SaveChanges();
            }
        }
        public static void ModifyCustomer(string customerID, string companyName, string city)
        {
            NorthwindEntities db = new NorthwindEntities();
            using (db)
            {
                var customerToModify = db.Customers.Find(customerID);
                customerToModify.CompanyName = companyName;
                customerToModify.City = city;
                db.SaveChanges();
            }
        }

        public static void FindByOrder(int year, string country)
        {
            NorthwindEntities db = new NorthwindEntities();
            var customers = db.Orders
                .Where(o => o.OrderDate.Value.Year == year && o.ShipCountry == country)
                .GroupBy(o => o.Customer.CompanyName);
            foreach (var customer in customers)
            {
                Console.WriteLine(customer.Key);
            }
        }

        public static void FindByOrderUsingSQL(int year, string country)
        {
            NorthwindEntities db = new NorthwindEntities();
            string nativeSQL =
            "SELECT c.CustomerID " +
            "FROM Customers c " +
            "JOIN Orders o " +
            "ON c.CustomerID = o.CustomerID " +
            "WHERE YEAR(o.OrderDate) = {0} " +
            "AND o.ShipCountry = {1} " +
            "group by c.CustomerID";
            object[] parameters = { year, country };
            var foundCustomers = db.Database.SqlQuery<string>(nativeSQL, parameters);
            foreach (var customer in foundCustomers)
            {
                Console.WriteLine(customer);
            }
        }

        public static void FindSales(string region, DateTime fromDate, DateTime toDate)
        {
            NorthwindEntities db = new NorthwindEntities();
            var foundSales = db.Orders
                .Where(o => o.ShipRegion == region 
                    && o.OrderDate > fromDate 
                    && o.OrderDate < toDate)
                .Select(o => new { ShipName = o.ShipName, OrderDate = o.OrderDate });
            foreach (var sale in foundSales)
            {
                Console.WriteLine(sale.ShipName + " - " + sale.OrderDate);
            }
        }
    }
}
