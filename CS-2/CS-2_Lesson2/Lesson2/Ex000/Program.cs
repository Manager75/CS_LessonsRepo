using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex000
{
    class A 
    {
        public int MyPropertyA { get; set; }
        //public static implicit operator B(A d)=> new B() { MyPropertyB =  d.MyPropertyA };
        public static explicit operator B(A d) => new B() { MyPropertyB = d.MyPropertyA };
    }

    class B
    {
        public int MyPropertyB { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {



            
            A a = new A();
            B b = new B();
            b = (B)a;
        }
    }
}
