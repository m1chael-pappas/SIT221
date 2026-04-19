using System;
using System.Collections.Generic;

namespace SortingOrder
{
    // Invoked from Tester.Main after the per-case loop. Runs the full
    // generator sweep (cases 0..27) plus randomised stress cases to
    // confirm the solver behaves correctly beyond the public tests.
    internal static class ExtraSweep
    {
        public static void Run()
        {
            int pass = 0,
                fail = 0;
            var failures = new List<string>();

            // 1. Run every hard-coded case in TestGenerator (0..27).
            for (int i = 0; i <= 27; i++)
            {
                string[] a1;
                int[] a2;
                int[] a3;
                string expected = TestGenerator.Generate(i, out a1, out a2, out a3);
                if (a1 == null)
                    continue;
                string got = SortingOrder.Solve(a1, a2, a3);
                if (got == expected)
                    pass++;
                else
                {
                    fail++;
                    failures.Add($"case {i}: expected {expected}, got {got}");
                }
            }

            // 2. Brute-force stress: for every rule R in {NAW,NWA,ANW,AWN,WAN,WNA},
            //    generate a small random tuple set, sort by R, then confirm
            //    Solve returns R OR IND (IND is legal if another rule also fits).
            string[] rules = { "NAW", "NWA", "ANW", "AWN", "WAN", "WNA" };
            Comparison<(string n, int a, int w)>[] cmps =
            {
                (x, y) => CompareTuple(x, y, 0, 1, 2),
                (x, y) => CompareTuple(x, y, 0, 2, 1),
                (x, y) => CompareTuple(x, y, 1, 0, 2),
                (x, y) => CompareTuple(x, y, 1, 2, 0),
                (x, y) => CompareTuple(x, y, 2, 1, 0),
                (x, y) => CompareTuple(x, y, 2, 0, 1),
            };

            var rand = new Random(42);
            int stressTotal = 0;
            for (int trial = 0; trial < 2000; trial++)
            {
                for (int ruleIdx = 0; ruleIdx < 6; ruleIdx++)
                {
                    int n = 1 + rand.Next(8);
                    var list = new List<(string n, int a, int w)>();
                    for (int k = 0; k < n; k++)
                    {
                        int len = 1 + rand.Next(3);
                        var sb = new System.Text.StringBuilder();
                        for (int j = 0; j < len; j++)
                            sb.Append((char)('A' + rand.Next(3)));
                        int age = 1 + rand.Next(5);
                        int weight = 1 + rand.Next(5);
                        list.Add((sb.ToString(), age, weight));
                    }
                    list.Sort(cmps[ruleIdx]);

                    var names = new string[n];
                    var ages = new int[n];
                    var weights = new int[n];
                    for (int k = 0; k < n; k++)
                    {
                        names[k] = list[k].n;
                        ages[k] = list[k].a;
                        weights[k] = list[k].w;
                    }

                    string got = SortingOrder.Solve(names, ages, weights);
                    stressTotal++;
                    // The sorted data must be consistent with rules[ruleIdx].
                    // Solve may return rules[ruleIdx] or IND; both are correct.
                    // NOT is a bug. Any *different* single rule is also a bug.
                    if (got == "NOT")
                    {
                        fail++;
                        failures.Add(
                            $"stress trial {trial} rule {rules[ruleIdx]}: got NOT on a valid ordering | names=[{string.Join(',', names)}] ages=[{string.Join(',', ages)}] weights=[{string.Join(',', weights)}]"
                        );
                    }
                    else if (got != "IND" && got != rules[ruleIdx])
                    {
                        fail++;
                        failures.Add(
                            $"stress trial {trial} rule {rules[ruleIdx]}: got {got} | names=[{string.Join(',', names)}] ages=[{string.Join(',', ages)}] weights=[{string.Join(',', weights)}]"
                        );
                    }
                    else
                        pass++;
                }
            }

            Console.WriteLine(
                $"\n=== Extra sweep: {pass} passed, {fail} failed (generator 0..27 + {stressTotal} stress cases) ==="
            );
            foreach (var f in failures)
                Console.WriteLine("  " + f);
        }

        private static int CompareTuple(
            (string n, int a, int w) x,
            (string n, int a, int w) y,
            int p,
            int s,
            int t
        )
        {
            int c = CmpField(x, y, p);
            if (c != 0)
                return c;
            c = CmpField(x, y, s);
            if (c != 0)
                return c;
            return CmpField(x, y, t);
        }

        private static int CmpField(
            (string n, int a, int w) x,
            (string n, int a, int w) y,
            int field
        )
        {
            switch (field)
            {
                case 0:
                    return string.CompareOrdinal(x.n, y.n);
                case 1:
                    return x.a.CompareTo(y.a);
                case 2:
                    return y.w.CompareTo(x.w); // descending
                default:
                    throw new Exception();
            }
        }
    }
}
