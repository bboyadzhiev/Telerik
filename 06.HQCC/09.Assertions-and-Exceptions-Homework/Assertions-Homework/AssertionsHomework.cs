using System;
using System.Linq;
using System.Diagnostics;

class AssertionsHomework
{
    public static void SelectionSort<T>(T[] arr) where T : IComparable<T>
    {
        Debug.Assert(arr != null, "Fatal Error: The array cannot be null!");
        Debug.Assert(arr.Length > 1, "Fatal Error: The array contains too few elements!");
        for (int index = 0; index < arr.Length-1; index++)
        {
            int minElementIndex = FindMinElementIndex(arr, index, arr.Length - 1);
            Swap(ref arr[index], ref arr[minElementIndex]);
        }
    }
  
    private static int FindMinElementIndex<T>(T[] arr, int startIndex, int endIndex) 
        where T : IComparable<T>
    {
        
        Debug.Assert(arr != null, "Fatal Error: The array cannot be null!");
        Debug.Assert(startIndex <= arr.Length - 1, "Fatal Error: startIndex is outside array boudaries");
        Debug.Assert(endIndex <= arr.Length - 1, "Fatal Error: endIndex is outside array boudaries");
        Debug.Assert(startIndex < endIndex, "Fatal Error: startIndex must b before endIndex");
        Debug.Assert(startIndex >= 0, "Fatal Error: startIndex must be positive integer");
        Debug.Assert(endIndex >= 0, "Fatal Error: endIndex must be positive imteger");
        
        int minElementIndex = startIndex;
        for (int i = startIndex + 1; i <= endIndex; i++)
        {
            if (arr[i].CompareTo(arr[minElementIndex]) < 0)
            {
                minElementIndex = i;
            }
        }
        return minElementIndex;
    }

    private static void Swap<T>(ref T x, ref T y)
    {
        T oldX = x;
        x = y;
        y = oldX;
    }

    public static int BinarySearch<T>(T[] arr, T value) where T : IComparable<T>
    {
        Debug.Assert(arr != null, "Fatal Error: The array cannot be null!");
        Debug.Assert(arr.Length > 1, "Fatal Error: The array contains too few elements!");
        Debug.Assert(arr.SequenceEqual(arr.OrderBy(x => x).ToArray()), "Fatal Error: Unsorted array!");

        return BinarySearch(arr, value, 0, arr.Length - 1);
    }

    private static int BinarySearch<T>(T[] arr, T value, int startIndex, int endIndex) 
        where T : IComparable<T>
    {
        // null and length are cheked by the public method
        Debug.Assert(startIndex <= arr.Length - 1, "Fatal Error: startIndex is outside array boudaries");
        Debug.Assert(endIndex <= arr.Length - 1, "Fatal Error: endIndex is outside array boudaries");
        Debug.Assert(startIndex < endIndex, "Fatal Error: startIndex must be before endIndex");
        Debug.Assert(startIndex >= 0, "Fatal Error: startIndex must be positive integer");
        Debug.Assert(endIndex >= 0, "Fatal Error: endIndex must be positive integer");

        while (startIndex <= endIndex)
        {
            int midIndex = (startIndex + endIndex) / 2;
            if (arr[midIndex].Equals(value))
            {
                return midIndex;
            }
            if (arr[midIndex].CompareTo(value) < 0)
            {
                // Search on the right half
                startIndex = midIndex + 1;
            }
            else 
            {
                // Search on the right half
                endIndex = midIndex - 1;
            }
        }

        // Searched value not found
        return -1;
    }

    static void Main()
    {
        int[] arr = new int[] { 3, -1, 15, 4, 17, 2, 33, 0 };
        Console.WriteLine("arr = [{0}]", string.Join(", ", arr));
        SelectionSort(arr);
        Console.WriteLine("sorted = [{0}]", string.Join(", ", arr));

        SelectionSort(new int[0]); // Test sorting empty array
        SelectionSort(new int[1]); // Test sorting single element array

        Console.WriteLine(BinarySearch(arr, -1000));
        Console.WriteLine(BinarySearch(arr, 0));
        Console.WriteLine(BinarySearch(arr, 17));
        Console.WriteLine(BinarySearch(arr, 10));
        Console.WriteLine(BinarySearch(arr, 1000));
    }
}
