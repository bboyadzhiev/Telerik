namespace _01.TreeTraversal
{
    using System;
    using System.Collections.Generic;

    public static class TreeNodeExtensions
    {
        public static void PrintChildren<T>(this TreeNode<T> node, int offset) where T : IComparable<T>
        {
            for (int i = 0; i < offset; i++)
            {
                Console.Write(" ");
            }
            if (node.Children.Count != 0)
            {
                Console.WriteLine("{0}", node.Value);
                foreach (var child in node.Children)
                {
                    child.PrintChildren(offset + 1);
                }
            }
            else
            {
                Console.WriteLine("{0} - leaf", node.Value);
            }
        }

        public static List<TreeNode<T>> GetLeafNodes<T>(this TreeNode<T> treeNode) where T : IComparable<T>
        {
            var leafs = new List<TreeNode<T>>();
            if (treeNode.Children.Count == 0)
            {
                leafs.Add(treeNode);
            }
            else
            {
                foreach (var child in treeNode.Children)
                {
                    leafs.AddRange(child.GetLeafNodes());
                }
            }
            return leafs;
        }

        public static List<TreeNode<T>> GetMiddleNodes<T>(this TreeNode<T> treeNode) where T : IComparable<T>
        {
            var middleNodesList = new List<TreeNode<T>>();
            var children = treeNode.Children;
            if (children.Count > 0 && treeNode.HasParent)
            {
                middleNodesList.Add(treeNode);
            }
            foreach (var child in children)
                {
                    foreach (var leaf in child.GetMiddleNodes())
                    {
                        if (!middleNodesList.Contains(leaf))
                        {
                            middleNodesList.Add(leaf);
                        }
                    }
                }
            return middleNodesList;
        }
    }
}