namespace _01.TreeTraversal
{
    using System;
    using System.Collections.Generic;

    internal class TreeBuilder<T> where T : IComparable<T>
    {
        public static Dictionary<T, TreeNode<T>> ParseTree(List<Tuple<T, T>> pairs)
        {
            var tree = new Dictionary<T, TreeNode<T>>();
            for (int i = 0; i < pairs.Count; i++)
            {
                T firstValue = pairs[i].Item1;
                T secondValue = pairs[i].Item2;
                if (tree.ContainsKey(firstValue))
                {
                    TreeNode<T> node = tree[firstValue];
                    TreeNode<T> secondNode;
                    if (tree.ContainsKey(secondValue))
                    {
                        secondNode = tree[secondValue];
                        secondNode.HasParent = true;
                    }
                    else
                    {
                        secondNode = new TreeNode<T>(secondValue);
                        tree.Add(secondValue, secondNode);
                    }
                    node.AddChild(secondNode);
                }
                else
                {
                    TreeNode<T> secondNode;
                    if (tree.ContainsKey(secondValue))
                    {
                        secondNode = tree[secondValue];
                        secondNode.HasParent = true;
                    }
                    else
                    {
                        secondNode = new TreeNode<T>(secondValue);
                        tree.Add(secondValue, secondNode);
                    }
                    TreeNode<T> firstNode = new TreeNode<T>(firstValue);
                    firstNode.AddChild(secondNode);
                    tree.Add(firstValue, firstNode);
                }
            }
            return tree;
        }

        public static TreeNode<T> GetTreeRoot(Dictionary<T, TreeNode<T>> treeDictionary)
        {
            foreach (var node in treeDictionary)
            {
                if (!node.Value.HasParent)
                {
                    return node.Value;
                }
            }
            throw new KeyNotFoundException("No root was found!");
        }
    }
}