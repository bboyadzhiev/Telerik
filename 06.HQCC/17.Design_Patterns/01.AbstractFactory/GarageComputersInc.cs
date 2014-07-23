using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    public class GarageComputersInc : AbstractComputerManufacturer
    {
        public override PC MakePC()
        {
            return new PC(CPU.Celeron, MotherBoard.Unknown, "Cheepy PC", 512);
        }

        public override GamerMachine MakeGamerMachine()
        {
            return new GamerMachine(CPU.Duron, MotherBoard.ASRock, "N00b Gamer", 2048);
        }

        public override ServerMachine MakeServerMachine()
        {
            return new ServerMachine(CPU.Pentium_4, MotherBoard.ChinaTech, "Don't Restart it!", 4096);
        }
    }
}
