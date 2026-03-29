using System;
using System.Collections.Generic;
using System.Text;

namespace Vector
{
    /// <summary>
    /// A generic dynamic array that stores elements of type <typeparamref name="T"/>.
    /// Supports adding, removing, searching, sorting, and binary search operations.
    /// </summary>
    /// <typeparam name="T">The type of elements stored in the vector. Must implement <see cref="IComparable{T}"/>.</typeparam>
    public class Vector<T>(int capacity)
        where T : IComparable<T>
    {
        private const int DEFAULT_CAPACITY = 10;

        private T[] data = new T[capacity];

        /// <summary>Gets the number of elements currently stored in the vector.</summary>
        public int Count { get; private set; } = 0;

        /// <summary>Gets the total number of elements the internal array can hold before resizing.</summary>
        public int Capacity
        {
            get { return data.Length; }
        }

        /// <summary>
        /// Initialises a new instance of the <see cref="Vector{T}"/> class with the default capacity.
        /// </summary>
        public Vector()
            : this(DEFAULT_CAPACITY) { }

        /// <summary>
        /// Gets or sets the element at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index of the element.</param>
        /// <exception cref="IndexOutOfRangeException">Thrown when <paramref name="index"/> is out of range.</exception>
        public T this[int index]
        {
            get
            {
                if (index >= Count || index < 0)
                    throw new IndexOutOfRangeException();
                return data[index];
            }
            set
            {
                if (index >= Count || index < 0)
                    throw new IndexOutOfRangeException();
                data[index] = value;
            }
        }

        /// <summary>
        /// Extends the internal array by the specified extra capacity.
        /// </summary>
        /// <param name="extraCapacity">The number of additional slots to allocate.</param>
        private void ExtendData(int extraCapacity)
        {
            T[] newData = new T[Capacity + extraCapacity];
            for (int i = 0; i < Count; i++)
                newData[i] = data[i];
            data = newData;
        }

        /// <summary>
        /// Adds an element to the end of the vector, resizing if necessary.
        /// </summary>
        /// <param name="element">The element to add.</param>
        public void Add(T element)
        {
            if (Count == Capacity)
                ExtendData(DEFAULT_CAPACITY);
            data[Count] = element;
            Count++;
        }

        /// <summary>
        /// Returns the zero-based index of the first occurrence of the specified element,
        /// or -1 if the element is not found.
        /// </summary>
        /// <param name="element">The element to locate.</param>
        /// <returns>The index of the element, or -1 if not found.</returns>
        public int IndexOf(T element)
        {
            for (var i = 0; i < Count; i++)
            {
                if (EqualityComparer<T>.Default.Equals(data[i], element))
                    return i;
            }
            return -1;
        }

        /// <summary>
        /// Inserts an element at the specified index, shifting subsequent elements to the right.
        /// </summary>
        /// <param name="index">The zero-based index at which to insert.</param>
        /// <param name="element">The element to insert.</param>
        /// <exception cref="IndexOutOfRangeException">Thrown when <paramref name="index"/> is out of range.</exception>
        public void Insert(int index, T element)
        {
            if (index < 0 || index > Count)
                throw new IndexOutOfRangeException();
            if (Count == Capacity)
                ExtendData(DEFAULT_CAPACITY);
            for (var i = Count; i > index; i--)
            {
                data[i] = data[i - 1];
            }
            data[index] = element;
            Count++;
        }

        /// <summary>
        /// Removes all elements from the vector, resetting the count to zero.
        /// </summary>
        public void Clear()
        {
            for (int i = 0; i < Count; i++)
                data[i] = default!;
            Count = 0;
        }

        /// <summary>
        /// Determines whether the vector contains the specified element.
        /// </summary>
        /// <param name="element">The element to search for.</param>
        /// <returns><c>true</c> if found; otherwise <c>false</c>.</returns>
        public bool Contains(T element)
        {
            return IndexOf(element) != -1;
        }

        /// <summary>
        /// Removes the first occurrence of the specified element from the vector.
        /// </summary>
        /// <param name="element">The element to remove.</param>
        /// <returns><c>true</c> if the element was found and removed; otherwise <c>false</c>.</returns>
        public bool Remove(T element)
        {
            int index = IndexOf(element);
            if (index == -1)
                return false;
            RemoveAt(index);
            return true;
        }

        /// <summary>
        /// Removes the element at the specified index, shifting subsequent elements to the left.
        /// </summary>
        /// <param name="index">The zero-based index of the element to remove.</param>
        /// <exception cref="IndexOutOfRangeException">Thrown when <paramref name="index"/> is out of range.</exception>
        public void RemoveAt(int index)
        {
            if (index < 0 || index >= Count)
                throw new IndexOutOfRangeException();
            for (var i = index; i < Count - 1; i++)
            {
                data[i] = data[i + 1];
            }
            data[Count - 1] = default!;
            Count--;
        }

        /// <summary>
        /// Sorts the elements using the default comparer for type <typeparamref name="T"/>.
        /// </summary>
        public void Sort()
        {
            Array.Sort(data, 0, Count);
        }

        /// <summary>
        /// Sorts the elements using the specified comparer.
        /// </summary>
        /// <param name="comparer">The comparer used to compare elements.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="comparer"/> is null.</exception>
        public void Sort(IComparer<T> comparer)
        {
            ArgumentNullException.ThrowIfNull(comparer);
            Array.Sort(data, 0, Count, comparer);
        }

        /// <summary>
        /// Searches for the specified item within the entire sorted vector using an iterative
        /// binary search algorithm. The vector must already be sorted according to the given comparer.
        ///
        /// The algorithm maintains two boundaries (low and high) and repeatedly compares the
        /// middle element to the target. Each comparison halves the search space:
        ///   - If the middle element equals the item, its index is returned.
        ///   - If the middle element is less than the item (per the comparer), search continues in the right half.
        ///   - If the middle element is greater, search continues in the left half.
        ///
        /// Time complexity: O(log n). Space complexity: O(1).
        /// </summary>
        /// <param name="item">The item to search for.</param>
        /// <param name="comparer">
        /// The comparer used to compare elements. If null, <see cref="Comparer{T}.Default"/> is used.
        /// </param>
        /// <returns>The zero-based index of <paramref name="item"/> if found; otherwise -1.</returns>
        public int BinarySearch(T item, IComparer<T> comparer)
        {
            comparer ??= Comparer<T>.Default;

            int low = 0;
            int high = Count - 1;

            while (low <= high)
            {
                // Calculate midpoint using (high - low) / 2 to avoid integer overflow
                int mid = low + (high - low) / 2;
                int result = comparer.Compare(data[mid], item);

                if (result == 0)
                    return mid; // item found at mid
                else if (result < 0)
                    low = mid + 1; // item is in the right half
                else
                    high = mid - 1; // item is in the left half
            }

            return -1;
        }

        /// <summary>
        /// Searches for the specified item within the entire sorted vector using a recursive
        /// binary search algorithm. The vector must already be sorted according to the given comparer.
        ///
        /// This is functionally identical to <see cref="BinarySearch(T, IComparer{T})"/> but uses
        /// recursion instead of a loop. Each recursive call narrows the search range by half.
        ///
        /// Time complexity: O(log n). Space complexity: O(log n) due to the recursive call stack.
        /// </summary>
        /// <param name="item">The item to search for.</param>
        /// <param name="comparer">
        /// The comparer used to compare elements. If null, <see cref="Comparer{T}.Default"/> is used.
        /// </param>
        /// <returns>The zero-based index of <paramref name="item"/> if found; otherwise -1.</returns>
        public int BinarySearchRecursive(T item, IComparer<T> comparer)
        {
            comparer ??= Comparer<T>.Default;
            return BinarySearchRecursive(item, comparer, 0, Count - 1);
        }

        /// <summary>
        /// Private recursive helper that performs binary search within the specified range.
        /// </summary>
        /// <param name="item">The item to search for.</param>
        /// <param name="comparer">The comparer used to compare elements.</param>
        /// <param name="low">The inclusive lower bound of the search range.</param>
        /// <param name="high">The inclusive upper bound of the search range.</param>
        /// <returns>The zero-based index of <paramref name="item"/> if found; otherwise -1.</returns>
        private int BinarySearchRecursive(T item, IComparer<T> comparer, int low, int high)
        {
            // Base case: search space is exhausted
            if (low > high)
                return -1;

            int mid = low + (high - low) / 2;
            int result = comparer.Compare(data[mid], item);

            if (result == 0)
                return mid; // item found at mid
            else if (result < 0)
                return BinarySearchRecursive(item, comparer, mid + 1, high); // search right half
            else
                return BinarySearchRecursive(item, comparer, low, mid - 1); // search left half
        }

        /// <summary>
        /// Returns a string representation of the vector in the format [e1,e2,...,en].
        /// </summary>
        /// <returns>A comma-separated string of all elements enclosed in square brackets.</returns>
        public override string ToString()
        {
            StringBuilder sb = new();
            sb.Append('[');
            for (int i = 0; i < Count; i++)
            {
                sb.Append(data[i]);
                if (i < Count - 1)
                    sb.Append(',');
            }
            sb.Append(']');
            return sb.ToString();
        }
    }
}
