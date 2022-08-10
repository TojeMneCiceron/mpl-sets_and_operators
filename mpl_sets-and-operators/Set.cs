using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace syap1
{
    abstract class Set
    {
        protected int max;
        abstract public void Insert(int elem);
        abstract public void Delete(int elem);
        abstract public bool Found(int elem);
        public virtual void FillSet(string str)
        {
            string[] a = str.Split(' ');
            for (int i = 0; i < a.Length; i++)
                Insert(int.Parse(a[i]));
        }
        public virtual void FillSet(int[] a)
        {
            for (int i = 0; i < a.Length; i++)
                Insert(a[i]);
        }
        public virtual void Show()
        {
            string str = "";
            for (int i = 0; i < max; i++)
                if (Found(i))
                    str += i + " ";
            Console.WriteLine("\n" + str + "\n");
        }
    }
}
