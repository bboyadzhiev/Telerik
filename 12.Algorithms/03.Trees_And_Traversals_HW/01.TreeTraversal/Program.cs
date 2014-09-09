namespace _01.TreeTraversal
{
    using System;
    using System.Collections.Generic;

    internal class Program
    {
        private static void Main(string[] args)
        {
            var pairs = new List<Tuple<int, int>>()
            {
                new Tuple<int, int>(2, 4),
                new Tuple<int, int>(3, 2),
                new Tuple<int, int>(5, 0),
                new Tuple<int, int>(3, 5),
                new Tuple<int, int>(5, 6),
                new Tuple<int, int>(5, 1),
                new Tuple<int, int>(5, 7),
                new Tuple<int, int>(7, 8),
                new Tuple<int, int>(8, 1),
                new Tuple<int, int>(0, 9)
            };

            var tree = TreeBuilder<int>.ParseTree(pairs);
            var root = TreeBuilder<int>.GetTreeRoot(tree);

            Console.WriteLine("The tree:");
            root.PrintChildren(0);

            Console.WriteLine();

            var leafsList = root.GetLeafNodes();
            Console.Write("The leafs: ");
            foreach (var leaf in leafsList)
            {
                Console.Write("{0} ", leaf.Value);
            }

            Console.WriteLine();

            var middleNodesList = root.GetMiddleNodes();
            Console.Write("The middle nodes: ");
            foreach (var node in middleNodesList)
            {
                Console.Write("{0} ", node.Value);
            }

            Console.WriteLine();
            Console.Write("The Lognest path: ");
            root.TraverseDFSWithStack();
            Console.WriteLine();
        }
    }
}