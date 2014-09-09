namespace _01.TreeTraversal
{
    using System;
    using System.Collections.Generic;

    public class TreeNode<T> where T : IComparable<T>
    {
        private T value;
        private TreeNode<T> parent;
        private List<TreeNode<T>> children;

        public T Value
        {
            get { return this.value; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Value cannot be null!");
                }
                this.value = value;
            }
        }

        public TreeNode<T> Parent
        {
            get
            {
                return this.parent;
            }
            set
            {
                this.parent = value;
            }
        }

        private bool hasParent;

        public bool HasParent
        {
            get { return hasParent; }
            set { hasParent = value; }
        }

        public List<TreeNode<T>> Children
        {
            get { return children; }
            set { children = value; }
        }

        public TreeNode(T value)
        {
            this.Value = value;
            this.Parent = null;
            this.Children = new List<TreeNode<T>>();
        }

        public TreeNode<T> AddChildByValue(T childValue)
        {
            var child = new TreeNode<T>(childValue);
            child.Parent = this;
            child.HasParent = true;
            this.Children.Add(child);
            return child;
        }

        public TreeNode<T> AddChild(TreeNode<T> child)
        {
            if (child == null)
            {
                throw new ArgumentNullException("Cannot add null child!");
            }
            child.Parent = this;
            child.HasParent = true;
            this.Children.Add(child);
            return child;
        }

        public int ChildrenCount()
        {
            return this.Children.Count;
        }

        public TreeNode<T> GetChild(int childIndex)
        {
            return this.Children[childIndex];
        }

        public TreeNode<T> FindChild(T childValue)
        {
            foreach (var treeNode in this.Children)
            {
                if (treeNode.Value.CompareTo(childValue) > 0)
                {
                    return treeNode;
                }
            }
            return null;
        }

        private TreeNode<T> GetRoot()
        {
            if (this.Parent != null)
            {
                return this.Parent.GetRoot();
            }
            else
            {
                return this;
            }
        }

        private void TraverseDFS(TreeNode<T> root, string spaces)
        {
            if (root == null)
            {
                return;
            }

            Console.WriteLine(spaces + root.Value);

            TreeNode<T> child = null;
            for (int i = 0; i < this.GetRoot().ChildrenCount(); i++)
            {
                child = root.GetChild(i);
                this.TraverseDFS(child, spaces + "   ");
            }
        }

        public void TraverseDFS()
        {
            this.TraverseDFS(this.GetRoot(), string.Empty);
        }

        public void TraverseBFS()
        {
            Queue<TreeNode<T>> queue = new Queue<TreeNode<T>>();
            queue.Enqueue(this.GetRoot());
            while (queue.Count > 0)
            {
                TreeNode<T> currentNode = queue.Dequeue();
                Console.Write("{0} ", currentNode.Value);
                for (int i = 0; i < currentNode.ChildrenCount(); i++)
                {
                    TreeNode<T> childNode = currentNode.GetChild(i);
                    queue.Enqueue(childNode);
                }
            }
        }

        public void TraverseDFSWithStack()
        {
            Stack<TreeNode<T>> stack = new Stack<TreeNode<T>>();
            stack.Push(this.GetRoot());
            while (stack.Count > 0)
            {
                TreeNode<T> currentNode = stack.Pop();
                Console.Write("{0} ", currentNode.Value);
                for (int i = 0; i < currentNode.ChildrenCount(); i++)
                {
                    TreeNode<T> childNode = currentNode.GetChild(i);
                    stack.Push(childNode);
                }
            }
        }
    }
}