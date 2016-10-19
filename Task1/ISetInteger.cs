using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public interface ISetInteger : IEnumerable
    {
        bool Add(int x);
        bool Remove(int x);
        bool Contains(int x);
        void Clear();
        void IntersectWith(ISetInteger other);
        void ExceptWith(ISetInteger other);
        void UnionWith(ISetInteger other);
        void SymmetricExceptWith(ISetInteger other);
    }
}
