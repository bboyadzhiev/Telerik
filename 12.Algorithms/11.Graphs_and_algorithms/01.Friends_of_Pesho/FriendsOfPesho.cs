namespace _01.Friends_of_Pesho
{
    using System;
    using System.Collections.Generic;
    using GenericGraph;

    public class FriendsOfPesho
    {
        private static void Main(string[] args)
        {
            var mapInfo = Console.ReadLine().Split(' ');
            int n, m, h;
            int.TryParse(mapInfo[0], out n);
            int.TryParse(mapInfo[1], out m);
            int.TryParse(mapInfo[2], out h);

            var hospitals = Console.ReadLine().Split(' ');

            var graph = new Graph<int, int>();
            var hospitalsList = new List<int>();

            for (int i = 0; i < h; i++)
            {
                int hospitalNodeValue;
                int.TryParse(hospitals[i], out hospitalNodeValue);
                hospitalsList.Add(hospitalNodeValue);
            }

            for (int i = 0; i < m; i++)
            {
                int f, s, d;
                var roadInfo = Console.ReadLine().Split(' ');
                int.TryParse(roadInfo[0], out f);
                int.TryParse(roadInfo[1], out s);
                int.TryParse(roadInfo[2], out d);

                if (!graph.Nodes.ContainsKey(f))
                {
                    graph.AddNode(new Node<int, int>(f));
                }

                if (!graph.Nodes.ContainsKey(s))
                {
                    graph.AddNode(new Node<int, int>(s));
                }

                graph.Nodes[f].AddConnection(graph.Nodes[s], d, 0, true);
            }

            var distances = new SortedSet<double>();
            foreach (var hospital in hospitalsList)
            {
                var currentHospitalNode = graph.Nodes[hospital];
                Dijkstra<int, int>.DijkstraAlgorithm(graph, currentHospitalNode);
                var journey = 0.0d;
                foreach (var home in graph.Nodes.Keys)
                {
                    if (!hospitalsList.Contains(home))
                    {
                        //Console.WriteLine("Hospital {0} - home {1}, distance: {2}", hospital, home, graph.Nodes[home].DijkstraDistance);
                        journey = journey + graph.Nodes[home].DijkstraDistance;
                    }
                }
                distances.Add(journey);
            }
            Console.WriteLine(distances.Min);
        }
    }
}