namespace _01.Northwind_DbContext
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Program
    {
        static void Main()
        {
            //NorthwindEntities db = new NorthwindEntities();
            //NorthwindDAO dao = new NorthwindDAO(db);
            //2. Create a DAO class with static methods which provide functionality for 
            //   inserting, modifying and deleting customers. Write a testing class.
            //Insert
           // NorthwindDAO.InsertCustomer("NCIC", "New Company Inc.", "Sofia");
            //Delete
            NorthwindDAO.DeleteCustomer("NCIC");
            //Insert again
            NorthwindDAO.InsertCustomer("NCIC", "New Company Inc.", "Sofia");
            //Modify
            NorthwindDAO.ModifyCustomer("NCIC", "Northwind Company Inc.", "New York");
          
            // 3. Write a method that finds all customers who have orders made in 1997 and shipped to Canada.
            NorthwindDAO.FindByOrder(1997, "Canada");
          
            // 4. Implement previous by using native SQL query and executing it through the DbContext.
            Console.WriteLine();
            NorthwindDAO.FindByOrderUsingSQL(1997, "Canada");
          
            // 5. Write a method that finds all the sales by specified region and period (start / end dates).
            Console.WriteLine();
            NorthwindDAO.FindSales("WA", new DateTime(1997, 01, 01), new DateTime(1997, 06, 06));

        }
    }
}
