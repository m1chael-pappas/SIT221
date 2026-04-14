using System;
using System.Text;

namespace DoublyLinkedList
{
    public class DoublyLinkedList<T>
    {
        private class Node<K>(
            K value,
            DoublyLinkedList<T>.Node<K> previous,
            DoublyLinkedList<T>.Node<K> next
        ) : INode<K>
        {
            public K Value { get; set; } = value;
            public Node<K> Next { get; set; } = next;
            public Node<K> Previous { get; set; } = previous;

            public override string ToString()
            {
                StringBuilder s = new();
                s.Append('{');
                s.Append(Previous.Previous == null ? "XXX" : Previous.Value.ToString());
                s.Append("-(");
                s.Append(Value);
                s.Append(")-");
                s.Append(Next.Next == null ? "XXX" : Next.Value.ToString());
                s.Append('}');
                return s.ToString();
            }
        }

        private Node<T> Head { get; set; }
        private Node<T> Tail { get; set; }
        public int Count { get; private set; } = 0;

        public DoublyLinkedList()
        {
            Head = new Node<T>(default(T), null, null);
            Tail = new Node<T>(default(T), Head, null);
            Head.Next = Tail;
        }

        public INode<T> First
        {
            get
            {
                if (Count == 0)
                    return null;
                else
                    return Head.Next;
            }
        }

        public INode<T> Last
        {
            get
            {
                if (Count == 0)
                    return null;
                else
                    return Tail.Previous;
            }
        }

        /// <summary>
        /// Validates that the supplied <see cref="INode{T}"/> is non-null, of the
        /// correct concrete type, still attached to a list, and owned by this
        /// particular list instance.
        /// </summary>
        /// <param name="node">The node reference to validate.</param>
        /// <param name="paramName">
        /// The name of the caller's parameter, used when throwing
        /// <see cref="ArgumentNullException"/> so the message points at the
        /// correct argument.
        /// </param>
        /// <returns>The validated node cast to the internal <see cref="Node{T}"/> type.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="node"/> is null.</exception>
        /// <exception cref="InvalidCastException">
        /// Thrown when <paramref name="node"/> is not an instance of <see cref="Node{T}"/>.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// Thrown when the node has already been removed from a list, or when
        /// it belongs to a different <see cref="DoublyLinkedList{T}"/> instance.
        /// </exception>
        private Node<T> ValidateNode(INode<T> node, string paramName)
        {
            if (node == null)
                throw new ArgumentNullException(paramName);

            if (node is not Node<T> current)
                throw new InvalidCastException(
                    "The provided node is not compatible with this list."
                );

            if (current.Previous == null || current.Next == null)
                throw new InvalidOperationException("The node is no longer in the list");

            Node<T> walker = current;
            while (walker.Previous != null)
                walker = walker.Previous;
            if (!ReferenceEquals(walker, Head))
                throw new InvalidOperationException("The node does not belong to this list");

            return current;
        }

        public INode<T> After(INode<T> node)
        {
            Node<T> node_current = ValidateNode(node, nameof(node));
            if (node_current.Next.Equals(Tail))
                return null;
            else
                return node_current.Next;
        }

        public INode<T> Before(INode<T> node)
        {
            Node<T> node_current = ValidateNode(node, nameof(node));
            if (node_current.Previous.Equals(Head))
                return null;
            else
                return node_current.Previous;
        }

        public INode<T> AddLast(T value)
        {
            return AddBetween(value, Tail.Previous, Tail);
        }

        public INode<T> AddFirst(T value)
        {
            return AddBetween(value, Head, Head.Next);
        }

        private Node<T> AddBetween(T value, Node<T> previous, Node<T> next)
        {
            Node<T> node = new(value, previous, next);
            previous.Next = node;
            next.Previous = node;
            Count++;
            return node;
        }

        public INode<T> AddBefore(INode<T> before, T value)
        {
            Node<T> node_before = ValidateNode(before, nameof(before));
            return AddBetween(value, node_before.Previous, node_before);
        }

        public INode<T> AddAfter(INode<T> after, T value)
        {
            Node<T> node_after = ValidateNode(after, nameof(after));
            return AddBetween(value, node_after, node_after.Next);
        }

        public INode<T> Find(T value)
        {
            Node<T> node = Head.Next;
            while (!node.Equals(Tail))
            {
                if (node.Value.Equals(value))
                    return node;
                node = node.Next;
            }
            return null;
        }

        public void Clear()
        {
            Node<T> node = Head.Next;
            while (!node.Equals(Tail))
            {
                Node<T> next = node.Next;
                node.Previous = null;
                node.Next = null;
                node = next;
            }
            Head.Next = Tail;
            Tail.Previous = Head;
            Count = 0;
        }

        public void Remove(INode<T> node)
        {
            Node<T> node_current = ValidateNode(node, nameof(node));
            node_current.Previous.Next = node_current.Next;
            node_current.Next.Previous = node_current.Previous;
            node_current.Previous = null;
            node_current.Next = null;
            Count--;
        }

        public void RemoveFirst()
        {
            if (Count == 0)
                throw new InvalidOperationException("The list is empty");
            Remove(Head.Next);
        }

        public void RemoveLast()
        {
            if (Count == 0)
                throw new InvalidOperationException("The list is empty");
            Remove(Tail.Previous);
        }

        public override string ToString()
        {
            if (Count == 0)
                return "[]";
            StringBuilder s = new();
            s.Append('[');
            int k = 0;
            Node<T> node = Head.Next;
            while (!node.Equals(Tail))
            {
                s.Append(node.ToString());
                node = node.Next;
                if (k < Count - 1)
                    s.Append(',');
                k++;
            }
            s.Append(']');
            return s.ToString();
        }
    }
}
