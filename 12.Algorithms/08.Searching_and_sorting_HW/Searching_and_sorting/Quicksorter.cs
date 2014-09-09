namespace SortingHomework
{
    using System;
    using System.Collections.Generic;

    public class Quicksorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException("Collection is null!");
            }

            if (collection.Count <= 1)
            {
                return;
            }

            QuickSortCollection(collection);
        }

        private void QuickSortCollection(IList<T> collection)
        {
            QuickSort(collection, 0, collection.Count - 1);
        }

        private void QuickSort(IList<T> collection, int start, int end)
        {
            int i, j;
            T m, p;
            i = start;
            j = end;
            m = collection[(start + end) / 2];

            do
            {
                while (collection[i].CompareTo(m) == -1)
                {
                    i++;
                }
                while (collection[j].CompareTo(m) == 1)
                {
                    j--;
                }
                if (i <= j)
                {
                    p = collection[i];
                    collection[i] = collection[j];
                    collection[j] = p;
                    i++;
                    j--;
                }
            } while (i <= j);

            if (start < j)
            {
                QuickSort(collection, start, j);
            }
            if (i < end)
            {
                QuickSort(collection, i, end);
            }
        }
    }
}