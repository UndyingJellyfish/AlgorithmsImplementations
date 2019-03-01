using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DamsboSoftware.AlgorithmImplementations.Utilities;
using LinearProgramming;

namespace TestingBench
{
    class Program
    {
        private static List<List<int>> test = new List<List<int>> { 
            new List<int> { 82,  83,  69,  92, },
            new List<int> { 77,  37,  49,  92, },
            new List<int> { 11,  69,  5,   86, },
            new List<int> { 8,   9,   98,  23, },
        };

        private static int[,] test2 =
        {
            { 82,  83,  69,  92, },
            { 77,  37,  49,  92, },
            { 11,  69,  5,   86, },
            { 8,   9,   98,  23, },
        };

        static void Main(string[] args)
        {
            
            Console.WriteLine(EnumerableHelper<int>.PrettyPrintList(test));
            Console.WriteLine(EnumerableHelper<int>.PrettyPrintMatrix(test2));
            Console.WriteLine(EnumerableHelper<int>.PrettyPrintArray(test2.FindAssignments()));
            Console.ReadLine();
        }
    }
}
