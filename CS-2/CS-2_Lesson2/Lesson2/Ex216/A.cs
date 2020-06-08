using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex216
{
    struct A
    {
        public int[] arr;
    
        public A(params int[] Col)
        {
            index = -1;

            arr = new int[Col.Length];

            for (int i = 0; i < Col.Length; i++)
            {
                arr[i] = Col[i];
            }
        }

        int index;

        //public int Current { get { return arr[index]; } }
        public int Current() { return arr[index]; }

        public void Reset() { index = -1; }

        public bool MoveNext()
        {
            index++;
            return index < arr.Length;
        }
    }
}
