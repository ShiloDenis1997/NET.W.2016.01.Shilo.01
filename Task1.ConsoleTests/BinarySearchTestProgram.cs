using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1;

namespace Task1.ConsoleTests
{
    class BinarySearchTestProgram
    {
        static private int[] oddArrayDifference = new int[7] { 0, 2, 4, 6, 8, 10, 24 };
        static private int[] evenArrayDifference = new int[6] { 0, 2, 4, 6, 8, 25 };
        static private int[] oddArraySame = new int[11] { 1, 1, 3, 3, 3, 5, 5, 7, 7, 7, 7 };
        static private int[] evenArraySame = new int[10] { 1, 1, 3, 3, 3, 5, 7, 7, 7, 7 };

        static private int[,] testOddNegativeSame = new int[,]
        {
            {-1, -1 },
            {2, -3 },
            {4, -6 },
            {6, -8 },
            {8, -12 },
        };

        static private int[,] testEvenNegativeSame = new int[,]
        {
            {-1, -1 },
            {2, -3 },
            {4, -6 },
            {6, -7 },
            {8, -11 },
        };

        static private int[,] testEvenNegativeDifference = new int[,]
        {
            {-5, -1 },
            {1, -2 },
            {3, -3 },
            {5, -4 },
            {7, -5 },
            {9, -6 },
            {26, -7 },
        };

        static private int[,] testOddNegativeDifference = new int[,]
        {
            {-5, -1 },
            {1, -2 },
            {3, -3 },
            {5, -4 },
            {7, -5 },
            {9, -6 },
            {11, -7 },
            {26, -8 },
        };

        static private int[,] testEvenPositiveSame = new int[,]
        {
            {1, 1 },
            {3, 4 },
            {5, 5 },
            {7, 9 },
        };

        static private int[,] testOddPositiveSame = new int[,]
        {
            {1, 1 },
            {3, 4 },
            {5, 6 },
            {7, 10 },
        };

        static private int[,] testEvenPositiveDifference = new int[,]
        {
            {0, 0 },
            {2, 1 },
            {4, 2 },
            {6, 3 },
            {8, 4 },
            {25, 5 },
        };

        static private int[,] testOddPositiveDifference = new int[,]
        {
            {0, 0 },
            {2, 1 },
            {4, 2 },
            {6, 3 },
            {8, 4 },
            {10, 5 },
            {24, 6 },
        };

        static int testNumber = 1;
        static int totalOk = 0;
        static int totalFailed = 0;

        static void Main(string[] args)
        {
            //Positive tests
            TestCase(oddArrayDifference, testOddPositiveDifference);
            TestCase(oddArraySame, testOddPositiveSame);
            TestCase(evenArrayDifference, testEvenPositiveDifference);
            TestCase(evenArraySame, testEvenPositiveSame);

            //Negative tests
            TestCase(oddArrayDifference, testOddNegativeDifference);
            TestCase(oddArraySame, testOddNegativeSame);
            TestCase(evenArrayDifference, testEvenNegativeDifference);
            TestCase(evenArraySame, testEvenNegativeSame);

            Console.WriteLine(String.Format("Total OK: {0}\n Total FAILED: {1}",
                        totalOk, totalFailed));
        }

        public static void TestCase(int[] array, int[,] testCase)
        {
            for (int i = 0; i < testCase.GetLength(0); i++)
            {
                Console.WriteLine("Test #" + testNumber++);
                Console.Write("Array to test: ");
                foreach (int x in array)
                {
                    Console.Write(x + " ");
                }
                Console.WriteLine("\nValue to search: " + testCase[i, 0]);
                int res = BinarySearcher.BinarySearch(array, testCase[i, 0]);
                Console.WriteLine(String.Format("Expected: {0} \t Got: {1}",
                        testCase[i, 1], res));
                if (res == testCase[i, 1])
                {
                    totalOk++;
                    Console.WriteLine("Ok");
                }
                else
                {
                    totalFailed++;
                    Console.WriteLine("Failed");
                }
            }
        }
        
    }
}
