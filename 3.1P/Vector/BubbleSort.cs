using System;
using System.Collections.Generic;

namespace Vector
{
    public class BubbleSort : ISorter
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

            for (int i = 0; i < num - 1; i++)
            {
                bool swapped = false;
                for (int j = index; j < index + num - 1 - i; j++)
                {
                    if (comparer.Compare(array[j], array[j + 1]) > 0)
                    {
                        K temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                        swapped = true;
                    }
                }
                if (!swapped)
                    break;
            }
        }
    }
}
