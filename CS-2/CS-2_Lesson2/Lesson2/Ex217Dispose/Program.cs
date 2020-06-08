using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Threading;

namespace Ex217Dispose
{

    class A : IDisposable
    {
        public Image Img { get; set; }
        public A()
        {
            Img = new Bitmap(10, 10);
        }

        ~A()
        {
            Console.Beep(1000, 1000);
            
        }

        public void Dispose()
        {
            //Img.Save();
            Img.Dispose();

            GC.SuppressFinalize(this);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            
            Console.ReadLine();

            using (A a = new A())
            {

            }

           

            GC.Collect();

            Console.ReadLine();


        }
    }
}
