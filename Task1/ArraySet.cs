using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class ArraySet : ISetInteger
    {
        private int[] array;
        private int pos;

        private void EnlargeArray()
        {
            int[] temp = new int[array.Length * 2];
            for (int i = 0; i < pos; i++)
            {
                temp[i] = array[i];
            }
            array = temp;
        }

        private int HasElement(int x)
        {
            for (int i = 0; i < pos; i++)
            {
                if (array[i] == x)
                {
                    return i;
                }
            }
            return -1;
        }

        private void Delete(int ps)
        {
            for (int i = ps + 1; i < pos; i++)
            {
                array[i - 1] = array[i];
            }
            pos--;
        }

        public ArraySet(int n = 20)
        {
            array = new int[n];
            pos = 0;
        }

        public bool Add(int x)
        {
            if (Contains(x))
                return false;
            if (pos >= array.Length)
            {
                EnlargeArray();
            }
            array[pos++] = x;
            return true;
        }

        public void Clear()
        {
            pos = 0;
        }

        public bool Contains(int x)
        {
            if (HasElement(x) == -1)
                return false;
            return true;
        }

        public bool Remove(int x)
        {
            int ps = HasElement(x);
            if (ps != -1)
            {
                Delete(ps);
                return true;
            }
            return false;
        }

        public void ExceptWith(ISetInteger other)
        {
            for (int i = 0; i < pos; i++)
            {
                if (other.Contains(array[i]))
                {
                    Delete(i);
                    i--;
                }
            }
        }

        public void IntersectWith(ISetInteger other)
        {
            for (int i = 0; i < pos; i++)
            {
                if (!other.Contains(array[i]))
                {
                    Delete(i);
                    i--;
                }
            }
        }

        public void SymmetricExceptWith(ISetInteger other)
        {
            foreach (int x in other)
            {
                int ps = HasElement(x);
                if (ps != -1)
                    Delete(ps);
                else
                    Add(x);
            }
        }

        public void UnionWith(ISetInteger other)
        {
            foreach (int x in other)
            {
                Add(x);
            }
        }

        public IEnumerator GetEnumerator()
        {
            return new ArrayIntEnumerator(array, pos);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private class ArrayIntEnumerator : IEnumerator
        {
            private int[] array;
            private int pos = -1;
            private int size;

            public ArrayIntEnumerator(int[] array, int size)
            {
                this.array = array;
                this.size = size;
            }

            public int Current
            {
                get
                {
                    try
                    {
                        return array[pos];
                    }
                    catch (IndexOutOfRangeException)
                    {
                        throw new InvalidOperationException();
                    }

                }
            }

            object IEnumerator.Current
            {
                get
                {
                    return Current;
                }
            }

            public bool MoveNext()
            {
                return ++pos < size;
            }

            public void Reset()
            {
                pos = -1;
            }
        }
    }
}
