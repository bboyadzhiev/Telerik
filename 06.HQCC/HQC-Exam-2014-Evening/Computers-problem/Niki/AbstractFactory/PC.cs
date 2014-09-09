namespace Computers.AbstractFactory
{
    using System.Collections.Generic;

    public class PC : AbstractComputer
    {
        public PC(AbstractComputer.ComputerType type, CPU cpu, RAM ram, IEnumerable<HardDrive> hardDrives, VideoCard videoCard, Battery battery, IMotherboard motherBoard)
            : base(type, cpu, ram, hardDrives, videoCard, battery, motherBoard)
        {
        }

        public override void Play(int guessNumber)
        {
            this.Cpu.GenerateRandomInteger(1, 10, this.Ram);
            var generatedNuber = Ram.LoadRamValue();
            if (generatedNuber + 1 != guessNumber + 1)
            {
                this.VideoCard.DrawOnVideoCard(string.Format("You didn't guess the number {0}.", generatedNuber));
            }
            else
            {
                this.VideoCard.DrawOnVideoCard("You win!");
            }
        }
    }
}