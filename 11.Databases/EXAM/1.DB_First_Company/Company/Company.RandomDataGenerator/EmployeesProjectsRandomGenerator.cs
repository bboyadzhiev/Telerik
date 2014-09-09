namespace Company.RandomDataGenerator
{
    using Company.Data;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class EmployeesProjectsRandomGenerator : DataGenerator, IDataGenerator
    {
        public EmployeesProjectsRandomGenerator(IRandomDataGenerator randomDataGenerator, CompanyEntities companyEntities, int count)
            : base(randomDataGenerator, companyEntities, count)
        {
        }

        public override void Generate()
        {
            var employees = this.Database.Employees.Select(e => e.Id).ToList();
            var projects = this.Database.Projects.Select(p => p.Id).ToList();

            Console.WriteLine("EmployeesProjects adding started ... ");
            var index = 0;
            foreach (var project in projects)
            {
                var employeesToSkip = new List<int>();
                var employeesIdList = new List<int>();
                for (int i = 0; i < this.Random.GetRandomNumber(2, 20); i++)
                {
                    var emp = employees[this.Random.GetRandomNumber(0, employees.Count - 1)];
                    if (employeesToSkip.Contains(emp))
                    {
                        i = i - 1;
                        continue;
                    }
                    employeesIdList.Add(emp);
                    employeesToSkip.Add(emp);
                }

                foreach (var employeeId in employeesIdList)
                {
                    DateTime date = DateTime.Now.AddDays(this.Random.GetRandomNumber(1, 100));
                    var employeeProject = new EmployeesProject
                    {
                        ProjectId = project,
                        EmployeeId = employeeId,
                        StartDate = date,
                        EndDate = date.AddDays(this.Random.GetRandomNumber(1, 10))
                    };
                    this.Database.EmployeesProjects.Add(employeeProject);

                    if (index % 100 == 0)
                    {
                        this.Database.SaveChanges();
                        Console.WriteLine("EmployeeProject {0} added", index);
                    }
                    index++;
                }
                
                
            }
            Console.WriteLine("EmployeesProjects adding FINISHED");
        }
    }
}