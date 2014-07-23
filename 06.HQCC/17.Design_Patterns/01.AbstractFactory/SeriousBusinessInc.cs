using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    public class SeriousBusinessInc : AbstractComputerManufacturer
    {
        public override PC MakePC()
        {
            return new PC(CPU.Pentium_4, MotherBoard.MSI, "Office Station", 1024);
        }

        public override GamerMachine MakeGamerMachine()
        {
            return new GamerMachine(CPU.Opteron, MotherBoard.Foxconn, "Gamer X", 4096);
        }

        public override ServerMachine MakeServerMachine()
        {
            return new ServerMachine(CPU.Xeon, MotherBoard.SuperMicro, "Bring it ON!", 8192);
        }
    }
}
