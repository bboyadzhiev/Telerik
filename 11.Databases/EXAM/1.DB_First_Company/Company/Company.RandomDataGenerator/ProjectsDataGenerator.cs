namespace Company.RandomDataGenerator
{
    using Company.Data;
    using System;

    internal class ProjectsDataGenerator : DataGenerator, IDataGenerator
    {
        public ProjectsDataGenerator(IRandomDataGenerator randomDataGenerator, CompanyEntities companyEntities, int count)
            : base(randomDataGenerator, companyEntities, count)
        {
        }

        public override void Generate()
        {
            Console.WriteLine("Adding Projects started ...");
            for (int i = 0; i < this.Count; i++)
            {
                var project = new Project
                {
                    Name = this.Random.GetRandomStringWithRandomLength(5, 50),
                    
                };

                this.Database.Projects.Add(project);
                if (i % 100 == 0)
                {
                    Console.WriteLine("Saving {0}th project", i);
                    Database.SaveChanges();
                }
            }
            Console.WriteLine("Projects adding completed!");
        }
    }
}