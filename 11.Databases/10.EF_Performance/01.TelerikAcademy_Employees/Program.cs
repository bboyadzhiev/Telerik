namespace _01.TelerikAcademy_Employees
{
    using System;

    internal class Program
    {
        private static void Main(string[] args)
        {
            var tableRowString = "| {0, -27} | {1, -27} | {2, -14} |";
            var tableBar = new String('-', 79);
            TelerikAcademyEntities ctx = new TelerikAcademyEntities();

            // 1 SQL Query + 338 RPC Calls !!!
            GetEmployeesSlow(tableRowString, tableBar, ctx);

            Console.WriteLine("Now press any key to take it FAST");
            Console.Read();

            ctx = new TelerikAcademyEntities();
            // 1 SQL Query + only 13 RPC Calls !!!
            GetEmployeesFast(tableRowString, tableBar, ctx);
        }

        private static void GetEmployeesSlow(string tableRowString, string tableBar, TelerikAcademyEntities ctx)
        {
            Console.WriteLine("Take it SLOW");
            using (ctx)
            {
                Console.WriteLine(tableBar);
                Console.WriteLine(tableRowString, "Emplayee Name", "Department", "Town");
                Console.WriteLine(tableBar);
                foreach (var employee in ctx.Employees)
                {
                    Console.WriteLine(tableRowString, employee.FirstName + " " + employee.LastName, employee.Departments1.Name, employee.Addresses.Towns.Name);
                }
                Console.WriteLine(tableBar);
            }
        }

        private static void GetEmployeesFast(string tableRowString, string tableBar, TelerikAcademyEntities ctx)
        {
            using (ctx)
            {
                Console.WriteLine("Take it FAST");
                Console.WriteLine(tableBar);
                Console.WriteLine(tableRowString, "Emplayee Name", "Department", "Town");
                Console.WriteLine(tableBar);
                foreach (var employee in ctx.Employees.Include("Departments").Include("Addresses.Towns"))
                {
                    Console.WriteLine(tableRowString, employee.FirstName + " " + employee.LastName, employee.Departments1.Name, employee.Addresses.Towns.Name);
                }
                Console.WriteLine(tableBar);
            }
        }
    }
}