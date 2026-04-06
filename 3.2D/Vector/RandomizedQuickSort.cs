using System;
using System.Collections.Generic;

namespace Vector
{
    /// <summary>
    /// Implements the Randomized In-Place Quick Sort algorithm (Chapter 12.2).
    /// Uses a randomly selected pivot to achieve expected O(n log n) time complexity,
    /// avoiding the O(n^2) worst case that occurs with deterministic pivot selection
    /// on already-sorted or nearly-sorted input.
    /// </summary>
    public class RandomizedQuickSort : ISorter
    {
        private static readonly Random random = new();

        /// <summary>
        /// Sorts the sub-array array[index .. index+num-1] using the Randomized Quick Sort algorithm.
        /// Validates input parameters then delegates to the recursive QuickSort helper.
        /// </summary>
        /// <typeparam name="K">The type of elements in the array. Must implement IComparable.</typeparam>
        /// <param name="array">The array to sort.</param>
        /// <param name="index">The starting index of the sub-array to sort.</param>
        /// <param name="num">The number of elements to sort.</param>
        /// <param name="comparer">The comparer used to determine element ordering. Falls back to default if null.</param>
        /// <exception cref="ArgumentNullException">Thrown if array is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if index or num is negative.</exception>
        /// <exception cref="ArgumentException">Thrown if index + num exceeds the array length.</exception>
        public void Sort<K>(K[] array, int index, int num, IComparer<K> comparer)
            where K : IComparable<K>
        {
            ArgumentNullException.ThrowIfNull(array);
            ArgumentOutOfRangeException.ThrowIfNegative(index);
            ArgumentOutOfRangeException.ThrowIfNegative(num);

            if (index + num > array.Length)
                throw new ArgumentException("index + num exceeds array length.");

            comparer ??= Comparer<K>.Default;

            QuickSort(array, index, index + num - 1, comparer);
        }

        /// <summary>
        /// Recursively sorts array[low..high] in-place.
        /// Base case: if low >= high, the sub-array has 0 or 1 elements and is already sorted.
        /// Recursive case: partition around a pivot, then sort both halves.
        /// </summary>
        /// <typeparam name="K">The type of elements in the array.</typeparam>
        /// <param name="array">The array to sort.</param>
        /// <param name="low">The inclusive lower bound of the sub-array.</param>
        /// <param name="high">The inclusive upper bound of the sub-array.</param>
        /// <param name="comparer">The comparer used to determine element ordering.</param>
        private static void QuickSort<K>(K[] array, int low, int high, IComparer<K> comparer)
        {
            if (low >= high)
                return;

            int pivotIndex = Partition(array, low, high, comparer);
            QuickSort(array, low, pivotIndex - 1, comparer);
            QuickSort(array, pivotIndex + 1, high, comparer);
        }

        /// <summary>
        /// Partitions array[low..high] around a randomly chosen pivot (Section 12.2.1 / Code Fragment 12.6).
        /// A random pivot is selected and moved to the end. Two pointers scan inward from both ends,
        /// swapping misplaced elements. After partitioning, all elements left of the pivot are less than or
        /// equal to it, and all elements right of the pivot are greater than or equal to it.
        /// </summary>
        /// <typeparam name="K">The type of elements in the array.</typeparam>
        /// <param name="array">The array to partition.</param>
        /// <param name="low">The inclusive lower bound of the sub-array.</param>
        /// <param name="high">The inclusive upper bound of the sub-array.</param>
        /// <param name="comparer">The comparer used to determine element ordering.</param>
        /// <returns>The final index of the pivot element after partitioning.</returns>
        private static int Partition<K>(K[] array, int low, int high, IComparer<K> comparer)
        {
            // Randomized pivot selection — modification from Section 12.2.1 applied to Code Fragment 12.6 line 7
            int pivotIdx = random.Next(low, high + 1);
            Swap(array, pivotIdx, high);

            K pivot = array[high];
            int left = low;
            int right = high - 1;

            while (left <= right)
            {
                while (left <= right && comparer.Compare(array[left], pivot) < 0)
                    left++;

                while (left <= right && comparer.Compare(array[right], pivot) > 0)
                    right--;

                if (left <= right)
                {
                    Swap(array, left, right);
                    left++;
                    right--;
                }
            }

            Swap(array, left, high);
            return left;
        }

        /// <summary>
        /// Swaps two elements in the array at the given indices.
        /// </summary>
        /// <typeparam name="K">The type of elements in the array.</typeparam>
        /// <param name="array">The array containing the elements to swap.</param>
        /// <param name="i">The index of the first element.</param>
        /// <param name="j">The index of the second element.</param>
        private static void Swap<K>(K[] array, int i, int j)
        {
            K temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
    }
}
