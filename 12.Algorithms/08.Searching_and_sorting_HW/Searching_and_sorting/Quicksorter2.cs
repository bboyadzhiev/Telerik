namespace SortingHomework
{
    using System;
    using System.Collections.Generic;

    public class Quicksorter2<T> : ISorter<T> where T : IComparable<T>
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
            var n = collection.Count - 1;
            QuickSort(collection, 0, n);
            InsertionSort(collection, n);
        }

        private void QuickSort(IList<T> collection, int start, int end)
        {
            int i, j, b;
            T m;
            // According to a research by J. Weiss for collection
            // of 10 or less elements Insertion Sort is the quickest sort
            b = 10;
            if (start + b - 1 <= end)
            {
                m = Median(collection, start, end);
                i = start;
                j = end - 1;

                do
                {
                    do
                    {
                        i++;
                    } while (collection[i].CompareTo(m) == -1);
                    do
                    {
                        j--;
                        //Console.WriteLine(j);
                    } while (collection[j].CompareTo(m) == 1);
                    Swap(collection[i], collection[j]);
                } while (j < i);

                Swap(collection[i], collection[j]);
                Swap(collection[i], collection[end - 1]);
                QuickSort(collection, start, i - 1);
                QuickSort(collection, i + 1, end);
            }
        }

        private void InsertionSort(IList<T> collection, int n)
        {
            int j, i;
            T p;
            for (i = 1; i < n; i++)
            {
                p = collection[i];
                j = i - 1;
                while ((j >= 0) && (collection[j].CompareTo(p) == 1))
                {
                    collection[j + 1] = collection[j];
                    j--;
                }
                collection[j + 1] = p;
            }
        }

        private T Median(IList<T> collection, int start, int end)
        {
            int middle = (start + end) / 2;
            if (collection[start].CompareTo(collection[middle]) == 1)
            {
                Swap(collection[start], collection[middle]);
            }
            if (collection[start].CompareTo(collection[end]) == 1)
            {
                Swap(collection[start], collection[end]);
            }
            if (collection[middle].CompareTo(collection[end]) == 1)
            {
                Swap(collection[middle], collection[end]);
            }

            T leading = collection[middle];
            Swap(collection[middle], collection[end - 1]);
            return leading;
        }

        private void Swap(T x, T y)
        {
            T p = x;
            x = y;
            y = p;
        }
    }
}