using System;

namespace _01.PriorityQueue
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            PriorityQueue<int> priorityQueue = new PriorityQueue<int>();

            priorityQueue.Enqueue(50);
            priorityQueue.Enqueue(25);
            priorityQueue.Enqueue(12);
            priorityQueue.Enqueue(6);
            priorityQueue.Enqueue(17);
            priorityQueue.Enqueue(35);
            priorityQueue.Enqueue(100);
            priorityQueue.Enqueue(75);
            priorityQueue.Enqueue(85);
            priorityQueue.Enqueue(125);
            priorityQueue.Enqueue(4);

            foreach (var item in priorityQueue)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("Dequeueing {0}", priorityQueue.Dequeue());
            Console.WriteLine("Dequeueing {0}", priorityQueue.Dequeue());
            Console.WriteLine("Dequeueing {0}", priorityQueue.Dequeue());

            foreach (var item in priorityQueue)
            {
                Console.WriteLine(item);
            }
        }
    }
}