using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections.Generic;

namespace Ex219
{
    

    class Program
    {
        static void Main(string[] args)
        {
            A a = new A();
            a.M();
            ((I1)a).M();
            ((I2)a).M();


            List<I1> i1s = new List<I1>()
            {
                new B(),
                new A(),
            };

            foreach (var e in i1s)
            {
                e.M();
            }


        }
    }
}
