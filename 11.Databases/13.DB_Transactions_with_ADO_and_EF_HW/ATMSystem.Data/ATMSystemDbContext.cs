namespace ATMSystem.Data
{
    using ATMSystem.Model;
    using System.Data.Entity;

    public class ATMSystemDbContext : DbContext
    {

        public ATMSystemDbContext()
            : base("name=ATM_DEFAULT")
        {

        }
        public ATMSystemDbContext(string connectionString)
            : base("name=ATM_DEFAULT")
        {
            this.Database.Connection.ConnectionString = connectionString;
        }
        public IDbSet<CardAccount> CardAccounts { get; set; }
    }
}