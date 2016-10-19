using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1;

namespace Task1.ConsoleTests
{
    class Program
    {
        private int[] oddArrayDifference = new int[7] { 0, 2, 4, 6, 8, 10, 24 };
        private int[] evenArrayDifference = new int[6] { 0, 2, 4, 6, 8, 25 };
        private int[] oddArraySame = new int[11] { 1, 1, 3, 3, 3, 5, 5, 7, 7, 7, 7 };
        private int[] evenArraySame = new int[10] { 1, 1, 3, 3, 3, 5, 7, 7, 7, 7 };

        private int[,] testOddNegativeSame = new int[,]
        {
            { -1,  2,  4,  6,  8 },
            { -1, -3, -6, -8, -12 }
        };

        private int[,] testEvenNegativeSame = new int[,]
        {
            { -1,  2,  4,  6,  8},
            { -1, -3, -6, -7, -11}
        };

        private int[,] testEvenNegativeDifference = new int[,]
        {
            { -5,  1,  3,  5,  7,  9,  26 },
            { -1, -2, -3, -4,  -5, -6, -7 }
        };

        private int[,] testOddNegativeDifference = new int[,]
        {
            { -5,  1,  3,  5,  7,  9,  11, 26 },
            { -1, -2, -3, -4,  -5, -6, -7, -8 }
        };

        private int[,] testEvenPositiveSame = new int[,]
        {
            { 1, 3, 5, 7, },
            { 1, 4, 5, 9, }
        };

        private int[,] testOddPositiveSame = new int[,]
        {
            { 1, 3, 5, 7, },
            { 1, 4, 6, 10, }
        };

        private int[,] testEvenPositiveDifference = new int[,]
        {
            { 0, 2, 4, 6, 8, 25},
            { 0, 1, 2, 3, 4, 5}
        };

        private int[,] testOddPositiveDifference = new int[,]
        {
            { 0, 2, 4, 6, 8, 10, 24},
            { 0, 1, 2, 3, 4, 5, 6 },
        };

        static void Main(string[] args)
        {
            int[] array = new int[20];
            Random rand = new Random();
            for (int i = 0; i < array.Length; i++)
                array[i] = rand.Next();
            
            Console.WriteLine(BinarySearcher.BinarySearch(array, 40));
        }
    }
}
