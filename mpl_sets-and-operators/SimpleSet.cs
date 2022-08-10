using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace syap1
{
    class SimpleSet: Set
    {
        bool[] set;
        public SimpleSet(int n)
        {
            set = new bool[n + 1];
            max = n + 1;
        }
        public override void Insert(int elem)
        {
            if (elem > max)
                throw new SetExceptionOutOfRange();
            set[elem] = true;
        }
        public override void Delete(int elem)
        {
            if (elem > max)
                throw new SetExceptionOutOfRange();
            if (set[elem])
                set[elem] = false;
            else
                throw new SetExceptionDelete();
        }
        public override bool Found(int elem)
        {
            return !(elem > max) && set[elem];
        }
        public static SimpleSet operator +(SimpleSet A, SimpleSet B)
        {
            int uMax;
            if (A.max > B.max)
                uMax = A.max;
            else
                uMax = B.max;
            SimpleSet union = new SimpleSet(uMax);
            for (int i = 0; i < A.set.Length; i++)
                union.set[i] = A.set[i];
            for (int i = 0; i < B.set.Length; i++)
                union.set[i] = union.set[i] || B.set[i];
            return union;
        }
        public static SimpleSet operator *(SimpleSet A, SimpleSet B)
        {
            int iMax;
            if (A.max > B.max)
                iMax = A.max;
            else
                iMax = B.max;
            SimpleSet intersection = new SimpleSet(iMax);
            for (int i = 0; i < A.set.Length; i++)
                intersection.set[i] = A.set[i];
            for (int i = 0; i < B.set.Length; i++)
                intersection.set[i] = intersection.set[i] && B.set[i];
            return intersection;
        }
    }
}
