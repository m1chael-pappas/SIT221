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

    // IComparable<Student> lets the Student type compare itself to another Student.
    // CompareTo is called by Sort() (no comparer argument) via Comparer<T>.Default.
    // Ascending ID order means a lower ID should come first, so we return this.Id - another.Id.
    public class Student : IComparable<Student>
    {
        public string Name { get; set; }
        public int Id { get; set; }

        public override string ToString()
        {
            return Id + "[" + Name + "]";
        }

        // Compares this student to another by ID in ascending order.
        // Returns negative  -> this comes first
        // Returns zero      -> equal
        // Returns positive  -> another comes first
        public int CompareTo(Student another)
        {
            if (another == null)
                return 1;
            return this.Id - another.Id;
        }
    }

    // Comparator class: compares two Student objects by ID ascending.
    // Implements IComparer<Student> so it can be passed to Sort(IComparer<T> comparer).
    // This is separate from the Student class itself -- it is an independent comparison strategy.
    public class AscendingIDComparer : IComparer<Student>
    {
        public int Compare(Student a, Student b)
        {
            if (a == null && b == null)
                return 0;
            if (a == null)
                return -1;
            if (b == null)
                return 1;
            return a.Id - b.Id;
        }
    }

    // Comparator class: sorts students by Name descending, breaking ties by ID descending.
    // String.Compare with StringComparison.Ordinal gives consistent, culture-neutral ordering.
    // We reverse the arguments (b before a) to get descending name order.
    // If names are equal, we then sort by ID descending (b.Id - a.Id).
    public class DescendingNameDescendingIdComparer : IComparer<Student>
    {
        public int Compare(Student a, Student b)
        {
            if (a == null && b == null)
                return 0;
            if (a == null)
                return -1;
            if (b == null)
                return 1;
            int nameComparison = string.Compare(b.Name, a.Name, StringComparison.Ordinal);
            if (nameComparison != 0)
                return nameComparison;
            return b.Id - a.Id;
        }
    }

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
                Console.WriteLine("\nTest A: Run a sequence of operations: ");
                Console.WriteLine(
                    "Create a new vector by calling 'Vector<int> vector = new Vector<int>(50);'"
                );
                vector = new Vector<int>(50);
                Console.WriteLine(
                    "Add a sequence of numbers 2, 6, 8, 5, 5, 1, 8, 5, 3, 5, 7, 1, 4, 9"
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
                vector.Add(7);
                vector.Add(1);
                vector.Add(4);
                vector.Add(9);
                if (
                    !CheckIntSequence(
                        new int[] { 2, 6, 8, 5, 5, 1, 8, 5, 3, 5, 7, 1, 4, 9 },
                        vector
                    )
                )
                    throw new Exception(
                        "Vector stores an incorrect sequence of integers after adding new elements"
                    );
                Console.WriteLine(
                    "Sort the integers in the default order defined by the native CompareTo() method"
                );
                vector.Sort();
                int[] array = new int[] { 2, 6, 8, 5, 5, 1, 8, 5, 3, 5, 7, 1, 4, 9 };
                Array.Sort(array, 0, 14);
                Console.WriteLine("Resulting order: " + vector.ToString());
                if (!CheckIntSequence(array, vector))
                    throw new Exception(
                        "Vector stores an incorrect sequence of integers after sorting them"
                    );
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
                Console.WriteLine("\nTest B: Run a sequence of operations: ");
                Console.WriteLine(
                    "Create a new vector by calling 'Vector<int> vector = new Vector<int>(50);'"
                );
                vector = new Vector<int>(50);
                Console.WriteLine(
                    "Add a sequence of numbers 2, 6, 8, 5, 5, 1, 8, 5, 3, 5, 7, 1, 4, 9"
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
                vector.Add(7);
                vector.Add(1);
                vector.Add(4);
                vector.Add(9);
                if (
                    !CheckIntSequence(
                        new int[] { 2, 6, 8, 5, 5, 1, 8, 5, 3, 5, 7, 1, 4, 9 },
                        vector
                    )
                )
                    throw new Exception(
                        "Vector stores an incorrect sequence of integers after adding new elements"
                    );
                Console.WriteLine(
                    "Sort the integers in the order defined by the AscendingIntComparer class"
                );
                vector.Sort(new AscendingIntComparer());
                int[] array = new int[] { 2, 6, 8, 5, 5, 1, 8, 5, 3, 5, 7, 1, 4, 9 };
                Array.Sort(array, 0, 14, new AscendingIntComparer());
                Console.WriteLine("Resulting order: " + vector.ToString());
                if (!CheckIntSequence(array, vector))
                    throw new Exception(
                        "Vector stores an incorrect sequence of integers after sorting them"
                    );
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
                Console.WriteLine("\nTest C: Run a sequence of operations: ");
                Console.WriteLine(
                    "Create a new vector by calling 'Vector<int> vector = new Vector<int>(50);'"
                );
                vector = new Vector<int>(50);
                Console.WriteLine(
                    "Add a sequence of numbers 2, 6, 8, 5, 5, 1, 8, 5, 3, 5, 7, 1, 4, 9"
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
                vector.Add(7);
                vector.Add(1);
                vector.Add(4);
                vector.Add(9);
                if (
                    !CheckIntSequence(
                        new int[] { 2, 6, 8, 5, 5, 1, 8, 5, 3, 5, 7, 1, 4, 9 },
                        vector
                    )
                )
                    throw new Exception(
                        "Vector stores an incorrect sequence of integers after adding new elements"
                    );
                Console.WriteLine(
                    "Sort the integers in the order defined by the DescendingIntComparer class"
                );
                vector.Sort(new DescendingIntComparer());
                int[] array = new int[] { 2, 6, 8, 5, 5, 1, 8, 5, 3, 5, 7, 1, 4, 9 };
                Array.Sort(array, 0, 14, new DescendingIntComparer());
                Console.WriteLine("Resulting order: " + vector.ToString());
                if (!CheckIntSequence(array, vector))
                    throw new Exception(
                        "Vector stores an incorrect sequence of integers after sorting them"
                    );
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
                Console.WriteLine("\nTest D: Run a sequence of operations: ");
                Console.WriteLine(
                    "Create a new vector by calling 'Vector<int> vector = new Vector<int>(50);'"
                );
                vector = new Vector<int>(50);
                Console.WriteLine(
                    "Add a sequence of numbers 2, 6, 8, 5, 5, 1, 8, 5, 3, 5, 7, 1, 4, 9"
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
                vector.Add(7);
                vector.Add(1);
                vector.Add(4);
                vector.Add(9);
                if (
                    !CheckIntSequence(
                        new int[] { 2, 6, 8, 5, 5, 1, 8, 5, 3, 5, 7, 1, 4, 9 },
                        vector
                    )
                )
                    throw new Exception(
                        "Vector stores an incorrect sequence of integers after adding new elements"
                    );
                Console.WriteLine(
                    "Sort the integers in the order defined by the EvenNumberFirstComparer class"
                );
                vector.Sort(new EvenNumberFirstComparer());
                int[] array = new int[] { 2, 6, 8, 5, 5, 1, 8, 5, 3, 5, 7, 1, 4, 9 };
                Array.Sort(array, 0, 14, new EvenNumberFirstComparer());
                Console.WriteLine("Resulting order: " + vector.ToString());
                if (!CheckIntSequence(array, vector))
                    throw new Exception(
                        "Vector stores an incorrect sequence of integers after sorting them"
                    );
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
                string[] names = new string[]
                {
                    "Kelly",
                    "Cindy",
                    "John",
                    "Andrew",
                    "Richard",
                    "Michael",
                    "Guy",
                    "Elicia",
                    "Tom",
                    "Iman",
                    "Simon",
                    "Vicky",
                };
                Random random = new Random(100);
                Console.WriteLine("\nTest E: Run a sequence of operations: ");
                Console.WriteLine(
                    "Create a new vector of Student objects by calling 'Vector<Student> students = new Vector<Student>();'"
                );
                Vector<Student> students = new Vector<Student>();
                for (int i = 0; i < 14; i++)
                {
                    Student student = new Student()
                    {
                        Name = names[random.Next(0, names.Length)],
                        Id = i,
                    };
                    Console.WriteLine("Add student with record: " + student.ToString());
                    students.Add(student);
                }
                Console.WriteLine(
                    "Sort the students in the default order defined by the native CompareTo() method"
                );
                students.Sort();
                Console.WriteLine("Print the vector of students via students.ToString();");
                Console.WriteLine(students.ToString());
                Console.WriteLine(" :: SUCCESS");
                result += "E";
            }
            catch (Exception exception)
            {
                Console.WriteLine(" :: FAIL");
                Console.WriteLine(exception.ToString());
                result += "-";
            }

            // test 6
            try
            {
                string[] names = new string[]
                {
                    "Kelly",
                    "Cindy",
                    "John",
                    "Andrew",
                    "Richard",
                    "Michael",
                    "Guy",
                    "Elicia",
                    "Tom",
                    "Iman",
                    "Simon",
                    "Vicky",
                };
                Random random = new Random(100);
                Console.WriteLine("\nTest F: Run a sequence of operations: ");
                Console.WriteLine(
                    "Create a new vector of Student objects by calling 'Vector<Student> students = new Vector<Student>();'"
                );
                Vector<Student> students = new Vector<Student>();
                for (int i = 0; i < 14; i++)
                {
                    Student student = new Student()
                    {
                        Name = names[random.Next(0, names.Length)],
                        Id = i,
                    };
                    Console.WriteLine("Add student with record: " + student.ToString());
                    students.Add(student);
                }
                Console.WriteLine(
                    "Sort the students in the order defined by the AscendingIDComparer class"
                );
                students.Sort(new AscendingIDComparer());
                Console.WriteLine("Print the vector of students via students.ToString();");
                Console.WriteLine(students.ToString());
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
                string[] names = new string[]
                {
                    "Kelly",
                    "Cindy",
                    "John",
                    "Andrew",
                    "Richard",
                    "Michael",
                    "Guy",
                    "Elicia",
                    "Tom",
                    "Iman",
                    "Simon",
                    "Vicky",
                };
                Random random = new Random(100);
                Console.WriteLine("\nTest G: Run a sequence of operations: ");
                Console.WriteLine(
                    "Create a new vector of Student objects by calling 'Vector<Student> students = new Vector<Student>();'"
                );
                Vector<Student> students = new Vector<Student>();
                for (int i = 0; i < 14; i++)
                {
                    Student student = new Student()
                    {
                        Name = names[random.Next(0, names.Length)],
                        Id = i,
                    };
                    Console.WriteLine("Add student with record: " + student.ToString());
                    students.Add(student);
                }
                Console.WriteLine(
                    "Sort the students in the order defined by the DescendingNameDescendingIdComparer class"
                );
                students.Sort(new DescendingNameDescendingIdComparer());
                Console.WriteLine("Print the vector of students via students.ToString();");
                Console.WriteLine(students.ToString());
                Console.WriteLine(" :: SUCCESS");
                result += "G";
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
