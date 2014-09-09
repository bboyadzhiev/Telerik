namespace Computers.AbstractFactory
{
    using System.Collections.Generic;

    public class Server : AbstractComputer
    {
        public Server(AbstractComputer.ComputerType type, CPU cpu, RAM ram, IEnumerable<HardDrive> hardDrives, VideoCard videoCard, Battery battery, IMotherboard motherBoard)
            : base(type, cpu, ram, hardDrives, videoCard, battery, motherBoard)
        {
        }

        public override void Process(int data)
        {
            this.Ram.SaveRamValue(data);
            this.Cpu.ScquareNumber(this.Ram, this.VideoCard);
        }
    }
}