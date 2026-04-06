using System;
using System.Collections.Generic;

namespace Vector
{
    /// <summary>
    /// Implements the Top-Down Merge Sort algorithm (Chapter 12.1, Code Fragments 12.1 and 12.2).
    /// This is a recursive divide-and-conquer algorithm that splits the array in half,
    /// recursively sorts each half, then merges them back together.
    /// Time complexity: O(n log n) in all cases (best, average, worst).
    /// Space complexity: O(n) — requires temporary arrays during the merge step.
    /// </summary>
    public class MergeSortTopDown : ISorter
    {
        /// <summary>
        /// Sorts the sub-array array[index .. index+num-1] using the Top-Down Merge Sort algorithm.
        /// Validates input parameters then delegates to the recursive MergeSortRecursive helper.
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

            if (num <= 1)
                return;

            MergeSortRecursive(array, index, index + num - 1, comparer);
        }

        /// <summary>
        /// Recursively sorts array[low..high] by splitting it at the midpoint.
        /// Base case: low >= high means 0 or 1 elements — already sorted.
        /// Recursive case: split at midpoint, sort left half, sort right half, then merge.
        /// </summary>
        /// <typeparam name="K">The type of elements in the array.</typeparam>
        /// <param name="array">The array to sort.</param>
        /// <param name="low">The inclusive lower bound of the sub-array.</param>
        /// <param name="high">The inclusive upper bound of the sub-array.</param>
        /// <param name="comparer">The comparer used to determine element ordering.</param>
        private static void MergeSortRecursive<K>(
            K[] array,
            int low,
            int high,
            IComparer<K> comparer
        )
        {
            if (low >= high)
                return;

            int mid = (low + high) / 2;

            MergeSortRecursive(array, low, mid, comparer);
            MergeSortRecursive(array, mid + 1, high, comparer);

            Merge(array, low, mid, high, comparer);
        }

        /// <summary>
        /// Merges two sorted sub-arrays array[low..mid] and array[mid+1..high]
        /// into a single sorted sub-array array[low..high].
        /// Copies each half into temporary arrays, then uses three index pointers
        /// to merge them back in sorted order. Uses less-than-or-equal comparison
        /// to preserve relative order of equal elements (stable sort).
        /// </summary>
        /// <typeparam name="K">The type of elements in the array.</typeparam>
        /// <param name="array">The array containing the two sorted sub-arrays to merge.</param>
        /// <param name="low">The inclusive lower bound of the left sub-array.</param>
        /// <param name="mid">The inclusive upper bound of the left sub-array (mid+1 is the start of the right).</param>
        /// <param name="high">The inclusive upper bound of the right sub-array.</param>
        /// <param name="comparer">The comparer used to determine element ordering.</param>
        private static void Merge<K>(K[] array, int low, int mid, int high, IComparer<K> comparer)
        {
            int n1 = mid - low + 1;
            int n2 = high - mid;

            K[] left = new K[n1];
            K[] right = new K[n2];

            Array.Copy(array, low, left, 0, n1);
            Array.Copy(array, mid + 1, right, 0, n2);

            int i = 0,
                j = 0,
                k = low;

            while (i < n1 && j < n2)
            {
                if (comparer.Compare(left[i], right[j]) <= 0)
                {
                    array[k] = left[i];
                    i++;
                }
                else
                {
                    array[k] = right[j];
                    j++;
                }
                k++;
            }

            while (i < n1)
            {
                array[k] = left[i];
                i++;
                k++;
            }

            while (j < n2)
            {
                array[k] = right[j];
                j++;
                k++;
            }
        }
    }
}
