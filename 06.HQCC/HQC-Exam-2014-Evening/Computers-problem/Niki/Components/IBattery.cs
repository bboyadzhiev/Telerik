namespace Computers
{
    public interface IBattery
    {
        int Percentage { get; set; }

        void Charge(int newPercentage);
    }
}