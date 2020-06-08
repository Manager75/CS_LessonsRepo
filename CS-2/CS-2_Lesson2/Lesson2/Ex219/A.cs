using Ex215;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex219
{
    interface I1
    {
        void M();
    }

    interface I2
    {
        void M();
    }


    class B:I1
    {
        public void M() { Console.WriteLine("B.M()"); }
    }

    class A : I1, I2
    {
        public void M() { Console.WriteLine("A.M()"); }

        void I1.M() { Console.WriteLine("I1.M()"); }

        void I2.M() { Console.WriteLine("I2.M()"); }
    }
}
