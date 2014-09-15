using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.AcademyTasks
{
    class Program
    {
        static List<int> tasks = new List<int>();
        static int variety;
        static int count = int.MaxValue;

        static int bestSolution;
        static void Main(string[] args)
        {
            var pleasantnessInput = Console.ReadLine();
            var pl = pleasantnessInput.Split(',').Select(sValue => sValue.Trim()).ToArray();
            foreach (var item in pl)
            {
                tasks.Add(int.Parse(item));
            }

            variety = int.Parse(Console.ReadLine());

            bestSolution = tasks.Count;
            int currentMin = tasks[0];
            int currentMax = tasks[0];

            int maxIndex = -1;
            for (int i = 0; i < tasks.Count; i++)
            {
                currentMax = Math.Max(currentMax, tasks[i]);
                currentMin = Math.Min(currentMin, tasks[i]);
                if (currentMax-currentMin>=variety)
                {
                    maxIndex = i;
                    break;
                }
            }

            if (maxIndex == -1)
            {
                Console.WriteLine(tasks.Count);
                return;
            }


            Recursion(0, tasks[0], 1);

            Console.WriteLine(count);
        }

        

        static void Recursion(int taskNumber, int threshold, int depth)
        {
            //if (found)
            //{
            //    return;
            //}

            if (taskNumber>= tasks.Count)
            {
                if (count > depth)
                {
                    count = depth;
                }
                return;
            }

            if (Math.Abs(tasks[taskNumber] - threshold) >= variety)
            {
                //Console.WriteLine(depth);
                //found = true;
                if (count > depth)
                {
                    count = depth;
                }
                return;
            }
            if (threshold < tasks[taskNumber])
            {
                threshold = tasks[taskNumber];
            }
            depth++;
            if (taskNumber < tasks.Count)
            {
                Recursion(taskNumber + 1, threshold, depth);
            }
            if (taskNumber < tasks.Count-1)
            {
                Recursion(taskNumber + 2, threshold, depth);
            }
        }
    }
}
