using ATMSystem.Data;
using ATMSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace ATMSystem.ConsoleClient
{
    public class ATMConsoleClient
    {
        static void Main(string[] args)
        {
            //var sqlServerPath = @".";
            //var sqlServerPath = @"(localdb)\v11.0";
            var sqlServerPath = @".\SQLEXPRESS";
            var connectionString = @"Data Source=" + sqlServerPath + @";Initial Catalog=ATM_DB;Integrated Security=True";

            Console.WriteLine("Connecting to SQL Server at " + sqlServerPath);
            Console.WriteLine("PLEASE CHANGE IF NEEDED");
            Console.WriteLine();

            try
            {
                // Console.Write("Withdrawing $200 from account n.1000000010: ");
                // var invalid = CardAccountService.WithdrawCash("1000000010", "1010", 200, connectionString);
                // Console.WriteLine("got ${0}", invalid);

                //var changesResult = CardAccountService.AddSampleData(connectionString);
                //Console.WriteLine("Added {0} accounts", changesResult);


                Console.Write("Withdrawing $200 from account n.1000000010: ");
                var success = CardAccountService.WithdrawCash("1000000010", "1010", 200, connectionString);
                Console.WriteLine("got ${0}", success);
                Console.WriteLine();

                Console.Write("Checking account n.1000000010: ");
                var cash = CardAccountService.CashCheck("1000000010", "1010", connectionString);
                Console.WriteLine("Account has ${0}", cash);
                Console.WriteLine();

                Console.Write("Withdrawing $2000 from account n.1000000010: ");
                var error = CardAccountService.WithdrawCash("1000000010", "1010", 2000, connectionString);
                Console.WriteLine("got ${0}", error);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("----");
            }
        }
    }
}
