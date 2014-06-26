//2. Refactor the following code to apply variable usage and naming best practices:
using System;

public class Printer
{
    /// <summary>
    /// Prints a statistical value
    /// </summary>
    /// <param name="statisticalData">The statistical data that is to be processed</param>
    /// <param name="recordsCount">The number of records that are to be processed</param>
    public void PrintStatistics(double[] statisticalData, int recordsCount)
    {
        double maximalValue = Double.MinValue;
        for (int i = 0; i < recordsCount; i++)
        {
            if (statisticalData[i] > maximalValue)
            {
                maximalValue = statisticalData[i];
            }
        }
        PrintMaxValue(maximalValue);

        double minimalValue = Double.MaxValue;
        for (int i = 0; i < recordsCount; i++)
        {
            if (statisticalData[i] < minimalValue)
            {
                minimalValue = statisticalData[i];
            }
        }
        PrintMinValue(minimalValue);

        double partialData = 0;
        for (int i = 0; i < recordsCount; i++)
        {
            partialData += statisticalData[i];
        }
        double averageValue = partialData / recordsCount;
        PrintAvgValue(averageValue);
    }

}