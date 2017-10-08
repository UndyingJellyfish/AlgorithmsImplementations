using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strings
{
    public class LongestCommonSubsequence
    {
        public static string lcs_Dynamic(string s1, string s2)
        {
            int[,] lengths = new int[s1.Length + 1, s2.Length + 1];

            for (int i = 0; i < s1.Length; i++)
            {
                for (int j = 0; j < s2.Length; j++)
                {
                    if (s1[i] == s2[j])
                    {
                        lengths[i + 1, j + 1] = lengths[i, j] + 1;
                    }
                    else
                    {
                        lengths[i + 1, j + 1] = Math.Max(lengths[i + 1, j], lengths[i, j + 1]);
                    }
                }
            }

            StringBuilder sb = new StringBuilder();

            for (int x = s1.Length, y = s2.Length; x != 0 && y != 0;)
            {
                if (lengths[x, y] == lengths[x - 1, y])
                {
                    x--;
                }
                else if (lengths[x, y] == lengths[x, y - 1])
                {
                    y--;
                }
                else
                {
                    Debug.Assert(s1[x - 1] == s2[y - 1]);

                    sb.Append(s1[x - 1]);
                    x--;
                    y--;

                }
            }
            string output = sb.ToString();

            return reverse(output);
        }

        private static string reverse(string s)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = s.Length - 1; i >= 0; i--)
            {
                sb.Append(s[i]);
            }
            return sb.ToString();
        }
    }
}
