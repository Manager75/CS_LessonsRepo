using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex216
{
    class Program
    {
        static void Main(string[] args)
        {

            A objA = new A(1, 2, 3, 4, 5, 6);

            B objB = new B(1, 2, 3, 4, 5, 6);

            objA.Reset();
            
            while (objA.MoveNext())
            {
                Console.WriteLine(objA.Current());
            }

            objA.Reset();
            while (objA.MoveNext())
            {
                Console.WriteLine(objA.Current());

            }

            Console.WriteLine();


            objB.Reset();

            while (objB.MoveNext())
            {
                Console.WriteLine(objB.Current);
            }
        }
    }
}
