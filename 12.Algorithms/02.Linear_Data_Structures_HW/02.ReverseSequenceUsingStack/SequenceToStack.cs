namespace _02.ReverseSequenceUsingStack
{
    using System;
    using System.Collections.Generic;

    internal class SequenceToStack
    {
        private static void Main(string[] args)
        {
            var input = 0;
            var intSequence = new Stack<int>();
            Console.Write("Enter numbers count (N): ");
            int n = 0;
            int.TryParse(Console.ReadLine(), out n);

            for (int i = 0; i < n; i++)
            {
                Console.Write("Enter integer {0}: ", i);
                if (int.TryParse(Console.ReadLine(), out input))
                {
                    intSequence.Push(input);
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Invalid integer");
                }
            }
            Console.Write("Reversed sequence: ");

            foreach (var item in intSequence)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
    }
}