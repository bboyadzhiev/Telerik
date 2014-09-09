namespace Computers
{
    public class RAM : IMotherboard
    {
        private int storedValue;

        public RAM(int amount)
        {
            this.Amount = amount;
        }

        public int Amount { get; set; }

        public void SaveRamValue(int newValue)
        {
            this.storedValue = newValue;
        }

        public int LoadRamValue()
        {
            return this.storedValue;
        }

        public void DrawOnVideoCard(string data)
        {
            throw new System.NotImplementedException();
        }
    }
}