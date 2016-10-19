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
