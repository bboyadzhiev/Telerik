using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{

    public enum CPU
    {
        Xeon,
        Pentium_4,
        Core_i7,
        Opteron,
        Athlon,
        Duron,
        Sempron,
        Celeron
    };

    public enum MotherBoard
	{
	    ASRock,
        ASUS,
        Lenivo,
        MSI,
        Acer,
        Foxconn,
        Unknown,
        ChinaTech,
        SuperMicro
	}

    public abstract class AbstractComputerManufacturer
    {
        public abstract PC MakePC();
        public abstract GamerMachine MakeGamerMachine();
        public abstract ServerMachine MakeServerMachine();

    }
}
