// 3. Refactor the following loop: 
using System;

class Program
{
    static void Main()
    {
        for (int i = 0; i < 100; i++)
        {
            Console.WriteLine(array[i]);

            if ((i % 10 == 0) && (array[i] == expectedValue))
            {
                bool expectedValueFound = true;
                break;
            }
        }

        // More code here

        if (expectedValueFound)
        {
            Console.WriteLine("Value Found");
        }
    }
}

