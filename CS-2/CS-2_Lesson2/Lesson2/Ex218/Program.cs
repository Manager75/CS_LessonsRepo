using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex218
{
    class Program
    {
        const string s = "qwerty";
        static string s1 = "asdfg";
        public readonly string s2;

        public Program()
        {
            s2 = "zxcvb";
        }



        public void A()
        {
            Console.WriteLine(s);
        }

         

        public void A1()
        {
            Console.WriteLine(Program.s1);
        }

        public void A2()
        {
            Console.WriteLine(s2);
        }
        static void Main(string[] args)
        {
            Console.WriteLine(s);
            Console.WriteLine(Program.s1);
            new Program().A2();
        }
    }
}
