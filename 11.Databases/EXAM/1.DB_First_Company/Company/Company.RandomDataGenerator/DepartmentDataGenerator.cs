namespace Company.RandomDataGenerator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Company.Data;
    internal class DepartmentDataGenerator :DataGenerator, IDataGenerator
    {
      
        public DepartmentDataGenerator(IRandomDataGenerator randomDataGenerator, CompanyEntities companyEntities, int count)
            :base(randomDataGenerator, companyEntities, count)
        {
        }

        public override void Generate()
        {
            Console.WriteLine("Adding Departments started ...");
            var departmentsToBeAdded = new HashSet<string>();

            while (departmentsToBeAdded.Count != this.Count)
            {
                departmentsToBeAdded.Add(this.Random.GetRandomStringWithRandomLength(10, 50));
            }
            int index = 0;
            foreach (var departmenName in departmentsToBeAdded)
            {
                var department = new Department
                {
                    Name = departmenName
                };
                this.Database.Departments.Add(department);

                if (index % 25 == 0)
                {
                    Console.WriteLine("Saving {0}th department", index);
                    this.Database.SaveChanges();
                }
                index++;
            }
            Console.WriteLine("Departments adding completed!");           
        }
    }
}
