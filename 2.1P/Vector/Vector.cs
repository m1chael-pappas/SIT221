using System;
using System.Collections.Generic;
using System.Text;

namespace Vector
{
    public class Vector<T>(int capacity)
    {
        private const int DEFAULT_CAPACITY = 10;

        private T[] data = new T[capacity];

        public int Count { get; private set; } = 0;

        public int Capacity
        {
            get { return data.Length; }
        }

        public Vector()
            : this(DEFAULT_CAPACITY) { }

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

        private void ExtendData(int extraCapacity)
        {
            T[] newData = new T[Capacity + extraCapacity];
            for (int i = 0; i < Count; i++)
                newData[i] = data[i];
            data = newData;
        }

        public void Add(T element)
        {
            if (Count == Capacity)
                ExtendData(DEFAULT_CAPACITY);
            data[Count] = element;
            Count++;
        }

        public int IndexOf(T element)
        {
            for (var i = 0; i < Count; i++)
            {
                if (EqualityComparer<T>.Default.Equals(data[i], element))
                    return i;
            }
            return -1;
        }

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

        public void Clear()
        {
            for (int i = 0; i < Count; i++)
                data[i] = default!;
            Count = 0;
        }

        public bool Contains(T element)
        {
            return IndexOf(element) != -1;
        }

        public bool Remove(T element)
        {
            int index = IndexOf(element);
            if (index == -1)
                return false;
            RemoveAt(index);
            return true;
        }

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

        // Sorts using the default comparer for type T (Comparer<T>.Default).
        // Delegates to Array.Sort so no sorting algorithm needs to be written here.
        public void Sort()
        {
            Array.Sort(data, 0, Count);
        }

        // Sorts using the provided comparer.
        // Falls back to Comparer<T>.Default if comparer is null.
        public void Sort(IComparer<T> comparer)
        {
            Array.Sort(data, 0, Count, comparer ?? Comparer<T>.Default);
        }

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
