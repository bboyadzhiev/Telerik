using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.RiskWinsRiskLoses
{
    class Program
    {
        static HashSet<string> visited = new HashSet<string>();
        static Queue<Tuple<string, int>> queue = new Queue<Tuple<string, int>>();
        static void Main(string[] args)
        {
            var startCombination = Console.ReadLine();
            var endCombination = Console.ReadLine();

            var forbiddenCombinationsCount = int.Parse(Console.ReadLine());

            List<string> forbiddenCombinations = new List<string>();

            for (int i = 0; i < forbiddenCombinationsCount; i++)
            {
                //forbiddenCombinations.Add(Console.ReadLine());
                visited.Add(Console.ReadLine());
            }

            //BFS
            // queue <- node
            queue.Enqueue(new Tuple<string, int>(startCombination, 0));

            //visited[node] = true;
            visited.Add(startCombination);

            // while queue not empty
            while (queue.Count > 0)
            {
                // v <- queue
                var current = queue.Dequeue();

                // print v - end combination reached
                if (current.Item1 == endCombination)
                {
                    Console.WriteLine(current.Item2);
                    return;
                }
                var sb = new StringBuilder();
                // foreach child c of v for UP
                for (int i = 0; i < 5; i++)
                {
                    int newDigit = current.Item1[i] - '0';
                    newDigit++;
                    if (newDigit == 10)
                    {
                        newDigit = 0;
                    }

                    //if not visited[c]
                    sb[i] = (char)(newDigit + '0');
                    var node = sb.ToString();

                    if (!visited.Contains(node))
                    {
                        queue.Enqueue(new Tuple<string, int>(node, current.Item2 + 1));
                        visited.Add(node);
                    }
                    sb[i] = current.Item1[i];
                }

                // foreach child c of v for DOWN
                for (int i = 0; i < 5; i++)
                {
                    int newDigit = current.Item1[i] - '0';
                    newDigit--;
                    if (newDigit == -1)
                    {
                        newDigit = 9;
                    }

                    //if not visited[c]
                    sb[i] = (char)(newDigit + '0');
                    var node = sb.ToString();

                    if (!visited.Contains(node))
                    {
                        queue.Enqueue(new Tuple<string, int>(node, current.Item2 + 1));
                        visited.Add(node);
                    }

                    sb[i] = current.Item1[i];
                }
            }

            Console.WriteLine(-1);

            //var count = 0;
            //for (int i = 0; i < startCombination.Length; i++)
            //{
            //    int startDigit = startCombination[i] - '0';
            //    int endDigit = endCombination[i] - '0';

            //    if (startDigit > endDigit)
            //    {
            //        if (Math.Abs(startDigit - endDigit) >= 5)
            //        {
            //            count += endDigit + 10 - startDigit;
            //        }
            //        else
            //        {
            //            count += startDigit - endDigit;
            //        }
            //    }
            //    if (startDigit < endDigit)
            //    {
            //        if (Math.Abs(startDigit - endDigit) >= 5)
            //        {
            //            count += startDigit + 10 - endDigit;
            //        }
            //        else
            //        {
            //            count += endDigit - startDigit;
            //        }
            //    }

            //}
            //Console.WriteLine(count);
        }
    }
}
