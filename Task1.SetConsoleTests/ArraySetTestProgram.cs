using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.SetConsoleTests
{
    class ArraySetTestProgram
    {
        static private ISetInteger set1;
        static private ISetInteger set2;

        static public void Init()
        {
            set1 = new ArraySet(1);
            set2 = new ArraySet(1);
        }

        static void Main(string[] args)
        {
            CheckFunction(CanAddElements, "Add elements function:");
            CheckFunction(CanRemoveElements, "Remove elements function:");
            CheckFunction(CanClearElements, "Clear elements function:");
            CheckFunction(CanExcept, "Except set function:");
            CheckFunction(CanIntersect, "Intersect set function:");
            CheckFunction(CanUnion, "Union set function: ");
            CheckFunction(CanSymmetricExcept, "Symmetric except set function:");
        }
        
        static void CheckFunction(Func<bool> func, string message)
        {
            if (func())
                Console.WriteLine(message + " OK");
            else
                Console.WriteLine(message + " FAILED");
        }

        static public bool CanAddElements()
        {
            //arrange
            Init();
            //act
            set1.Add(1);
            set1.Add(1);
            set1.Add(3);
            set1.Add(2);
            //assert
            if (!set1.Contains(1))
                return false;
            if (!set1.Contains(3))
                return false;
            if (!set1.Contains(2))
                return false;
            if (set1.Contains(4))
                return false;
            return true;
        }

        static public bool CanRemoveElements()
        {
            //arrange
            Init();
            set1.Add(1);
            set1.Add(1);
            set1.Add(2);
            set1.Add(3);
            //act
            set1.Remove(2);
            set1.Remove(1);
            //assert
            if (set1.Contains(1))
                return false;
            if (set1.Contains(2))
                return false;
            if (!set1.Contains(3))
                return false;
            return true;
        }
        
        static public bool CanClearElements()
        {
            //arrange
            Init();
            set1.Add(1);
            set1.Add(2);
            set1.Add(3);
            //act
            set1.Clear();
            //assert
            if (set1.Contains(1))
                return false;
            if(set1.Contains(2))
                return false;
            if (set1.Contains(3))
                return false;
            return true;
        }
        
        static public bool CanIntersect()
        {
            //arrange
            Init();
            int[] s1 = { 1, 2, 3 }, s2 = { 2, 3, 4 };
            int[] arFalse = { 1, 4 }, arTrue = { 2, 3 };
            foreach (int x in s1)
            {
                set1.Add(x);
            }
            foreach (int x in s2)
            {
                set2.Add(x);
            }
            //act
            set1.IntersectWith(set2);
            //assert
            foreach (int x in arFalse)
            {
                if (set1.Contains(x))
                    return false;
            }
            foreach (int x in arTrue)
            {
                if (!set1.Contains(x))
                    return false;
            }
            return true;
        }
        
        static public bool CanExcept()
        {
            //arrange
            Init();
            int[] s1 = { 1, 2, 3 }, s2 = { 2, 3, 4 };
            int[] arFalse = { 2, 3, 4 }, arTrue = { 1 };
            foreach (int x in s1)
            {
                set1.Add(x);
            }
            foreach (int x in s2)
            {
                set2.Add(x);
            }
            //act
            set1.ExceptWith(set2);
            //assert
            foreach (int x in arFalse)
            {
                if (set1.Contains(x))
                    return false;
            }
            foreach (int x in arTrue)
            {
                if (!set1.Contains(x))
                    return false;
            }
            return true;
        }
        
        static public bool CanUnion()
        {
            //arrange
            Init();
            int[] s1 = { 1, 2, 3 }, s2 = { 2, 3, 4, 5 };
            int[] arFalse = { 5 }, arTrue = { 1, 2, 3, 4 };
            foreach (int x in s1)
            {
                set1.Add(x);
            }
            foreach (int x in s2)
            {
                set2.Add(x);
            }
            set2.Remove(5);
            //act
            set1.UnionWith(set2);
            //assert
            foreach (int x in arFalse)
            {
                if (set1.Contains(x))
                    return false;
            }
            foreach (int x in arTrue)
            {
                if (!set1.Contains(x))
                    return false;
            }
            return true;
        }
        
        static public bool CanSymmetricExcept()
        {
            //arrange
            Init();
            int[] s1 = { 1, 2, 3 }, s2 = { 2, 3, 4, 5 };
            int[] arFalse = { 2, 3, 5 }, arTrue = { 1, 4 };
            foreach (int x in s1)
            {
                set1.Add(x);
            }
            foreach (int x in s2)
            {
                set2.Add(x);
            }
            set2.Remove(5);
            //act
            set1.SymmetricExceptWith(set2);
            //assert
            foreach (int x in arFalse)
            {
                if (set1.Contains(x))
                    return false;
            }
            foreach (int x in arTrue)
            {
                if (set1.Contains(x))
                    return false;
            }
            return true;
        }
        
    }
}
