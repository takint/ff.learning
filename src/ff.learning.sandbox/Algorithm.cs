using System;
using System.Collections.Generic;
using System.Text;

namespace ff.learning.sandbox
{
    public class Algorithm
    {
        public const string EMAIL_REG = @"/^[a-z0-9!#$%&'*+\/=?^_`{|}~.-]+@[a-z0-9]([a-z0-9-]*[a-z0-9])?(\.[a-z0-9]([a-z0-9-]*[a-z0-9])?)*$/i";

        public static int[] CyclicRotationSolution(int[] n, int k)
        {
            int[] result = n;

            for (int i = 0; i < k; i++)
            {
                result = CyclicRotation(result);
            }

            return result;
        }

        public static int[] CyclicRotation(int[] n)
        {
            if (n.Length == 0)
            {
                return n;
            }

            int[] result = new int[n.Length];
            int loops = n.Length - 1;

            result[0] = n[loops];

            for (int i = 0; i < loops; i++)
            {
                result[i + 1] = n[i];
            }

            return result;
        }

        public static bool CheckSquare(int n)
        {
            return (n & (n - 1)) == 0;
        }

        public static int OrrcurArray(int[] A)
        {
            int result = 0;
            for (int i = 0; i < A.Length; i++)
            {
                result ^= A[i];
            }

            return result;
        }

        public static int Levenshtein(string strLeft, string strRight)
        {
            string S1 = strLeft.ToUpper();
            string S2 = strRight.ToUpper();

            int lenLeft = S1.Length;
            int lenRight = S2.Length;

            int[,] diffs = new int[lenLeft + 1, lenRight + 1];
            int cost = 0;

            if (lenLeft + lenRight == 0)
            {
                return 100;
            }
            else if (lenLeft == 0)
            {
                return 0;
            }
            else if (lenRight == 0)
            {
                return 0;
            }

            for (int i = 0; i <= lenLeft; i++)
            {
                diffs[i, 0] = i;
            }

            for (int j = 0; j <= lenRight; j++)
            {
                diffs[0, j] = j;
            }

            for (int i = 1; i <= lenLeft; i++)
            {
                for (int j = 1; j <= lenRight; j++)
                {
                    cost = S1[i - 1] == S2[j - 1] ? 0 : 1;

                    diffs[i, j] = Math.Min(Math.Min(diffs[i - 1, j] + 1, diffs[i, j - 1] + 1), diffs[i - 1, j - 1] + cost);
                }
            }

            return diffs[lenLeft, lenRight];
        }
    }
}
