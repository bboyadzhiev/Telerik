using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            var localGarageComputers = new GarageComputersInc();
            var crappyPCDistriputor = new ComputerSellingCompany(localGarageComputers);
            var crappyPC = crappyPCDistriputor.BuyPC();

            Console.WriteLine(crappyPC.GetDescription);
            Console.WriteLine();
            var seriousManufacturer = new SeriousBusinessInc();
            var seriousDistripbutor = new ComputerSellingCompany(seriousManufacturer);
            var superServer = seriousDistripbutor.BuyServerMachine();
            Console.WriteLine(superServer.GetDescription);
        }
    }
}
