namespace Computers.Components
{
    public interface ICPU
    {
        void ScquareNumber(RAM ram, VideoCard videoCard);

        void GenerateRandomInteger(int minValue, int maxValue, RAM ram);
    }
}