using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public static class BinarySearcher
    {
        public static int BinarySearch<T>(T[] array, T x) where T : IComparable
        {
            int left = 0, right = array.Length, middle;
            while (left + 1 < right)
            {
                middle = (left >> 1) + (right >> 1) + (1 & left & right);
                if (array[middle].CompareTo(x) <= 0)
                {
                    left = middle;
                }
                else
                {
                    right = middle;
                }
            }
            if (array[left].CompareTo(x) == 0)
            {
                return left;
            }
            if (array[left].CompareTo(x) > 0)
            {
                return -left - 1;
            }
            return -left - 2;
        }
    }
}
