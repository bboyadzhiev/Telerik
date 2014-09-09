namespace Computers.AbstractFactory
{
    using System.Collections.Generic;

    public class Laptop : AbstractComputer
    {
        public Laptop(AbstractComputer.ComputerType type, CPU cpu, RAM ram, IEnumerable<HardDrive> hardDrives, VideoCard videoCard, IBattery battery, IMotherboard motherBoard)
            : base(type, cpu, ram, hardDrives, videoCard, battery, motherBoard)
        {
        }

        public override void ChargeBattery(int percentage)
        {
            this.Battery.Charge(percentage);
            this.VideoCard.DrawOnVideoCard(string.Format("Battery status: {0} %", this.Battery.Percentage));
        }
    }
}