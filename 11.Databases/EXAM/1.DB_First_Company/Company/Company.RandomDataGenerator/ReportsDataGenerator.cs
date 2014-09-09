namespace Company.RandomDataGenerator
{
    using Company.Data;
    using System;
    using System.Linq;

    internal class ReportsDataGenerator : DataGenerator, IDataGenerator
    {
        public ReportsDataGenerator(IRandomDataGenerator randomDataGenerator, CompanyEntities companyEntities, int count)
            : base(randomDataGenerator, companyEntities, count)
        {
        }

        public override void Generate()
        {
            var employees = this.Database.Employees.Select(e => e.Id).ToList();

            Console.WriteLine("Reports adding started ... ");

            for (int i = 0; i < this.Count; i++)
            {
                DateTime date = DateTime.Now.AddDays(this.Random.GetRandomNumber(1, 100));
                var report = new Report
                {
                    EmployeeId = employees[this.Random.GetRandomNumber(0, employees.Count - 1)],
                    Time = date
                };

                this.Database.Reports.Add(report);
                if (i % 100 == 0)
                {
                    Console.WriteLine("Saving {0}th report", i);
                    Database.SaveChanges();
                }
            }
            Console.WriteLine("Reports adding FINISHED");
        }
    }
}