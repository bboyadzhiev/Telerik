namespace GenericGraph
{
    using System;
    using System.Collections.Generic;

    public class Node<T, W> : IComparable where W : IComparable
    {
        public T Value { get; set; }

        public IList<Edge<T, W>> Connections;

        // used for Dijkstra algorithm
        private double dijkstraDistance;

        public T Data { get; set; }

        public double DijkstraDistance
        {
            get { return dijkstraDistance; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Dijkstra distance must be positive or zero!");
                }
                dijkstraDistance = value;
            }
        }

        public Node(T value)
        {
            this.Value = value;
            this.Connections = new List<Edge<T, W>>();
        }

        public void AddConnection(Node<T, W> targetNode, W weight, bool isBidirectional)
        {
            this.AddConnection(targetNode, 0, weight, isBidirectional);
        }

        public void AddConnection(Node<T, W> targetNode, double dijkstraDistance, W weight, bool isBidirectional)
        {
            if (targetNode == null)
            {
                throw new ArgumentNullException("targetNode");
            }
            if (targetNode == this)
            {
                throw new ArgumentException("Node may not connect to itself.");
            }
            this.Connections.Add(new Edge<T, W>(targetNode, dijkstraDistance, weight));
            if (isBidirectional)
            {
                targetNode.AddConnection(this, dijkstraDistance, weight, false);
            }
        }

        public int CompareTo(object obj)
        {
            if (!(obj is Node<T, W>))
            {
                return -1;
            }

            return this.DijkstraDistance.CompareTo((obj as Node<T, W>).DijkstraDistance);
        }
    }
}