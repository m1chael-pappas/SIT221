using System;
using DoublyLinkedList;

namespace DoubleLinkedList
{
    class Tester
    {
        private static bool CheckIntSequence(int[] certificate, DoublyLinkedList<int> list)
        {
            if (certificate.Length != list.Count)
                return false;
            INode<int> node = list.First;
            for (int i = 0; i < certificate.Length; i++)
            {
                if (certificate[i] != node.Value)
                    return false;
                node = list.After(node);
            }
            return true;
        }

        static void Main(string[] args)
        {
            DoublyLinkedList<int> list = null;
            string result = "";

            // test 1
            try
            {
                Console.WriteLine(
                    "\nTest A: Create a new list by calling 'DoublyLinkedList<int> vector = new DoublyLinkedList<int>( );'"
                );
                list = new DoublyLinkedList<int>();
                Console.WriteLine(" :: SUCCESS: list's state " + list.ToString());
                result = result + "A";
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL: list's state " + list.ToString());
                Console.WriteLine(exception.ToString());
                result = result + "-";
            }

            // test 2
            try
            {
                Console.WriteLine(
                    "\nTest B: Add a sequence of numbers 2, 6, 8, 5, 1, 8, 5, 3, 5 with list.AddLast( )"
                );
                list.AddLast(2);
                list.AddLast(6);
                list.AddLast(8);
                list.AddLast(5);
                list.AddLast(1);
                list.AddLast(8);
                list.AddLast(5);
                list.AddLast(3);
                list.AddLast(5);
                if (!CheckIntSequence(new int[] { 2, 6, 8, 5, 1, 8, 5, 3, 5 }, list))
                    throw new Exception("The list stores incorrect sequence of integers");
                Console.WriteLine(" :: SUCCESS: list's state " + list.ToString());
                result = result + "B";
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL: list's state " + list.ToString());
                Console.WriteLine(exception.ToString());
                result = result + "-";
            }

            // test 3
            try
            {
                Console.WriteLine(
                    "\nTest C: Remove sequentially 4 last numbers with list.RemoveLast( )"
                );
                list.RemoveLast();
                list.RemoveLast();
                list.RemoveLast();
                list.RemoveLast();
                if (!CheckIntSequence(new int[] { 2, 6, 8, 5, 1 }, list))
                    throw new Exception("The list stores incorrect sequence of integers");
                Console.WriteLine(" :: SUCCESS: list's state " + list.ToString());
                result = result + "C";
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL: list's state " + list.ToString());
                Console.WriteLine(exception.ToString());
                result = result + "-";
            }

            // test 4
            try
            {
                Console.WriteLine(
                    "\nTest D: Add a sequence of numbers 10, 20, 30, 40, 50 with list.AddFirst( )"
                );
                list.AddFirst(10);
                list.AddFirst(20);
                list.AddFirst(30);
                list.AddFirst(40);
                list.AddFirst(50);
                if (!CheckIntSequence(new int[] { 50, 40, 30, 20, 10, 2, 6, 8, 5, 1 }, list))
                    throw new Exception("The list stores incorrect sequence of integers");
                Console.WriteLine(" :: SUCCESS: list's state " + list.ToString());
                result = result + "D";
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL: list's state " + list.ToString());
                Console.WriteLine(exception.ToString());
                result = result + "-";
            }

            // test 5
            try
            {
                Console.WriteLine(
                    "\nTest E: Remove sequentially 3 last numbers with list.RemoveFirst( )"
                );
                list.RemoveFirst();
                list.RemoveFirst();
                list.RemoveFirst();
                if (!CheckIntSequence(new int[] { 20, 10, 2, 6, 8, 5, 1 }, list))
                    throw new Exception("The list stores incorrect sequence of integers");
                Console.WriteLine(" :: SUCCESS: list's state " + list.ToString());
                result = result + "E";
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL: list's state " + list.ToString());
                Console.WriteLine(exception.ToString());
                result = result + "-";
            }

            INode<int> node1 = null;
            // test 6
            try
            {
                Console.WriteLine("\nTest F: Run a sequence of operations: ");

                Console.WriteLine("list.Find(40);");
                if (list.Find(40) == null)
                    Console.WriteLine(" :: SUCCESS: list's state " + list.ToString());
                else
                    throw new Exception("40 must no longer be in the list");

                Console.WriteLine("list.Find(0);");
                if (list.Find(0) == null)
                    Console.WriteLine(" :: SUCCESS: list's state " + list.ToString());
                else
                    throw new Exception("0 must not be in the list");

                Console.WriteLine("list.Find(2);");
                node1 = list.Find(2);
                if (node1 != null && node1.Value == 2)
                    Console.WriteLine(" :: SUCCESS: list's state " + list.ToString());
                else
                    throw new Exception(
                        "2 must be in the list, but 'list.Find(2)' does not return the correct result"
                    );

                result = result + "F";
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL: list's state " + list.ToString());
                Console.WriteLine(exception.ToString());
                result = result + "-";
            }

            // test 7
            try
            {
                Console.WriteLine("\nTest G: Run a sequence of operations: ");

                Console.WriteLine(
                    "Add {1} before the node with {0} with list.AddBefore({0},{1})",
                    node1.Value,
                    100
                );
                list.AddBefore(node1, 100);
                if (!CheckIntSequence(new int[] { 20, 10, 100, 2, 6, 8, 5, 1 }, list))
                    throw new Exception("The list stores incorrect sequence of integers");
                Console.WriteLine(" :: SUCCESS: list's state " + list.ToString());

                Console.WriteLine(
                    "Add {1} after the node with {0} with list.AddAfter({0},{1})",
                    node1.Value,
                    200
                );
                list.AddAfter(node1, 200);
                if (!CheckIntSequence(new int[] { 20, 10, 100, 2, 200, 6, 8, 5, 1 }, list))
                    throw new Exception("The list stores incorrect sequence of integers");
                Console.WriteLine(" :: SUCCESS: list's state " + list.ToString());

                Console.WriteLine(
                    "Add {0} before node list.First with list.AddBefore(list.First,{0})",
                    300
                );
                list.AddBefore(list.First, 300);
                if (!CheckIntSequence(new int[] { 300, 20, 10, 100, 2, 200, 6, 8, 5, 1 }, list))
                    throw new Exception("The list stores incorrect sequence of integers");
                Console.WriteLine(" :: SUCCESS: list's state " + list.ToString());

                Console.WriteLine(
                    "Add {0} after node list.First with list.AddAfter(list.First,{0})",
                    400
                );
                list.AddAfter(list.First, 400);
                if (
                    !CheckIntSequence(new int[] { 300, 400, 20, 10, 100, 2, 200, 6, 8, 5, 1 }, list)
                )
                    throw new Exception("The list stores incorrect sequence of integers");
                Console.WriteLine(" :: SUCCESS: list's state " + list.ToString());

                Console.WriteLine(
                    "Add {0} before node list.First with list.AddBefore(list.Last,{0})",
                    500
                );
                list.AddBefore(list.Last, 500);
                if (
                    !CheckIntSequence(
                        new int[] { 300, 400, 20, 10, 100, 2, 200, 6, 8, 5, 500, 1 },
                        list
                    )
                )
                    throw new Exception("The list stores incorrect sequence of integers");
                Console.WriteLine(" :: SUCCESS: list's state " + list.ToString());

                Console.WriteLine(
                    "Add {0} after node list.First with list.AddAfter(list.Last,{0})",
                    600
                );
                list.AddAfter(list.Last, 600);
                if (
                    !CheckIntSequence(
                        new int[] { 300, 400, 20, 10, 100, 2, 200, 6, 8, 5, 500, 1, 600 },
                        list
                    )
                )
                    throw new Exception("The list stores incorrect sequence of integers");
                Console.WriteLine(" :: SUCCESS: list's state " + list.ToString());

                result = result + "G";
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL: list's state " + list.ToString());
                Console.WriteLine(exception.ToString());
                result = result + "-";
            }

            // test 8
            try
            {
                Console.WriteLine("\nTest H: Run a sequence of operations: ");

                Console.WriteLine("Remove the node list.First with list.Remove(list.First)");
                list.Remove(list.First);
                if (
                    !CheckIntSequence(
                        new int[] { 400, 20, 10, 100, 2, 200, 6, 8, 5, 500, 1, 600 },
                        list
                    )
                )
                    throw new Exception("The list stores incorrect sequence of integers");
                Console.WriteLine(" :: SUCCESS: list's state " + list.ToString());

                Console.WriteLine("Remove the node list.Last with list.Remove(list.Last)");
                list.Remove(list.Last);
                if (
                    !CheckIntSequence(new int[] { 400, 20, 10, 100, 2, 200, 6, 8, 5, 500, 1 }, list)
                )
                    throw new Exception("The list stores incorrect sequence of integers");
                Console.WriteLine(" :: SUCCESS: list's state " + list.ToString());

                Console.WriteLine(
                    "Remove the node list.Before, which is before the node containing element {0}, with list.Remove(list.Before(...))",
                    node1.Value
                );
                list.Remove(list.Before(node1));
                if (!CheckIntSequence(new int[] { 400, 20, 10, 2, 200, 6, 8, 5, 500, 1 }, list))
                    throw new Exception("The list stores incorrect sequence of integers");
                Console.WriteLine(" :: SUCCESS: list's state " + list.ToString());

                Console.WriteLine(
                    "Remove the node containing element {0} with list.Remove(...)",
                    node1.Value
                );
                list.Remove(node1);
                if (!CheckIntSequence(new int[] { 400, 20, 10, 200, 6, 8, 5, 500, 1 }, list))
                    throw new Exception("The list stores incorrect sequence of integers");
                Console.WriteLine(" :: SUCCESS: list's state " + list.ToString());

                result = result + "H";
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL: list's state " + list.ToString());
                Console.WriteLine(exception.ToString());
                result = result + "-";
            }

            // test 9
            try
            {
                Console.WriteLine(
                    "\nTest I: Remove the node containing element {0}, which has been recently deleted, with list.Remove(...)",
                    node1.Value
                );
                list.Remove(node1);
                Console.WriteLine(" :: FAIL: list's state " + list.ToString());
                Console.WriteLine(
                    "Last operation is invalid and must throw InvalidOperationException. Your solution does not match specification."
                );
                result = result + "-";
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine(" :: SUCCESS: list's state " + list.ToString());
                result = result + "I";
            }
            catch (Exception)
            {
                Console.WriteLine(" :: FAIL: list's state " + list.ToString());
                Console.WriteLine(
                    "Last operation is invalid and must throw InvalidOperationException. Your solution does not match specification."
                );
                result = result + "-";
            }

            // test 10
            try
            {
                Console.WriteLine(
                    "\nTest J: Clear the content of the vector via calling vector.Clear();"
                );
                list.Clear();
                if (!CheckIntSequence(new int[] { }, list))
                    throw new Exception("The list stores incorrect data. It must be empty.");
                Console.WriteLine(" :: SUCCESS: list's state " + list.ToString());
                result = result + "J";
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL: list's state " + list.ToString());
                Console.WriteLine(exception.ToString());
                result = result + "-";
            }

            // test 11
            try
            {
                Console.WriteLine(
                    "\nTest K: Remove last element for the empty list with list.RemoveLast()"
                );
                list.RemoveLast();
                Console.WriteLine(" :: FAIL: list's state " + list.ToString());
                Console.WriteLine(
                    "Last operation is invalid and must throw InvalidOperationException. Your solution does not match specification."
                );
                result = result + "-";
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine(" :: SUCCESS: list's state " + list.ToString());
                result = result + "K";
            }
            catch (Exception)
            {
                Console.WriteLine(" :: FAIL: list's state " + list.ToString());
                Console.WriteLine(
                    "Last operation is invalid and must throw InvalidOperationException. Your solution does not match specification."
                );
                result = result + "-";
            }

            // test 12: RemoveFirst on empty list
            try
            {
                Console.WriteLine(
                    "\nTest L: Remove first element for the empty list with list.RemoveFirst()"
                );
                list.RemoveFirst();
                Console.WriteLine(" :: FAIL: list's state " + list.ToString());
                Console.WriteLine(
                    "Last operation is invalid and must throw InvalidOperationException. Your solution does not match specification."
                );
                result = result + "-";
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine(" :: SUCCESS: list's state " + list.ToString());
                result = result + "L";
            }
            catch (Exception)
            {
                Console.WriteLine(" :: FAIL: list's state " + list.ToString());
                Console.WriteLine(
                    "Last operation is invalid and must throw InvalidOperationException. Your solution does not match specification."
                );
                result = result + "-";
            }

            // test 13: AddFirst to empty list then verify single element
            try
            {
                Console.WriteLine(
                    "\nTest M: AddFirst to an empty list, then verify First and Last point to the same node"
                );
                list.AddFirst(99);
                if (list.Count != 1)
                    throw new Exception("Count should be 1");
                if (list.First == null || list.Last == null)
                    throw new Exception("First and Last should not be null");
                if (list.First != list.Last)
                    throw new Exception(
                        "First and Last should be the same node for a single-element list"
                    );
                if (list.First.Value != 99)
                    throw new Exception("Value should be 99");
                Console.WriteLine(" :: SUCCESS: list's state " + list.ToString());
                result = result + "M";
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL: list's state " + list.ToString());
                Console.WriteLine(exception.ToString());
                result = result + "-";
            }

            // test 14: Before on first node returns null, After on last node returns null
            try
            {
                Console.WriteLine("\nTest N: Before(First) returns null, After(Last) returns null");
                if (list.Before(list.First) != null)
                    throw new Exception("Before(First) should return null");
                if (list.After(list.Last) != null)
                    throw new Exception("After(Last) should return null");
                Console.WriteLine(" :: SUCCESS: list's state " + list.ToString());
                result = result + "N";
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL: list's state " + list.ToString());
                Console.WriteLine(exception.ToString());
                result = result + "-";
            }

            // test 15: Remove the only element, list becomes empty
            try
            {
                Console.WriteLine("\nTest O: Remove the only element, then verify list is empty");
                list.Remove(list.First);
                if (list.Count != 0)
                    throw new Exception("Count should be 0");
                if (list.First != null)
                    throw new Exception("First should be null");
                if (list.Last != null)
                    throw new Exception("Last should be null");
                Console.WriteLine(" :: SUCCESS: list's state " + list.ToString());
                result = result + "O";
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL: list's state " + list.ToString());
                Console.WriteLine(exception.ToString());
                result = result + "-";
            }

            // test 16: AddBefore with null node throws exception
            try
            {
                Console.WriteLine(
                    "\nTest P: AddBefore with null node throws ArgumentNullException"
                );
                list.AddBefore(null, 10);
                Console.WriteLine(" :: FAIL: Expected ArgumentNullException");
                result = result + "-";
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine(" :: SUCCESS: ArgumentNullException thrown as expected");
                result = result + "P";
            }
            catch (Exception)
            {
                Console.WriteLine(" :: FAIL: Wrong exception type thrown");
                result = result + "-";
            }

            // test 17: AddAfter with null node throws exception
            try
            {
                Console.WriteLine(
                    "\nTest Q: AddAfter with null node throws ArgumentNullException"
                );
                list.AddAfter(null, 10);
                Console.WriteLine(" :: FAIL: Expected ArgumentNullException");
                result = result + "-";
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine(" :: SUCCESS: ArgumentNullException thrown as expected");
                result = result + "Q";
            }
            catch (Exception)
            {
                Console.WriteLine(" :: FAIL: Wrong exception type thrown");
                result = result + "-";
            }

            // test 18: Remove with null node throws exception
            try
            {
                Console.WriteLine("\nTest R: Remove with null node throws ArgumentNullException");
                list.Remove(null);
                Console.WriteLine(" :: FAIL: Expected ArgumentNullException");
                result = result + "-";
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine(" :: SUCCESS: ArgumentNullException thrown as expected");
                result = result + "R";
            }
            catch (Exception)
            {
                Console.WriteLine(" :: FAIL: Wrong exception type thrown");
                result = result + "-";
            }

            // test 19: Clear on already empty list works without error
            try
            {
                Console.WriteLine("\nTest S: Clear on an already empty list does not throw");
                list.Clear();
                if (list.Count != 0)
                    throw new Exception("Count should be 0");
                Console.WriteLine(" :: SUCCESS: list's state " + list.ToString());
                result = result + "S";
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL: list's state " + list.ToString());
                Console.WriteLine(exception.ToString());
                result = result + "-";
            }

            // test 20: Build list, clear, then rebuild to ensure reuse works
            try
            {
                Console.WriteLine("\nTest T: Build list, clear, then rebuild");
                list.AddLast(1);
                list.AddLast(2);
                list.AddLast(3);
                list.Clear();
                list.AddFirst(10);
                list.AddLast(20);
                if (!CheckIntSequence(new int[] { 10, 20 }, list))
                    throw new Exception("The list stores incorrect sequence of integers");
                if (list.First.Value != 10)
                    throw new Exception("First should be 10");
                if (list.Last.Value != 20)
                    throw new Exception("Last should be 20");
                Console.WriteLine(" :: SUCCESS: list's state " + list.ToString());
                result = result + "T";
                list.Clear();
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL: list's state " + list.ToString());
                Console.WriteLine(exception.ToString());
                result = result + "-";
            }

            Console.WriteLine("\n\n ------------------- SUMMARY ------------------- ");
            Console.WriteLine("Tests passed: " + result);
            Console.ReadKey();
        }
    }
}
