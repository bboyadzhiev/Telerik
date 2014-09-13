namespace GenericGraph
{
    using System;

    public class Dijkstra<T, W> where W : IComparable
    {
        public static void DijkstraAlgorithm(Graph<T, W> graph, Node<T, W> source)
        {
            var queue = new PriorityQueue<Node<T, W>>();

            foreach (var node in graph.Nodes)
            {
                node.Value.DijkstraDistance = double.PositiveInfinity;
            }

            source.DijkstraDistance = 0.0d;
            queue.Enqueue(source);

            while (queue.Count != 0)
            {
                var currentNode = queue.Dequeue();

                if (double.IsPositiveInfinity(currentNode.DijkstraDistance))
                {
                    break;
                }

                foreach (var neighbor in graph.Nodes[currentNode.Value].Connections)
                {
                    var potDistance = currentNode.DijkstraDistance + neighbor.DijkstraEdgeDistance;
                    if (potDistance < neighbor.Target.DijkstraDistance)
                    {
                        neighbor.Target.DijkstraDistance = potDistance;
                        queue.Enqueue(neighbor.Target);
                    }
                }
            }
        }
    }
}