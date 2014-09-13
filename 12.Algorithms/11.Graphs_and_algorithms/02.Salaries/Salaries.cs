namespace _02.Salaries
{
    using System;
    using System.Collections.Generic;
    using GenericGraph;

    internal class Salaries
    {
        private static HashSet<int> vizited = new HashSet<int>();

        private static void Main(string[] args)
        {
            var graph = new Graph<int, int>();

            var employeesCount = 0;
            int.TryParse(Console.ReadLine(), out employeesCount);

            for (int i = 0; i < employeesCount; i++)
            {
                graph.AddNode(new Node<int, int>(i));
            }

            for (int i = 0; i < employeesCount; i++)
            {
                var row = Console.ReadLine();
                for (int j = 0; j < employeesCount; j++)
                {
                    if (row[j] == 'Y')
                    {
                        graph.Nodes[i].AddConnection(graph.Nodes[j], 0, false);
                    }
                }
            }

            long sum = 0;
            for (int i = 0; i < employeesCount; i++)
            {
                DefineSalary(graph.Nodes[i]);
            }

            foreach (var employer in graph.Nodes.Values)
            {
                sum += employer.Data;
            }
            Console.WriteLine(sum);
        }

        private static void DefineSalary(Node<int, int> employer)
        {
            if (vizited.Contains(employer.Value))
            {
                return;
            }

            vizited.Add(employer.Value);

            if (employer.Connections.Count == 0)
            {
                employer.Data = 1;
                return;
            }

            foreach (var e in employer.Connections)
            {
                DefineSalary(e.Target);
                employer.Data += e.Target.Data;
            }
        }
    }
}