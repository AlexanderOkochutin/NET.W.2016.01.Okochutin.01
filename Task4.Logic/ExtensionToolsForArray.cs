using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4.Logic
{
    public static class ExtensionToolsForArray
    {
        public static void MergeSort<T>(this T[] array, IComparer<T> comparer)
        {
            MergeSort<T>(array, 0, array.Length - 1, comparer);
        }

        private static void MergeSort<T>(T[] array, int left, int right, IComparer<T> comparer)
        {
            if (left < right)
            {
                int middle = left + (right - left) / 2;
                MergeSort<T>(array, left, middle, comparer);
                MergeSort<T>(array, middle + 1, right, comparer);
                Merge<T>(array, left, right, comparer);
            }
        }

        private static void Merge<T>(T[] array, int left, int right, IComparer<T> comparer)
        {
            T[] buff = new T[right - left + 1];
            int middle = left + (right - left) / 2;
            int ind1 = left, ind2 = middle + 1, indBuff = 0;
            while (ind1 <= middle && ind2 <= right)
            {
                if (comparer.Compare(array[ind1], array[ind2]) <= 0)
                {
                    buff[indBuff++] = array[ind1++];
                }
                else
                {
                    buff[indBuff++] = array[ind2++];
                }
            }

            while (ind1 <= middle)
            {
                buff[indBuff++] = array[ind1++];
            }

            while (ind2 <= right)
            {
                buff[indBuff++] = array[ind2++];
            }

            for (int i = left; i <= right; i++)
            {
                array[i] = buff[i - left];
            }
        }

        public class IncComparer<T> : IComparer<T> where T : IComparable<T>
        {
            public int Compare(T x, T y)
            {
                if (x.CompareTo(y) > 0) { return 1; }
                else if (x.CompareTo(y) < 0)
                { return -1; }
                else { return 0; }
            }
        }

        public class DecComparer<T> : IComparer<T> where T : IComparable<T>
        {
            public int Compare(T x, T y)
            {
                if (x.CompareTo(y) < 0) { return 1; }
                else if (x.CompareTo(y) > 0)
                { return -1; }
                else { return 0; }
            }
        }
    }
   
}


