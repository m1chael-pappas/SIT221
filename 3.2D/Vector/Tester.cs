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

            Vector<int> vector = null;

            // ------------------ RandomizedQuickSort ----------------------------------

            try
            {
                Console.WriteLine(
                    "\nTest A: Sort integer numbers applying RandomizedQuickSort with the AscendingIntComparer: "
                );
                vector = new Vector<int>(problem_size);
                for (int i = 0; i < problem_size; i++)
                    vector.Add(data[i]);
                Console.WriteLine("Initial data: " + vector.ToString());
                vector.Sort(new RandomizedQuickSort(), new AscendingIntComparer());
                Console.WriteLine("Resulting order: " + vector.ToString());
                if (!CheckAscending(vector))
                {
                    Console.WriteLine(" :: FAIL");
                    result += "-";
                }
                else
                {
                    Console.WriteLine(" :: SUCCESS");
                    result += "A";
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine(exception.ToString());
                result += "-";
            }

            try
            {
                Console.WriteLine(
                    "\nTest B: Sort integer numbers applying RandomizedQuickSort with the DescendingIntComparer: "
                );
                vector = new Vector<int>(problem_size);
                for (int i = 0; i < problem_size; i++)
                    vector.Add(data[i]);
                Console.WriteLine("Initial data: " + vector.ToString());
                vector.Sort(new RandomizedQuickSort(), new DescendingIntComparer());
                Console.WriteLine("Resulting order: " + vector.ToString());
                if (!CheckDescending(vector))
                {
                    Console.WriteLine(" :: FAIL");
                    result += "-";
                }
                else
                {
                    Console.WriteLine(" :: SUCCESS");
                    result += "B";
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine(exception.ToString());
                result += "-";
            }

            try
            {
                Console.WriteLine(
                    "\nTest C: Sort integer numbers applying RandomizedQuickSort with the EvenNumberFirstComparer: "
                );
                vector = new Vector<int>(problem_size);
                for (int i = 0; i < problem_size; i++)
                    vector.Add(data[i]);
                Console.WriteLine("Initial data: " + vector.ToString());
                vector.Sort(new RandomizedQuickSort(), new EvenNumberFirstComparer());
                Console.WriteLine("Resulting order: " + vector.ToString());
                if (!CheckEvenNumberFirst(vector))
                {
                    Console.WriteLine(" :: FAIL");
                    result += "-";
                }
                else
                {
                    Console.WriteLine(" :: SUCCESS");
                    result += "C";
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine(exception.ToString());
                result += "-";
            }

            // ------------------ MergeSortTopDown ----------------------------------

            try
            {
                Console.WriteLine(
                    "\nTest D: Sort integer numbers applying MergeSortTopDown with the AscendingIntComparer: "
                );
                vector = new Vector<int>(problem_size);
                for (int i = 0; i < problem_size; i++)
                    vector.Add(data[i]);
                Console.WriteLine("Initial data: " + vector.ToString());
                vector.Sort(new MergeSortTopDown(), new AscendingIntComparer());
                Console.WriteLine("Resulting order: " + vector.ToString());
                if (!CheckAscending(vector))
                {
                    Console.WriteLine(" :: FAIL");
                    result += "-";
                }
                else
                {
                    Console.WriteLine(" :: SUCCESS");
                    result += "D";
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine(exception.ToString());
                result += "-";
            }

            try
            {
                Console.WriteLine(
                    "\nTest E: Sort integer numbers applying MergeSortTopDown with the DescendingIntComparer: "
                );
                vector = new Vector<int>(problem_size);
                for (int i = 0; i < problem_size; i++)
                    vector.Add(data[i]);
                Console.WriteLine("Initial data: " + vector.ToString());
                vector.Sort(new MergeSortTopDown(), new DescendingIntComparer());
                Console.WriteLine("Resulting order: " + vector.ToString());
                if (!CheckDescending(vector))
                {
                    Console.WriteLine(" :: FAIL");
                    result += "-";
                }
                else
                {
                    Console.WriteLine(" :: SUCCESS");
                    result += "E";
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine(exception.ToString());
                result += "-";
            }

            try
            {
                Console.WriteLine(
                    "\nTest F: Sort integer numbers applying MergeSortTopDown with the EvenNumberFirstComparer: "
                );
                vector = new Vector<int>(problem_size);
                for (int i = 0; i < problem_size; i++)
                    vector.Add(data[i]);
                Console.WriteLine("Initial data: " + vector.ToString());
                vector.Sort(new MergeSortTopDown(), new EvenNumberFirstComparer());
                Console.WriteLine("Resulting order: " + vector.ToString());
                if (!CheckEvenNumberFirst(vector))
                {
                    Console.WriteLine(" :: FAIL");
                    result += "-";
                }
                else
                {
                    Console.WriteLine(" :: SUCCESS");
                    result += "F";
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine(exception.ToString());
                result += "-";
            }

            // ------------------ MergeSortBottomUp ----------------------------------

            try
            {
                Console.WriteLine(
                    "\nTest G: Sort integer numbers applying MergeSortBottomUp with the AscendingIntComparer: "
                );
                vector = new Vector<int>(problem_size);
                for (int i = 0; i < problem_size; i++)
                    vector.Add(data[i]);
                Console.WriteLine("Initial data: " + vector.ToString());
                vector.Sort(new MergeSortBottomUp(), new AscendingIntComparer());
                Console.WriteLine("Resulting order: " + vector.ToString());
                if (!CheckAscending(vector))
                {
                    Console.WriteLine(" :: FAIL");
                    result += "-";
                }
                else
                {
                    Console.WriteLine(" :: SUCCESS");
                    result += "G";
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine(exception.ToString());
                result += "-";
            }

            try
            {
                Console.WriteLine(
                    "\nTest H: Sort integer numbers applying MergeSortBottomUp with the DescendingIntComparer: "
                );
                vector = new Vector<int>(problem_size);
                for (int i = 0; i < problem_size; i++)
                    vector.Add(data[i]);
                Console.WriteLine("Initial data: " + vector.ToString());
                vector.Sort(new MergeSortBottomUp(), new DescendingIntComparer());
                Console.WriteLine("Resulting order: " + vector.ToString());
                if (!CheckDescending(vector))
                {
                    Console.WriteLine(" :: FAIL");
                    result += "-";
                }
                else
                {
                    Console.WriteLine(" :: SUCCESS");
                    result += "H";
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine(exception.ToString());
                result += "-";
            }

            try
            {
                Console.WriteLine(
                    "\nTest I: Sort integer numbers applying MergeSortBottomUp with the EvenNumberFirstComparer: "
                );
                vector = new Vector<int>(problem_size);
                for (int i = 0; i < problem_size; i++)
                    vector.Add(data[i]);
                Console.WriteLine("Initial data: " + vector.ToString());
                vector.Sort(new MergeSortBottomUp(), new EvenNumberFirstComparer());
                Console.WriteLine("Resulting order: " + vector.ToString());
                if (!CheckEvenNumberFirst(vector))
                {
                    Console.WriteLine(" :: FAIL");
                    result += "-";
                }
                else
                {
                    Console.WriteLine(" :: SUCCESS");
                    result += "I";
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine(exception.ToString());
                result += "-";
            }

            // ======================================================================
            // Step 5: Custom tests — sorting arrays directly via Sort method
            // ======================================================================

            Console.WriteLine("\n\n --------- CUSTOM DIRECT ARRAY TESTS --------- \n");

            ISorter[] sorters =
            {
                new RandomizedQuickSort(),
                new MergeSortTopDown(),
                new MergeSortBottomUp(),
            };
            string[] sorterNames = ["RandomizedQuickSort", "MergeSortTopDown", "MergeSortBottomUp"];

            // Test J: Empty array — should not crash
            Console.Write("Test J: Empty array sort ... ");
            try
            {
                bool passed = true;
                foreach (var sorter in sorters)
                {
                    int[] empty = Array.Empty<int>();
                    sorter.Sort(empty, 0, 0, new AscendingIntComparer());
                }
                Console.WriteLine(passed ? "SUCCESS" : "FAIL");
                result += passed ? "J" : "-";
            }
            catch (Exception ex)
            {
                Console.WriteLine("FAIL\n" + ex);
                result += "-";
            }

            // Test K: Single element array — should remain unchanged
            Console.Write("Test K: Single element array sort ... ");
            try
            {
                bool passed = true;
                foreach (var sorter in sorters)
                {
                    int[] single = [42];
                    sorter.Sort(single, 0, 1, new AscendingIntComparer());
                    if (single[0] != 42)
                        passed = false;
                }
                Console.WriteLine(passed ? "SUCCESS" : "FAIL");
                result += passed ? "K" : "-";
            }
            catch (Exception ex)
            {
                Console.WriteLine("FAIL\n" + ex);
                result += "-";
            }

            // Test L: Already sorted array — best-case scenario
            Console.Write("Test L: Already sorted array ... ");
            try
            {
                bool passed = true;
                foreach (var sorter in sorters)
                {
                    int[] sorted = [1, 2, 3, 4, 5];
                    sorter.Sort(sorted, 0, 5, new AscendingIntComparer());
                    for (int i = 0; i < sorted.Length - 1; i++)
                        if (sorted[i] > sorted[i + 1])
                            passed = false;
                }
                Console.WriteLine(passed ? "SUCCESS" : "FAIL");
                result += passed ? "L" : "-";
            }
            catch (Exception ex)
            {
                Console.WriteLine("FAIL\n" + ex);
                result += "-";
            }

            // Test M: Reverse sorted array — worst-case for QuickSort without randomization
            Console.Write("Test M: Reverse sorted array ... ");
            try
            {
                bool passed = true;
                foreach (var sorter in sorters)
                {
                    int[] reversed = [5, 4, 3, 2, 1];
                    sorter.Sort(reversed, 0, 5, new AscendingIntComparer());
                    for (int i = 0; i < reversed.Length - 1; i++)
                        if (reversed[i] > reversed[i + 1])
                            passed = false;
                }
                Console.WriteLine(passed ? "SUCCESS" : "FAIL");
                result += passed ? "M" : "-";
            }
            catch (Exception ex)
            {
                Console.WriteLine("FAIL\n" + ex);
                result += "-";
            }

            // Test N: Array with all duplicate values — tests equal-element handling
            Console.Write("Test N: Array with all duplicates ... ");
            try
            {
                bool passed = true;
                foreach (var sorter in sorters)
                {
                    int[] dupes = [7, 7, 7, 7, 7];
                    sorter.Sort(dupes, 0, 5, new AscendingIntComparer());
                    for (int i = 0; i < dupes.Length; i++)
                        if (dupes[i] != 7)
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

            // Test O: Sorting a sub-range only — elements outside the range must stay untouched
            Console.Write("Test O: Sub-range sort (middle of array) ... ");
            try
            {
                bool passed = true;
                foreach (var sorter in sorters)
                {
                    int[] arr = [99, 5, 3, 4, 1, 88];
                    sorter.Sort(arr, 1, 4, new AscendingIntComparer());
                    if (arr[0] != 99 || arr[5] != 88)
                        passed = false;
                    for (int i = 1; i < 4; i++)
                        if (arr[i] > arr[i + 1])
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

            // Test P: Negative numbers
            Console.Write("Test P: Negative numbers ... ");
            try
            {
                bool passed = true;
                foreach (var sorter in sorters)
                {
                    int[] neg = [-3, -1, -5, 0, 2, -4];
                    sorter.Sort(neg, 0, 6, new AscendingIntComparer());
                    for (int i = 0; i < neg.Length - 1; i++)
                        if (neg[i] > neg[i + 1])
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

            // Test Q: Large array (1000 elements) — stress test
            Console.Write("Test Q: Large array (1000 elements) ... ");
            try
            {
                bool passed = true;
                Random rng = new Random(42);
                foreach (var sorter in sorters)
                {
                    int[] large = new int[1000];
                    for (int i = 0; i < large.Length; i++)
                        large[i] = rng.Next(-5000, 5000);
                    sorter.Sort(large, 0, 1000, new AscendingIntComparer());
                    for (int i = 0; i < large.Length - 1; i++)
                        if (large[i] > large[i + 1])
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

            // Test R: Sorting strings — verify generic type works beyond int
            Console.Write("Test R: Sort strings descending ... ");
            try
            {
                bool passed = true;
                foreach (var sorter in sorters)
                {
                    string[] names = ["Charlie", "Alice", "Eve", "Bob", "Dave"];
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
                result += passed ? "R" : "-";
            }
            catch (Exception ex)
            {
                Console.WriteLine("FAIL\n" + ex);
                result += "-";
            }

            // Test S: Two element array — minimal swap scenario
            Console.Write("Test S: Two element array ... ");
            try
            {
                bool passed = true;
                foreach (var sorter in sorters)
                {
                    int[] two = [9, 1];
                    sorter.Sort(two, 0, 2, new AscendingIntComparer());
                    if (two[0] != 1 || two[1] != 9)
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

            Console.WriteLine("\n\n ------------------- SUMMARY ------------------- ");
            Console.WriteLine("Tests passed: " + result);
            Console.ReadKey();
        }
    }
}
