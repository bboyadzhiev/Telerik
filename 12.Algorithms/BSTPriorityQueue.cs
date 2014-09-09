using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.PriorityQueueOfT
{
    class BSTPriorityQueue<T> where T : IComparable<T>
    {
        public TreeNode<T> Root { get; set; }

        public void Enqueue(T newChildValue)
        {
            var newChildNode = new TreeNode<T>() { Value = newChildValue };

            if (this.Root == null)
            {
                this.Root = newChildNode;
            }
            else
            {
                TreeNode<T> parent = this.SearchForParent(newChildValue);
                if (parent.Value.CompareTo(newChildValue) < 0)
                {
                    parent.LeftChild = newChildNode;
                }
                else
                {
                    parent.RightChild = newChildNode;
                }
            }
        }

        private TreeNode<T> SearchForParent(T childValue)
        {
            var parentCandidate = this.Root;
            while (true)
            {
                if (parentCandidate.Value.CompareTo(childValue)<0)
                {
                    if (parentCandidate.RightChild == null)
                    {
                        return parentCandidate;
                    }
                    else
                    {
                        return parentCandidate.RightChild;
                    }
                }
                else
                {
                    if (parentCandidate.LeftChild == null)
                    {
                        return parentCandidate;
                    }
                    else
                    {
                        return parentCandidate.LeftChild;
                    }
                }
            }
        }

        public T Dequeue()
        {
            var node = this.Root;
            while (node.RightChild != null)
            {
                node = node.RightChild;
            }
            var nodeValue = node.Value;
            node = null;
            return nodeValue;
            
        }
    }
}
