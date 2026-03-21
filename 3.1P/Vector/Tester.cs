using System;
using System.Collections.Generic;

namespace Vector
{
    public class AscendingIntComparer : IComparer<int>
    {
        public int Compare(int A, int B)
        {
            return A - B;
        }
    }

    public class DescendingIntComparer : IComparer<int>
    {
        public int Compare(int A, int B)
        {
            return B - A;
        }
    }

    public class EvenNumberFirstComparer : IComparer<int>
    {
        public int Compare(int A, int B)
        {
            return A % 2 - B % 2;
        }
    }

    class Tester
    {
        private static bool CheckAscending(Vector<int> vector)
        {
            for (int i = 0; i < vector.Count - 1; i++)
                if (vector[i] > vector[i + 1])
                    return false;
            return true;
        }

        private static bool CheckDescending(Vector<int> vector)
        {
            for (int i = 0; i < vector.Count - 1; i++)
                if (vector[i] < vector[i + 1])
                    return false;
            return true;
        }

        private static bool CheckEvenNumberFirst(Vector<int> vector)
        {
            for (int i = 0; i < vector.Count - 1; i++)
                if (vector[i] % 2 > vector[i + 1] % 2)
                    return false;
            return true;
        }

        static void Main(string[] args)
        {
            string result = "";
            int problem_size = 20;
            int[] data = new int[problem_size];
            data[0] = 333;
            Random k = new Random(1000);
            for (int i = 1; i < problem_size; i++)
                data[i] = 100 + k.Next(900);

            Vector<int> vector = new Vector<int>(problem_size);

            // ------------------ Default Sort ----------------------------------
            try
            {
                Console.WriteLine(
                    "\nTest A: Sort integer numbers applying Default Sort with the AscendingIntComparer: "
                );
                vector = new Vector<int>(problem_size);
                for (int i = 0; i < problem_size; i++)
                    vector.Add(data[i]);
                Console.WriteLine("Initial data: " + vector.ToString());
                vector.Sort(null, new AscendingIntComparer());
                Console.WriteLine("Resulting order: " + vector.ToString());
                if (!CheckAscending(vector))
                {
                    Console.WriteLine(" :: FAIL");
                    result = result + "-";
                }
                else
                {
                    Console.WriteLine(" :: SUCCESS");
                    result = result + "A";
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine(exception.ToString());
                result = result + "-";
            }

            try
            {
                Console.WriteLine(
                    "\nTest B: Sort integer numbers applying Default Sort with the DescendingIntComparer: "
                );
                vector = new Vector<int>(problem_size);
                for (int i = 0; i < problem_size; i++)
                    vector.Add(data[i]);
                Console.WriteLine("Initial data: " + vector.ToString());
                vector.Sort(null, new DescendingIntComparer());
                Console.WriteLine("Resulting order: " + vector.ToString());
                if (!CheckDescending(vector))
                {
                    Console.WriteLine(" :: FAIL");
                    result = result + "-";
                }
                else
                {
                    Console.WriteLine(" :: SUCCESS");
                    result = result + "B";
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine(exception.ToString());
                result = result + "-";
            }

            try
            {
                Console.WriteLine(
                    "\nTest C: Sort integer numbers applying Default Sort with the EvenNumberFirstComparer: "
                );
                vector = new Vector<int>(problem_size);
                for (int i = 0; i < problem_size; i++)
                    vector.Add(data[i]);
                Console.WriteLine("Initial data: " + vector.ToString());
                vector.Sort(null, new EvenNumberFirstComparer());
                Console.WriteLine("Resulting order: " + vector.ToString());
                if (!CheckEvenNumberFirst(vector))
                {
                    Console.WriteLine(" :: FAIL");
                    result = result + "-";
                }
                else
                {
                    Console.WriteLine(" :: SUCCESS");
                    result = result + "C";
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine(exception.ToString());
                result = result + "-";
            }

            // ------------------ BubbleSort ----------------------------------

            try
            {
                Console.WriteLine(
                    "\nTest D: Sort integer numbers applying BubbleSort with the AscendingIntComparer: "
                );
                vector = new Vector<int>(problem_size);
                for (int i = 0; i < problem_size; i++)
                    vector.Add(data[i]);
                Console.WriteLine("Initial data: " + vector.ToString());
                vector.Sort(new BubbleSort(), new AscendingIntComparer());
                Console.WriteLine("Resulting order: " + vector.ToString());
                if (!CheckAscending(vector))
                {
                    Console.WriteLine(" :: FAIL");
                    result = result + "-";
                }
                else
                {
                    Console.WriteLine(" :: SUCCESS");
                    result = result + "D";
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine(exception.ToString());
                result = result + "-";
            }

            try
            {
                Console.WriteLine(
                    "\nTest E: Sort integer numbers applying BubbleSort with the DescendingIntComparer: "
                );
                vector = new Vector<int>(problem_size);
                for (int i = 0; i < problem_size; i++)
                    vector.Add(data[i]);
                Console.WriteLine("Initial data: " + vector.ToString());
                vector.Sort(new BubbleSort(), new DescendingIntComparer());
                Console.WriteLine("Resulting order: " + vector.ToString());
                if (!CheckDescending(vector))
                {
                    Console.WriteLine(" :: FAIL");
                    result = result + "-";
                }
                else
                {
                    Console.WriteLine(" :: SUCCESS");
                    result = result + "E";
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine(exception.ToString());
                result = result + "-";
            }

            try
            {
                Console.WriteLine(
                    "\nTest F: Sort integer numbers applying BubbleSort with the EvenNumberFirstComparer: "
                );
                vector = new Vector<int>(problem_size);
                for (int i = 0; i < problem_size; i++)
                    vector.Add(data[i]);
                Console.WriteLine("Initial data: " + vector.ToString());
                vector.Sort(new BubbleSort(), new EvenNumberFirstComparer());
                Console.WriteLine("Resulting order: " + vector.ToString());
                if (!CheckEvenNumberFirst(vector))
                {
                    Console.WriteLine(" :: FAIL");
                    result = result + "-";
                }
                else
                {
                    Console.WriteLine(" :: SUCCESS");
                    result = result + "F";
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine(exception.ToString());
                result = result + "-";
            }

            // ------------------ SelectionSort ----------------------------------

            try
            {
                Console.WriteLine(
                    "\nTest G: Sort integer numbers applying SelectionSort with the AscendingIntComparer: "
                );
                vector = new Vector<int>(problem_size);
                for (int i = 0; i < problem_size; i++)
                    vector.Add(data[i]);
                Console.WriteLine("Initial data: " + vector.ToString());
                vector.Sort(new SelectionSort(), new AscendingIntComparer());
                Console.WriteLine("Resulting order: " + vector.ToString());
                if (!CheckAscending(vector))
                {
                    Console.WriteLine(" :: FAIL");
                    result = result + "-";
                }
                else
                {
                    Console.WriteLine(" :: SUCCESS");
                    result = result + "G";
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine(exception.ToString());
                result = result + "-";
            }

            try
            {
                Console.WriteLine(
                    "\nTest H: Sort integer numbers applying SelectionSort with the DescendingIntComparer: "
                );
                vector = new Vector<int>(problem_size);
                for (int i = 0; i < problem_size; i++)
                    vector.Add(data[i]);
                Console.WriteLine("Initial data: " + vector.ToString());
                vector.Sort(new SelectionSort(), new DescendingIntComparer());
                Console.WriteLine("Resulting order: " + vector.ToString());
                if (!CheckDescending(vector))
                {
                    Console.WriteLine(" :: FAIL");
                    result = result + "-";
                }
                else
                {
                    Console.WriteLine(" :: SUCCESS");
                    result = result + "H";
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine(exception.ToString());
                result = result + "-";
            }

            try
            {
                Console.WriteLine(
                    "\nTest I: Sort integer numbers applying SelectionSort with the EvenNumberFirstComparer: "
                );
                vector = new Vector<int>(problem_size);
                for (int i = 0; i < problem_size; i++)
                    vector.Add(data[i]);
                Console.WriteLine("Initial data: " + vector.ToString());
                vector.Sort(new SelectionSort(), new EvenNumberFirstComparer());
                Console.WriteLine("Resulting order: " + vector.ToString());
                if (!CheckEvenNumberFirst(vector))
                {
                    Console.WriteLine(" :: FAIL");
                    result = result + "-";
                }
                else
                {
                    Console.WriteLine(" :: SUCCESS");
                    result = result + "I";
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine(exception.ToString());
                result = result + "-";
            }

            // ------------------ InsertionSort ----------------------------------

            try
            {
                Console.WriteLine(
                    "\nTest J: Sort integer numbers applying InsertionSort with the AscendingIntComparer: "
                );
                vector = new Vector<int>(problem_size);
                for (int i = 0; i < problem_size; i++)
                    vector.Add(data[i]);
                Console.WriteLine("Initial data: " + vector.ToString());
                vector.Sort(new InsertionSort(), new AscendingIntComparer());
                Console.WriteLine("Resulting order: " + vector.ToString());
                if (!CheckAscending(vector))
                {
                    Console.WriteLine(" :: FAIL");
                    result = result + "-";
                }
                else
                {
                    Console.WriteLine(" :: SUCCESS");
                    result = result + "J";
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine(exception.ToString());
                result = result + "-";
            }

            try
            {
                Console.WriteLine(
                    "\nTest K: Sort integer numbers applying InsertionSort with the DescendingIntComparer: "
                );
                vector = new Vector<int>(problem_size);
                for (int i = 0; i < problem_size; i++)
                    vector.Add(data[i]);
                Console.WriteLine("Initial data: " + vector.ToString());
                vector.Sort(new InsertionSort(), new DescendingIntComparer());
                Console.WriteLine("Resulting order: " + vector.ToString());
                if (!CheckDescending(vector))
                {
                    Console.WriteLine(" :: FAIL");
                    result = result + "-";
                }
                else
                {
                    Console.WriteLine(" :: SUCCESS");
                    result = result + "K";
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine(exception.ToString());
                result = result + "-";
            }

            try
            {
                Console.WriteLine(
                    "\nTest L: Sort integer numbers applying InsertionSort with the EvenNumberFirstComparer: "
                );
                vector = new Vector<int>(problem_size);
                for (int i = 0; i < problem_size; i++)
                    vector.Add(data[i]);
                Console.WriteLine("Initial data: " + vector.ToString());
                vector.Sort(new InsertionSort(), new EvenNumberFirstComparer());
                Console.WriteLine("Resulting order: " + vector.ToString());
                if (!CheckEvenNumberFirst(vector))
                {
                    Console.WriteLine(" :: FAIL");
                    result = result + "-";
                }
                else
                {
                    Console.WriteLine(" :: SUCCESS");
                    result = result + "L";
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine(exception.ToString());
                result = result + "-";
            }

            // ======================================================================
            // Step 6: Custom tests — sorting arrays directly via Sort method
            // ======================================================================

            Console.WriteLine("\n\n --------- CUSTOM DIRECT ARRAY TESTS --------- \n");

            ISorter[] sorters = { new BubbleSort(), new InsertionSort(), new SelectionSort() };
            string[] sorterNames = { "BubbleSort", "InsertionSort", "SelectionSort" };

            // Test 1: Empty array — should not crash
            Console.Write("Test M: Empty array sort ... ");
            try
            {
                bool passed = true;
                foreach (var sorter in sorters)
                {
                    int[] empty = Array.Empty<int>();
                    sorter.Sort(empty, 0, 0, new AscendingIntComparer());
                }
                Console.WriteLine(passed ? "SUCCESS" : "FAIL");
                result += passed ? "M" : "-";
            }
            catch (Exception ex)
            {
                Console.WriteLine("FAIL\n" + ex);
                result += "-";
            }

            // Test 2: Single element array — should remain unchanged
            Console.Write("Test N: Single element array sort ... ");
            try
            {
                bool passed = true;
                foreach (var sorter in sorters)
                {
                    int[] single = { 42 };
                    sorter.Sort(single, 0, 1, new AscendingIntComparer());
                    if (single[0] != 42)
                        passed = false;
                }
                Console.WriteLine(passed ? "SUCCESS" : "FAIL");
                result += passed ? "N" : "-";
            }
            catch (Exception ex)
            {
                Console.WriteLine("FAIL\n" + ex);
                result += "-";
            }

            // Test 3: Already sorted array — tests best-case (especially BubbleSort O(n))
            Console.Write("Test O: Already sorted array ... ");
            try
            {
                bool passed = true;
                foreach (var sorter in sorters)
                {
                    int[] sorted = { 1, 2, 3, 4, 5 };
                    sorter.Sort(sorted, 0, 5, new AscendingIntComparer());
                    for (int i = 0; i < sorted.Length - 1; i++)
                        if (sorted[i] > sorted[i + 1])
                            passed = false;
                }
                Console.WriteLine(passed ? "SUCCESS" : "FAIL");
                result += passed ? "O" : "-";
            }
            catch (Exception ex)
            {
                Console.WriteLine("FAIL\n" + ex);
                result += "-";
            }

            // Test 4: Reverse sorted array — tests worst-case
            Console.Write("Test P: Reverse sorted array ... ");
            try
            {
                bool passed = true;
                foreach (var sorter in sorters)
                {
                    int[] reversed = { 5, 4, 3, 2, 1 };
                    sorter.Sort(reversed, 0, 5, new AscendingIntComparer());
                    for (int i = 0; i < reversed.Length - 1; i++)
                        if (reversed[i] > reversed[i + 1])
                            passed = false;
                }
                Console.WriteLine(passed ? "SUCCESS" : "FAIL");
                result += passed ? "P" : "-";
            }
            catch (Exception ex)
            {
                Console.WriteLine("FAIL\n" + ex);
                result += "-";
            }

            // Test 5: Array with duplicate values — ensures stable/correct handling of equal elements
            Console.Write("Test Q: Array with duplicates ... ");
            try
            {
                bool passed = true;
                foreach (var sorter in sorters)
                {
                    int[] dupes = { 3, 1, 2, 1, 3, 2 };
                    sorter.Sort(dupes, 0, 6, new AscendingIntComparer());
                    for (int i = 0; i < dupes.Length - 1; i++)
                        if (dupes[i] > dupes[i + 1])
                            passed = false;
                }
                Console.WriteLine(passed ? "SUCCESS" : "FAIL");
                result += passed ? "Q" : "-";
            }
            catch (Exception ex)
            {
                Console.WriteLine("FAIL\n" + ex);
                result += "-";
            }

            // Test 6: Sorting a sub-range only — elements outside the range must stay untouched
            Console.Write("Test R: Sub-range sort (middle of array) ... ");
            try
            {
                bool passed = true;
                foreach (var sorter in sorters)
                {
                    int[] arr = { 99, 5, 3, 4, 1, 88 };
                    sorter.Sort(arr, 1, 4, new AscendingIntComparer());
                    if (arr[0] != 99 || arr[5] != 88)
                        passed = false;
                    for (int i = 1; i < 4; i++)
                        if (arr[i] > arr[i + 1])
                            passed = false;
                }
                Console.WriteLine(passed ? "SUCCESS" : "FAIL");
                result += passed ? "R" : "-";
            }
            catch (Exception ex)
            {
                Console.WriteLine("FAIL\n" + ex);
                result += "-";
            }

            // Test 7: Negative numbers
            Console.Write("Test S: Negative numbers ... ");
            try
            {
                bool passed = true;
                foreach (var sorter in sorters)
                {
                    int[] neg = { -3, -1, -5, 0, 2, -4 };
                    sorter.Sort(neg, 0, 6, new AscendingIntComparer());
                    for (int i = 0; i < neg.Length - 1; i++)
                        if (neg[i] > neg[i + 1])
                            passed = false;
                }
                Console.WriteLine(passed ? "SUCCESS" : "FAIL");
                result += passed ? "S" : "-";
            }
            catch (Exception ex)
            {
                Console.WriteLine("FAIL\n" + ex);
                result += "-";
            }

            // Test 8: Null array — must throw ArgumentNullException
            Console.Write("Test T: Null array throws ArgumentNullException ... ");
            try
            {
                bool passed = true;
                foreach (var sorter in sorters)
                {
                    try
                    {
                        sorter.Sort<int>(null!, 0, 0, new AscendingIntComparer());
                        passed = false; // should not reach here
                    }
                    catch (ArgumentNullException) { }
                }
                Console.WriteLine(passed ? "SUCCESS" : "FAIL");
                result += passed ? "T" : "-";
            }
            catch (Exception ex)
            {
                Console.WriteLine("FAIL\n" + ex);
                result += "-";
            }

            // Test 9: Negative index — must throw ArgumentOutOfRangeException
            Console.Write("Test U: Negative index throws ArgumentOutOfRangeException ... ");
            try
            {
                bool passed = true;
                foreach (var sorter in sorters)
                {
                    try
                    {
                        int[] arr = { 1, 2, 3 };
                        sorter.Sort(arr, -1, 2, new AscendingIntComparer());
                        passed = false;
                    }
                    catch (ArgumentOutOfRangeException) { }
                }
                Console.WriteLine(passed ? "SUCCESS" : "FAIL");
                result += passed ? "U" : "-";
            }
            catch (Exception ex)
            {
                Console.WriteLine("FAIL\n" + ex);
                result += "-";
            }

            // Test 10: index + num exceeds array length — must throw ArgumentException
            Console.Write("Test V: Out-of-bounds range throws ArgumentException ... ");
            try
            {
                bool passed = true;
                foreach (var sorter in sorters)
                {
                    try
                    {
                        int[] arr = { 1, 2, 3 };
                        sorter.Sort(arr, 1, 5, new AscendingIntComparer());
                        passed = false;
                    }
                    catch (ArgumentException) { }
                }
                Console.WriteLine(passed ? "SUCCESS" : "FAIL");
                result += passed ? "V" : "-";
            }
            catch (Exception ex)
            {
                Console.WriteLine("FAIL\n" + ex);
                result += "-";
            }

            // Test 11: Null comparer — should fall back to Comparer<K>.Default
            Console.Write("Test W: Null comparer uses default ordering ... ");
            try
            {
                bool passed = true;
                foreach (var sorter in sorters)
                {
                    int[] arr = { 5, 3, 1, 4, 2 };
                    sorter.Sort(arr, 0, 5, null!);
                    for (int i = 0; i < arr.Length - 1; i++)
                        if (arr[i] > arr[i + 1])
                            passed = false;
                }
                Console.WriteLine(passed ? "SUCCESS" : "FAIL");
                result += passed ? "W" : "-";
            }
            catch (Exception ex)
            {
                Console.WriteLine("FAIL\n" + ex);
                result += "-";
            }

            // Test 12: Sorting strings to verify generic type works beyond int
            Console.Write("Test X: Sort strings descending ... ");
            try
            {
                bool passed = true;
                foreach (var sorter in sorters)
                {
                    string[] names = { "Charlie", "Alice", "Eve", "Bob", "Dave" };
                    sorter.Sort(
                        names,
                        0,
                        5,
                        Comparer<string>.Create(
                            (a, b) => string.Compare(b, a, StringComparison.Ordinal)
                        )
                    );
                    for (int i = 0; i < names.Length - 1; i++)
                        if (string.Compare(names[i], names[i + 1], StringComparison.Ordinal) < 0)
                            passed = false;
                }
                Console.WriteLine(passed ? "SUCCESS" : "FAIL");
                result += passed ? "X" : "-";
            }
            catch (Exception ex)
            {
                Console.WriteLine("FAIL\n" + ex);
                result += "-";
            }

            Console.WriteLine("\n\n ------------------- SUMMARY ------------------- ");
            Console.WriteLine("Tests passed: " + result);
            Console.ReadKey();
        }
    }
}
