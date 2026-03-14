using System;

namespace Vector
{
    class Tester
    {
        private static bool CheckIntSequence(int[] certificate, Vector<int> vector)
        {
            if (certificate.Length != vector.Count)
                return false;
            for (int i = 0; i < certificate.Length; i++)
            {
                if (certificate[i] != vector[i])
                    return false;
            }
            return true;
        }

        static void Main(string[] args)
        {
            Vector<int> vector = null;
            string result = "";

            // test 1
            try
            {
                int capacity = 1;
                Console.WriteLine(
                    "\nTest A: Create a new vector by calling 'Vector<int> vector = new Vector<int>("
                        + capacity
                        + ");'"
                );
                vector = new Vector<int>(capacity);
                if (vector.Capacity != capacity)
                    throw new Exception("Vector has a wrong capacity");
                Console.WriteLine(" :: SUCCESS");
                result += "A";
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine(exception.ToString());
                result += "-";
            }

            // test 2
            try
            {
                Console.WriteLine(
                    "\nTest B: Add a sequence of numbers 2, 6, 8, 5, 5, 1, 8, 5, 3, 5"
                );
                vector.Add(2);
                vector.Add(6);
                vector.Add(8);
                vector.Add(5);
                vector.Add(5);
                vector.Add(1);
                vector.Add(8);
                vector.Add(5);
                vector.Add(3);
                vector.Add(5);
                if (!CheckIntSequence(new int[] { 2, 6, 8, 5, 5, 1, 8, 5, 3, 5 }, vector))
                    throw new Exception("Vector stores incorrect sequence of integers");
                Console.WriteLine(" :: SUCCESS");
                result += "B";
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine(exception.ToString());
                result += "-";
            }

            // test 3
            try
            {
                Console.WriteLine("\nTest C: Remove number 3, 7, and then 6");
                bool check =
                    vector.Remove(3)
                    && (!vector.Remove(7))
                    && vector.Remove(6)
                    && (!vector.Remove(6));
                if (!CheckIntSequence(new int[] { 2, 8, 5, 5, 1, 8, 5, 5 }, vector))
                    throw new Exception("Vector stores incorrect sequence of integers");
                Console.WriteLine(" :: SUCCESS");
                result += "C";
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine(exception.ToString());
                result += "-";
            }

            // test 4
            try
            {
                Console.WriteLine(
                    "\nTest D: Insert number 50 at index 6, then number 0 at index 0, then number 60 at index 'vector.Count-1', then number 70 at index 'vector.Count'"
                );
                vector.Insert(6, 50);
                vector.Insert(0, 0);
                vector.Insert(vector.Count - 1, 60);
                vector.Insert(vector.Count, 70);
                if (!CheckIntSequence(new int[] { 0, 2, 8, 5, 5, 1, 8, 50, 5, 60, 5, 70 }, vector))
                    throw new Exception("Vector stores incorrect sequence of integers");
                Console.WriteLine(" :: SUCCESS");
                result += "D";
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine(exception.ToString());
                result += "-";
            }

            // test 5
            try
            {
                Console.WriteLine("\nTest E: Insert number -1 at index 'vector.Count+1'");
                vector.Insert(vector.Count + 1, -1);
                Console.WriteLine(" :: FAIL");
                Console.WriteLine(
                    "Last operation is invalid and must throw IndexOutOfRangeException. Your solution does not match specification."
                );
                result += "-";
            }
            catch (IndexOutOfRangeException exception)
            {
                Console.WriteLine(" :: SUCCESS");
                result += "E";
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine(
                    "Last operation is invalid and must throw IndexOutOfRangeException. Your solution does not match specification."
                );
                result += "-";
            }

            // test 6
            try
            {
                Console.WriteLine(
                    "\nTest F: Remove number at index 4, then number index 0, and then number at index 'vector.Count-1'"
                );
                vector.RemoveAt(4);
                vector.RemoveAt(0);
                vector.RemoveAt(vector.Count - 1);
                if (!CheckIntSequence(new int[] { 2, 8, 5, 1, 8, 50, 5, 60, 5 }, vector))
                    throw new Exception("Vector stores incorrect sequence of integers");
                Console.WriteLine(" :: SUCCESS");
                result += "F";
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine(exception.ToString());
                result += "-";
            }

            // test 7
            try
            {
                Console.WriteLine("\nTest G: Remove number at index 'vector.Count'");
                vector.RemoveAt(vector.Count);
                Console.WriteLine(" :: FAIL");
                Console.WriteLine(
                    "Last operation is invalid and must throw IndexOutOfRangeException. Your solution does not match specification."
                );
                result += "-";
            }
            catch (IndexOutOfRangeException exception)
            {
                Console.WriteLine(" :: SUCCESS");
                result += "G";
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine(
                    "Last operation is invalid and must throw IndexOutOfRangeException. Your solution does not match specification."
                );
                result += "-";
            }

            // test 8
            try
            {
                Console.WriteLine("\nTest H: Run a sequence of operations: ");

                Console.WriteLine("vector.Contains(1);");
                if (vector.Contains(1))
                    Console.WriteLine(" :: SUCCESS");
                else
                    throw new Exception("1 must be in the vector");

                Console.WriteLine("vector.Contains(2);");
                if (vector.Contains(2))
                    Console.WriteLine(" :: SUCCESS");
                else
                    throw new Exception("2 must be in the vector");

                Console.WriteLine("vector.Contains(4);");
                if (!vector.Contains(4))
                    Console.WriteLine(" :: SUCCESS");
                else
                    throw new Exception("4 must not be in the vector");

                Console.WriteLine("vector.Add(4); vector.Contains(4);");
                vector.Add(4);
                if (vector.Contains(4))
                    Console.WriteLine(" :: SUCCESS");
                else
                    throw new Exception("4 must be in the vector");

                result += "H";
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine(exception.ToString());
                result += "-";
            }

            // test 9
            try
            {
                Console.WriteLine(
                    "\nTest I: Print the content of the vector via calling vector.ToString();"
                );
                Console.WriteLine(vector.ToString());
                Console.WriteLine(" :: SUCCESS");
                result += "I";
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine(exception.ToString());
                result += "-";
            }

            // test 10
            try
            {
                Console.WriteLine(
                    "\nTest J: Clear the content of the vector via calling vector.Clear();"
                );
                vector.Clear();
                if (!CheckIntSequence(new int[] { }, vector))
                    throw new Exception("Vector stores incorrect data. It must be empty.");
                Console.WriteLine(" :: SUCCESS");
                result += "J";
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine(exception.ToString());
                result += "-";
            }

            // ---- ADDITIONAL TESTS ----

            // test K: After Clear(), internal data slots are actually reset (not just hidden by Count)
            try
            {
                Console.WriteLine(
                    "\nTest K: After Clear(), verify internal data is reset (elements are truly removed, not just hidden)"
                );
                Vector<string> sv = new Vector<string>();
                sv.Add("hello");
                sv.Add("world");
                sv.Clear();
                // Count must be 0
                if (sv.Count != 0)
                    throw new Exception("Count must be 0 after Clear()");
                // Re-add a new element and check it is correct (not polluted by old data)
                sv.Add("fresh");
                if (sv.Count != 1)
                    throw new Exception(
                        "Count must be 1 after adding one element to a cleared vector"
                    );
                if (sv[0] != "fresh")
                    throw new Exception("Element at index 0 should be 'fresh', not leftover data");
                Console.WriteLine(" :: SUCCESS");
                result += "K";
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine(exception.ToString());
                result += "-";
            }

            // test L: Accessing index out of range on empty vector throws IndexOutOfRangeException
            try
            {
                Console.WriteLine(
                    "\nTest L: Access index 0 on an empty vector should throw IndexOutOfRangeException"
                );
                Vector<int> emptyVec = new Vector<int>();
                int val = emptyVec[0];
                Console.WriteLine(" :: FAIL");
                Console.WriteLine("Should have thrown IndexOutOfRangeException but did not.");
                result += "-";
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine(" :: SUCCESS");
                result += "L";
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine(exception.ToString());
                result += "-";
            }

            // test M: Insert at negative index throws IndexOutOfRangeException
            try
            {
                Console.WriteLine(
                    "\nTest M: Insert at negative index -1 should throw IndexOutOfRangeException"
                );
                Vector<int> v = new Vector<int>();
                v.Add(1);
                v.Insert(-1, 99);
                Console.WriteLine(" :: FAIL");
                Console.WriteLine("Should have thrown IndexOutOfRangeException but did not.");
                result += "-";
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine(" :: SUCCESS");
                result += "M";
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine(exception.ToString());
                result += "-";
            }

            // test N: RemoveAt negative index throws IndexOutOfRangeException
            try
            {
                Console.WriteLine(
                    "\nTest N: RemoveAt negative index -1 should throw IndexOutOfRangeException"
                );
                Vector<int> v = new Vector<int>();
                v.Add(10);
                v.RemoveAt(-1);
                Console.WriteLine(" :: FAIL");
                Console.WriteLine("Should have thrown IndexOutOfRangeException but did not.");
                result += "-";
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine(" :: SUCCESS");
                result += "N";
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine(exception.ToString());
                result += "-";
            }

            // test O: Remove only removes the FIRST occurrence, not all occurrences
            try
            {
                Console.WriteLine(
                    "\nTest O: Remove(5) on [5,5,5] should leave [5,5] (only first occurrence removed)"
                );
                Vector<int> v = new Vector<int>();
                v.Add(5);
                v.Add(5);
                v.Add(5);
                v.Remove(5);
                if (!CheckIntSequence(new int[] { 5, 5 }, v))
                    throw new Exception("Remove should only remove the first occurrence");
                Console.WriteLine(" :: SUCCESS");
                result += "O";
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine(exception.ToString());
                result += "-";
            }

            // test P: Capacity grows correctly when adding beyond initial capacity
            try
            {
                Console.WriteLine(
                    "\nTest P: Adding elements beyond initial capacity triggers resize and all elements are preserved"
                );
                Vector<int> v = new Vector<int>(3); // capacity of 3
                v.Add(1);
                v.Add(2);
                v.Add(3);
                if (v.Capacity != 3)
                    throw new Exception("Capacity should be 3 before resize");
                v.Add(4); // should trigger resize
                if (v.Capacity <= 3)
                    throw new Exception("Capacity should have grown after exceeding limit");
                if (!CheckIntSequence(new int[] { 1, 2, 3, 4 }, v))
                    throw new Exception("Elements not preserved after resize");
                Console.WriteLine(" :: SUCCESS");
                result += "P";
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine(exception.ToString());
                result += "-";
            }

            // test Q: ToString on empty vector returns []
            try
            {
                Console.WriteLine("\nTest Q: ToString() on empty vector returns \"[]\"");
                Vector<int> v = new Vector<int>();
                string s = v.ToString();
                if (s != "[]")
                    throw new Exception($"Expected \"[]\", got \"{s}\"");
                Console.WriteLine(" :: SUCCESS");
                result += "Q";
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine(exception.ToString());
                result += "-";
            }

            // test R: IndexOf returns -1 when element is not present
            try
            {
                Console.WriteLine("\nTest R: IndexOf returns -1 for an element not in the vector");
                Vector<int> v = new Vector<int>();
                v.Add(10);
                v.Add(20);
                v.Add(30);
                int idx = v.IndexOf(99);
                if (idx != -1)
                    throw new Exception($"Expected -1, got {idx}");
                Console.WriteLine(" :: SUCCESS");
                result += "R";
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine(exception.ToString());
                result += "-";
            }

            // test S: Contains returns false on an empty vector
            try
            {
                Console.WriteLine("\nTest S: Contains on an empty vector returns false");
                Vector<int> v = new Vector<int>();
                if (v.Contains(1))
                    throw new Exception("Contains should return false on empty vector");
                Console.WriteLine(" :: SUCCESS");
                result += "S";
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine(exception.ToString());
                result += "-";
            }

            Console.WriteLine("\n\n ------------------- SUMMARY ------------------- ");
            Console.WriteLine("Tests passed: " + result);
            Console.ReadKey();
        }
    }
}
