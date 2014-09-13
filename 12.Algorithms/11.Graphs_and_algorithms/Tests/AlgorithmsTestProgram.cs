namespace Tests
{
    using GenericGraph;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    class AlgorithmsTestProgram
    {
        static void Main(string[] args)
        {
            var node0 = new Node<int, int>(0);
            var node1 = new Node<int, int>(1);
            var node2 = new Node<int, int>(2);
            var node3 = new Node<int, int>(3);
            var node4 = new Node<int, int>(4);
            var node5 = new Node<int, int>(5);
            

            var nodes = new List<Node<int, int>> { node0, node1, node2, node3, node4, node5 };

            var graph = new Graph<int, int>();
            foreach (var node in nodes)
            {
                graph.AddNode(node);
            }
            graph.Nodes[node1.Value].AddConnection(node0, 0, 0, false);
            graph.Nodes[node1.Value].AddConnection(node5, 0, 0, false);
            graph.Nodes[node1.Value].AddConnection(node2, 0, 0, false);

            graph.Nodes[node2.Value].AddConnection(node0, 0, 0, false);
            graph.Nodes[node2.Value].AddConnection(node5, 0, 0, false);

            graph.Nodes[node4.Value].AddConnection(node2, 0, 0, false);
            
            graph.Nodes[node5.Value].AddConnection(node0, 0, 0, false);
            graph.Nodes[node5.Value].AddConnection(node3, 0, 0, false);
            

            Node<int, int> source = node1;

            //Dijkstra<int, int>.DijkstraAlgorithm(graph, source);
            //
            //for (int i = 0; i < nodes.Count; i++)
            //{
            //    Console.Write("Distance from {0} to {1} ", source.Value, i);
            //    Console.WriteLine(nodes[i].DijkstraDistance);
            //}

        }
    }
}
