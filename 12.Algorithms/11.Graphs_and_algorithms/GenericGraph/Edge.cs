namespace GenericGraph
{
    using System;

    public class Edge<T, W> where W : IComparable
    {
        public W Weight { get; set; }

        public Node<T, W> Target { get; set; }

        // used for Dijkstra algorithm
        private double dijkstraEdgeDistance;

        public double DijkstraEdgeDistance
        {
            get { return dijkstraEdgeDistance; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Dijkstra distance must be positive or zero!");
                }
                dijkstraEdgeDistance = value;
            }
        }

        public Edge(Node<T, W> target, W weight)
        {
            this.Target = target;
            this.Weight = weight;
        }

        public Edge(Node<T, W> target, double dijkstraDistance, W weight)
            :this(target, weight)
        {
            this.DijkstraEdgeDistance = dijkstraDistance;
        }

        //public Node<T, W> Source { get; set; }
        //public Node<T, W> Destination { get; set; }

        //public Edge(Node<T, W> source, Node<T, W> destination, W weight)
        //{
        //    this.Source = source;
        //    this.Destination = destination;
        //    this.Weight = weight;
        //}
    }
}