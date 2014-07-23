using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    public abstract class AbstractComputer
    {
        protected CPU cpu;
        protected MotherBoard motherBoard;
        protected int ram;

        public AbstractComputer(CPU cpu, MotherBoard motherBoard, int ram)
        {
            this.cpu = cpu;
            this.motherBoard = motherBoard;
            this.ram = ram;
        }
      public abstract string GetDescription
      {
          get;
      }
    }
}
