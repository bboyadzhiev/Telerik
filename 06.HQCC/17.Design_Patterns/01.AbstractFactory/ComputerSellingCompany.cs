using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    public class ComputerSellingCompany
    {
        private AbstractComputerManufacturer manufacturer;

        public ComputerSellingCompany(AbstractComputerManufacturer pcManufacturer)
        {
            manufacturer = pcManufacturer;
        }

        public PC BuyPC()
        {
            return manufacturer.MakePC();
        }

        public GamerMachine BuyGamerMachine()
        {
            return manufacturer.MakeGamerMachine();
        }

        public ServerMachine BuyServerMachine()
        {
            return manufacturer.MakeServerMachine();
        }
    }
}
