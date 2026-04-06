using System;
using System.Collections.Generic;

namespace Vector
{
    /// <summary>
    /// Implements the Bottom-Up Merge Sort algorithm (Chapter 12.1.5).
    /// Unlike the Top-Down version, this approach is iterative (no recursion).
    /// It starts by merging pairs of single elements, then pairs of 2-element runs,
    /// then 4-element runs, and so on — doubling the width each pass until the
    /// entire array is sorted.
    /// Time complexity: O(n log n) in all cases.
    /// Space complexity: O(n) — requires temporary arrays for merging.
    /// </summary>
    public class MergeSortBottomUp : ISorter
    {
        /// <summary>
        /// Sorts the sub-array array[index .. index+num-1] using the Bottom-Up Merge Sort algorithm.
        /// Validates input parameters then iteratively merges adjacent runs of increasing width
        /// until the entire sub-array is sorted.
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

            int low = index;
            int high = index + num - 1;

            // Outer loop: width doubles each pass (1, 2, 4, 8, ...).
            // After log2(n) passes the entire array is sorted.
            for (int width = 1; width < num; width *= 2)
            {
                // Inner loop: merge adjacent pairs of runs of the current width.
                for (int start = low; start <= high - width; start += 2 * width)
                {
                    int mid = start + width - 1;
                    // Math.Min handles the case where the final right run is shorter than width
                    int end = Math.Min(start + 2 * width - 1, high);
                    Merge(array, start, mid, end, comparer);
                }
            }
        }

        /// <summary>
        /// Merges two sorted sub-arrays array[low..mid] and array[mid+1..high]
        /// into a single sorted sub-array array[low..high].
        /// Copies each half into temporary arrays, then uses three index pointers
        /// to merge them back in sorted order. Uses less-than-or-equal comparison
        /// to preserve relative order of equal elements (stable sort).
        /// </summary>
        /// <typeparam name="K">The type of elements in the array.</typeparam>
        /// <param name="array">The array containing the two sorted runs to merge.</param>
        /// <param name="low">The inclusive lower bound of the left run.</param>
        /// <param name="mid">The inclusive upper bound of the left run (mid+1 is the start of the right run).</param>
        /// <param name="high">The inclusive upper bound of the right run.</param>
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
