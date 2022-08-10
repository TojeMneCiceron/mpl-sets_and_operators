using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace syap1
{
    class MultiSet: Set
    {
        int[] set;
        public MultiSet(int n)
        {
            set = new int[n + 1];
            for (int i = 0; i < set.Length; i++)
                set[i] = 0;
            max = n + 1;
        }
        public override void Insert(int elem)
        {
            if (elem > max)
                throw new SetExceptionOutOfRange();
            set[elem]++;
        }
        public override void Delete(int elem)
        {
            if (elem > max)
                throw new SetExceptionOutOfRange();
            if (set[elem] > 0)
                set[elem]--;
            else
                throw new SetExceptionDelete();
        }
        public override bool Found(int elem)
        {
            return !(elem > max) && set[elem] > 0;
        }
    }
}
