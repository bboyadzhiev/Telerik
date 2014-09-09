namespace Cars.Data
{
    using Cars.Data.Migrations;
    using Cars.Models;
    using System.Data.Entity;

    public class CarsDBContext : DbContext
    {
        public CarsDBContext()
            : base("Cars_SQLEXPRESS")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<CarsDBContext, Configuration>());
        }

        public CarsDBContext(string connectionString)
            : base("Cars_SQLEXPRESS")
        {
            this.Database.Connection.ConnectionString = connectionString;
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<CarsDBContext, Configuration>());
        }

        public IDbSet<City> Cities { get; set; }

        public IDbSet<Manufacturer> Manufacturers { get; set; }

        public IDbSet<Dealer> Dealers { get; set; }

        public IDbSet<Car> Cars { get; set; }
    }
}