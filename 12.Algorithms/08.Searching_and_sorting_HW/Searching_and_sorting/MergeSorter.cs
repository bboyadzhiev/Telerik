namespace SortingHomework
{
    using System;
    using System.Collections.Generic;

    public class MergeSorter<T> : ISorter<T> where T : IComparable<T>
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

            IList<T> temp = new List<T>(collection);
            var count = collection.Count;
            MergeSort(0, count - 1, collection, temp);
        }

        private void MergeSort(int i, int j, IList<T> collection, IList<T> temp)
        {
            int middle;
            if (i < j)
            {
                middle = (i + j) / 2;
                MergeSort(i, middle, collection, temp);
                MergeSort(middle + 1, j, collection, temp);
                Merge(i, middle, middle + 1, j, collection, temp);
            }
        }

        public void Merge(int i1, int i2, int j1, int j2, IList<T> collection, IList<T> temp)
        {
            int k, n;
            n = j2 - i1 + 1;
            k = i1;
            while (i1 <= i2 && j1 <= j2)
            {
                if (collection[i1].CompareTo(collection[j1]) == -1)
                {
                    temp[k] = collection[i1];
                    i1++;
                }
                else
                {
                    temp[k] = collection[j1];
                    j1++;
                }
                k++;
            }
            while (i1 <= i2)
            {
                temp[k] = collection[i1];
                i1++;
                k++;
            }
            while (j1 <= j2)
            {
                temp[k] = collection[j1];
                j1++;
                k++;
            }
            for (k = 0; k < n; k++)
            {
                j1--;
                collection[j1] = temp[j1];
            }
        }
    }
}