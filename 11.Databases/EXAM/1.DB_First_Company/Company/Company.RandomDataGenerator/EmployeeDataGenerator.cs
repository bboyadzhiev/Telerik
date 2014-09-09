namespace Company.RandomDataGenerator
{
    using Company.Data;
    using System;
    using System.Linq;

    internal class EmployeeDataGenerator : DataGenerator, IDataGenerator
    {
        public EmployeeDataGenerator(IRandomDataGenerator randomDataGenerator, CompanyEntities companyEntities, int count)
            : base(randomDataGenerator, companyEntities, count)
        {
        }

        public override void Generate()
        {
            var departments = this.Database.Departments.Select(d => d.Id).ToList();

            Console.WriteLine("Adding Employees started ...");
            for (int i = 0; i < this.Count; i++)
            {
                int? managerId = null;
                if (i >= 2 && i <= this.Count * 0.95)
                {
                    managerId = i - 1;
                }
                else
                {
                    managerId = null;
                }

                var employee = new Employee
                {
                    DepartmentId = departments[this.Random.GetRandomNumber(0, departments.Count - 1)],
                    FirstName = this.Random.GetRandomStringWithRandomLength(5, 20),
                    LastName = this.Random.GetRandomStringWithRandomLength(5, 20),
                    YearlySalary = this.Random.GetRandomNumber(50000, 200000),
                    ManagerId = managerId
                };

                var projects = this.Database.Projects.Select(d => d.Id).ToList();

                this.Database.Employees.Add(employee);
                if (i % 100 == 0)
                {
                    Console.WriteLine("Saving {0}th employee", i);
                    Database.SaveChanges();
                }
            }
            Console.WriteLine("Employees adding completed!");
        }
    }
}