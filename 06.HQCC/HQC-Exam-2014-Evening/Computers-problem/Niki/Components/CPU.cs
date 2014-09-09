namespace Computers
{
    using System;

    public class CPU
    {
        public readonly byte NumberOfBits;

        private static readonly Random Random = new Random();

        public CPU(byte numberOfCores, byte numberOfBits)
        {
            this.NumberOfBits = numberOfBits;
            this.NumberOfCores = numberOfCores;
        }

        private byte NumberOfCores { get; set; }

        public void ScquareNumber(RAM ram, VideoCard videoCard)
        {
            var storedData = ram.LoadRamValue();
            if (storedData < 0)
            {
                videoCard.DrawOnVideoCard("Number too low.");
            }
            else if ((storedData > 500 && this.NumberOfBits == 32)
                    || (storedData > 1000 && this.NumberOfBits == 64)
                    || (storedData > 2000 && this.NumberOfBits == 128))
            {
                videoCard.DrawOnVideoCard("Number too high.");
            }
            else
            {
                int value = 0;
                for (int i = 0; i < storedData; i++)
                {
                    value += storedData;
                }

                videoCard.DrawOnVideoCard(string.Format("Square of {0} is {1}.", storedData, value));
            }
        }

        public void GenerateRandomInteger(int minValue, int maxValue, RAM ram)
        {
            int randomNumber;
            do
            {
                randomNumber = Random.Next(0, 1000);
            }
            while (!(randomNumber >= minValue && randomNumber <= maxValue));
            ram.SaveRamValue(randomNumber);
        }
    }
}