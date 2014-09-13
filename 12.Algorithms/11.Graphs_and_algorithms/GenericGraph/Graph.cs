namespace GenericGraph
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Graph<T, W> where W : IComparable
    {
        public IDictionary<T, Node<T, W>> Nodes { get; set; }
        private HashSet<T> visited;
        public List<T> SortedElements;
        public int recursionDepth;        

        public Graph()
        {
            this.Nodes = new Dictionary<T, Node<T, W>>();
            this.visited = new HashSet<T>();
            this.SortedElements = new List<T>();
        }

        public void AddNode(Node<T, W> node)
        {
            this.Nodes.Add(node.Value, node);
        }

        public void AddNodeByValue(T value)
        {
            var node = new Node<T, W>(value);
            this.Nodes.Add(node.Value, node);
        }

        public void AddConnection(T fromNode, T toNode, W weight, bool isBidirectional)
        {
            this.Nodes[fromNode].AddConnection(this.Nodes[toNode], weight, isBidirectional);
        }

        public override string ToString()
        {
            var result = new StringBuilder();

            foreach (var node in this.Nodes)
            {
                result.Append(node.Key  + " -> ");

                foreach (var connection in node.Value.Connections)
                {
                    result.Append(connection.Target + "-" + connection.DijkstraEdgeDistance + " ");
                }

                result.AppendLine();
            }

            return result.ToString();
        }

        public void DfsRecursive(T nodeValue)
        {
            if (!this.visited.Contains(nodeValue))
            {
                this.visited.Add(nodeValue);

                foreach (var connection in this.Nodes[nodeValue].Connections)
                {
                    this.DfsRecursive(connection.Target.Value);
                }
            }

            this.SortedElements.Add(nodeValue);
            this.recursionDepth++;
        }

        public void ShowSorted()
        {
            this.SortedElements.Reverse();
            
            foreach (var node in this.SortedElements)
            {
                Console.Write("{0} ", node);
            }
        }
    }
}