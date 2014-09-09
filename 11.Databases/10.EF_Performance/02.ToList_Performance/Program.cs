namespace _02.ToList_Performance
{
    using _01.TelerikAcademy_Employees;
    using System;
    using System.Linq;

    internal class Program
    {
        private static void Main(string[] args)
        {
            var tableRowString = "| {0, -27} | {1, -30} | {2, -11} |";
            var tableBar = new String('-', 78);

            // 323 RPC's
            TelerikAcademyEntities ctx = new TelerikAcademyEntities();
            GetEmployeesFromSofiaSlow(tableRowString, tableBar, ctx);

            ctx = new TelerikAcademyEntities();
            // 1 SQL Query ONLY !!!
            GetEmployeesFromSofiaFast(tableRowString, tableBar, ctx);
        }

        private static void GetEmployeesFromSofiaSlow(string tableRowString, string tableBar, TelerikAcademyEntities ctx)
        {
            using (ctx)
            {
                Console.WriteLine("Take it using toList()");
                Console.WriteLine(tableBar);
                Console.WriteLine(tableRowString, "Emplayee Name", "Address", "Town");
                Console.WriteLine(tableBar);

                var employees = ctx.Employees.ToList()
                    .Select(employee => new
                    {
                        Name = employee.FirstName + " " + employee.LastName,
                        Address = employee.Addresses.AddressText,
                        Town = employee.Addresses.Towns.Name,
                    })
                .ToList()
                .Where(x => x.Town == "Sofia")
                .ToList();

                foreach (var employee in employees)
                {
                    Console.WriteLine(tableRowString, employee.Name, employee.Address, employee.Town);
                }
                Console.WriteLine(tableBar);
            }
        }

        private static void GetEmployeesFromSofiaFast(string tableRowString, string tableBar, TelerikAcademyEntities ctx)
        {
            using (ctx)
            {
                Console.WriteLine("Take it FAST");
                Console.WriteLine(tableBar);
                Console.WriteLine(tableRowString, "Emplayee Name", "Address", "Town");
                Console.WriteLine(tableBar);

                var employees = ctx.Employees.Select(employee => new
                {
                    Name = employee.FirstName + " " + employee.LastName,
                    Address = employee.Addresses.AddressText,
                    Town = employee.Addresses.Towns.Name,
                })
                .Where(x => x.Town == "Sofia")
                .AsQueryable();

                foreach (var employee in employees)
                {
                    Console.WriteLine(tableRowString, employee.Name, employee.Address, employee.Town);
                }
                Console.WriteLine(tableBar);
            }
        }
    }
}