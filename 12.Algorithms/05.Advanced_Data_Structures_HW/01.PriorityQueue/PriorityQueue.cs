namespace _01.PriorityQueue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class PriorityQueue<T> : IEnumerable where T : IComparable<T>
    {
        private List<T> heap;

        public PriorityQueue()
        {
            heap = new List<T>();
        }

        public void Enqueue(T item)
        {
            this.heap.Add(item);

            int childIndex = this.heap.Count - 1;
            while (childIndex > 0)
            {
                int parentIndex = (childIndex - 1) / 2;
                if (this.heap[parentIndex].CompareTo(this.heap[childIndex]) >= 0)
                {
                    break;
                }

                T swapItem = this.heap[childIndex];
                this.heap[childIndex] = this.heap[parentIndex];
                this.heap[parentIndex] = swapItem;

                childIndex = parentIndex;
            }
        }

        public T Dequeue()
        {
            if (this.heap.Count == 0)
            {
                throw new InvalidOperationException("Queue is empty!");
            }

            int lastIndex = this.heap.Count - 1;

            T topItem = this.heap[0];
            this.heap[0] = this.heap[lastIndex];
            this.heap.RemoveAt(lastIndex);
            lastIndex--;

            int parentIndex = 0;
            while (true)
            {
                int leftIndex = 2 * parentIndex + 1;
                if (leftIndex > lastIndex)
                {
                    break;
                }

                int swapIndex = leftIndex;
                int rightIndex = leftIndex + 1;
                if (rightIndex <= lastIndex && this.heap[rightIndex].CompareTo(this.heap[leftIndex]) > 0)
                {
                    swapIndex = rightIndex;
                }

                if (this.heap[parentIndex].CompareTo(this.heap[swapIndex]) >= 0)
                {
                    break;
                }

                T swap = this.heap[swapIndex];
                this.heap[swapIndex] = this.heap[parentIndex];
                this.heap[parentIndex] = swap;

                parentIndex = swapIndex;
            }

            return topItem;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this.heap.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}