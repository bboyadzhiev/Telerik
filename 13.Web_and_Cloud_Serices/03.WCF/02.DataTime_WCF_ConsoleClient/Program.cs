using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _02.DataTime_WCF_ConsoleClient.ServiceReference1;

namespace _02.DataTime_WCF_ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTimeServiceClient client = new DateTimeServiceClient();
            var result = client.GetDayOfWeek(DateTime.Now);
            Console.WriteLine("Днес е {0}!",result);
            Console.ReadLine();
        }
    }
}
