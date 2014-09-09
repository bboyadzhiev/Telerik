namespace Computers.AbstractFactory
{
    using System.Collections.Generic;

    public abstract class AbstractComputer
    {
        public AbstractComputer(ComputerType type, CPU cpu, RAM ram, IEnumerable<HardDrive> hardDrives, VideoCard videoCard, IBattery battery, IMotherboard motherBoard)
        {
            this.MachineType = type;
            this.Cpu = cpu;
            this.Ram = ram;
            this.HardDrives = hardDrives;
            //// TODO: BUG was here
            ////if (type != ComputerType.LAPTOP && type != ComputerType.PC)
            ////{
            ////    VideoCard.IsMonochrome = true;
            ////}
            this.VideoCard = videoCard;
            this.Battery = battery;
            this.Motherboard = motherBoard;
        }

        public enum ComputerType
        {
            PC, LAPTOP, SERVER
        }

        public ComputerType MachineType { get; set; }

        public CPU Cpu { get; set; }

        public RAM Ram { get; set; }

        public IEnumerable<HardDrive> HardDrives { get; set; }

        public VideoCard VideoCard { get; set; }

        public IBattery Battery { get; set; }

        public IMotherboard Motherboard { get; set; }

        public virtual void ChargeBattery(int percentage)
        {
        }

        public virtual void Process(int data)
        {
        }

        public virtual void Play(int guessNumber)
        {
        }
    }
}