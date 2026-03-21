using System;
using System.Collections.Generic;

namespace Vector
{
    public class InsertionSort : ISorter
    {
        public static void Sort<K>(K[] array, int index, int num, IComparer<K> comparer)
            where K : IComparable<K>
        {
            ArgumentNullException.ThrowIfNull(array);
            if (index < 0 || num < 0)
                throw new ArgumentOutOfRangeException();
            if (index + num > array.Length)
                throw new ArgumentException();

            comparer ??= Comparer<K>.Default;

            for (int i = index + 1; i < index + num; i++)
            {
                K key = array[i];
                int j = i - 1;
                while (j >= index && comparer.Compare(array[j], key) > 0)
                {
                    array[j + 1] = array[j];
                    j--;
                }
                array[j + 1] = key;
            }
        }
    }
}
