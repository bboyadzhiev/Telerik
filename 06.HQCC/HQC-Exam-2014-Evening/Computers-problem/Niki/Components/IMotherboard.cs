namespace Computers
{
    /// <summary>
    /// Describes the required methods for communication with the RAM and the Video Card.
    /// </summary>
    public interface IMotherboard
    {
        /// <summary>
        /// Gets the stored value in the rRAM.
        /// </summary>
        /// <returns>The stored value.</returns>
        int LoadRamValue();

        /// <summary>
        /// Sets the value of the RAM.
        /// </summary>
        /// <param name="value">The value to be stored.</param>
        void SaveRamValue(int value);

        /// <summary>
        /// Draws text data on the video card.
        /// </summary>
        /// <param name="data">The data to be dwawn.</param>
        void DrawOnVideoCard(string data);
    }
}