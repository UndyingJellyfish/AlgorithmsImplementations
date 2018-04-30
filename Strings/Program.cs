using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            string in1 = Console.ReadLine();
            string in2 = Console.ReadLine();

            Console.WriteLine(LongestCommonSubsequence.lcs_Dynamic(in1, in2));
        }
    }
}
