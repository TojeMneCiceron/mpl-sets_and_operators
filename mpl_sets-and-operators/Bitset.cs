using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace syap1
{
    class BitSet: Set
    {
        int[] set;
        public BitSet(int n)
        {
            set = new int[n / 32 + 1];
            for (int i = 0; i < set.Length; i++)
                set[i] = 0;
            max = n + 1;
        }
        public override void Insert(int elem)
        {
            if (elem > max)
                throw new SetExceptionOutOfRange();
            set[elem / 32] |= 1 << (elem % 32);
        }
        public override void Delete(int elem)
        {
            if (elem > max)
                throw new SetExceptionOutOfRange();
            set[elem / 32] &= ~(1 << (elem % 32));
        }
        public override bool Found(int elem)
        {
            return !(elem > max) && ((set[elem / 32] & (1 << (elem % 32))) == (1 << (elem % 32)));
        }
        public static BitSet operator +(BitSet A, BitSet B)
        {
            int uMax;
            if (A.max > B.max)
                uMax = A.max;
            else
                uMax = B.max;
            BitSet union = new BitSet(uMax);
            for (int i = 0; i < A.set.Length; i++)
                union.set[i] = A.set[i];
            for (int i = 0; i < B.set.Length; i++)
                union.set[i] = union.set[i] | B.set[i];
            return union;
        }
        public static BitSet operator *(BitSet A, BitSet B)
        {
            int iMax;
            if (A.max > B.max)
                iMax = A.max;
            else
                iMax = B.max;
            BitSet intersection = new BitSet(iMax);
            for (int i = 0; i < A.set.Length; i++)
                intersection.set[i] = A.set[i];
            for (int i = 0; i < B.set.Length; i++)
                intersection.set[i] = intersection.set[i] & B.set[i];
            return intersection;
        }
    }
}
