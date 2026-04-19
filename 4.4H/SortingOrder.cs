using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace SortingOrder
{
    public class SortingOrder
    {
        private const int NAME = 0;
        private const int AGE = 1;
        private const int WEIGHT = 2;

        private static readonly string[] RuleLabels = ["NAW", "NWA", "ANW", "AWN", "WAN", "WNA"];

        private static readonly int[][] RuleFields =
        [
            [NAME, AGE, WEIGHT], // NAW
            [NAME, WEIGHT, AGE], // NWA
            [AGE, NAME, WEIGHT], // ANW
            [AGE, WEIGHT, NAME], // AWN
            [WEIGHT, AGE, NAME], // WAN
            [WEIGHT, NAME, AGE], // WNA
        ];

        public static string Solve(string[] name, int[] age, int[] weight)
        {
            if (name == null || age == null || weight == null)
                throw new ArgumentNullException("Input arrays must not be null.");
            if (name.Length != age.Length || age.Length != weight.Length)
                throw new ArgumentException("All three arrays must have the same length.");

            int n = name.Length;

            // With 0 or 1 element, every rule is trivially valid.
            if (n <= 1)
                return "IND";

            int validCount = 0;
            string onlyMatch = null;
            for (int r = 0; r < RuleLabels.Length; r++)
            {
                int[] fields = RuleFields[r];
                if (IsConsistent(name, age, weight, fields[0], fields[1], fields[2]))
                {
                    validCount++;
                    onlyMatch = RuleLabels[r];
                    if (validCount > 1)
                        return "IND";
                }
            }

            if (validCount == 0)
                return "NOT";
            return onlyMatch;
        }

        // Returns < 0 if element i precedes element j under the field's sort
        // direction, 0 if they tie, and > 0 if element i should come after j.
        private static int CompareField(
            string[] name,
            int[] age,
            int[] weight,
            int field,
            int i,
            int j
        )
        {
            return field switch
            {
                NAME => string.CompareOrdinal(name[i], name[j]),
                AGE => age[i].CompareTo(age[j]),
                WEIGHT => weight[j].CompareTo(weight[i]),
                _ => throw new ArgumentOutOfRangeException(nameof(field)),
            };
        }

        // Tests whether the existing array order is consistent with the rule
        // (primary -> secondary -> tertiary). A tie on all three fields is
        // permitted (true duplicates may appear in either order).
        private static bool IsConsistent(
            string[] name,
            int[] age,
            int[] weight,
            int primary,
            int secondary,
            int tertiary
        )
        {
            int n = name.Length;
            for (int i = 0; i < n - 1; i++)
            {
                int cmp = CompareField(name, age, weight, primary, i, i + 1);
                if (cmp < 0)
                    continue;
                if (cmp > 0)
                    return false;

                cmp = CompareField(name, age, weight, secondary, i, i + 1);
                if (cmp < 0)
                    continue;
                if (cmp > 0)
                    return false;

                cmp = CompareField(name, age, weight, tertiary, i, i + 1);
                if (cmp > 0)
                    return false;
            }
            return true;
        }
    }
}
