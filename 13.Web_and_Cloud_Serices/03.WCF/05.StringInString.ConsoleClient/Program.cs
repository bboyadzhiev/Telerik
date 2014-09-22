using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _05.StringInString.ConsoleClient.ServiceReferenceStringInString;

namespace _05.StringInString.ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            StringInStringClient client = new StringInStringClient();

            var result = client.GetOccuranceCount("task", "task1, task2, task3, task4");
            Console.WriteLine(result);
            Console.ReadLine();

        }
    }
}
