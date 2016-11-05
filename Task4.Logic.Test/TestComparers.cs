using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4.Logic.Test
{
    public class IncComparer<T> : IComparer<T> where T : IComparable<T>
    {
        public int Compare(T x, T y)
        {
            if (x.CompareTo(y) > 0) { return 1; }
            else if (x.CompareTo(y) < 0)
            { return -1; }
            else { return 0; }
        }
    }

    public class DecComparer<T> : IComparer<T> where T : IComparable<T>
    {
        public int Compare(T x, T y)
        {
            if (x.CompareTo(y) < 0) { return 1; }
            else if (x.CompareTo(y) > 0)
            { return -1; }
            else { return 0; }
        }
    }
}
