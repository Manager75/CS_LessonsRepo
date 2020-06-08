using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections.Generic;
using System.Collections;
using Ex214;

namespace Ex213
{
    class Program
    {
        static void Main(string[] args)
        {
            #region IEnumerable 

            Storage it = new Storage();

            //foreach (var item in it)
            //{
            //    Console.WriteLine(item);
            //}

            StorageNew it2 = new StorageNew();

            foreach (var item in it2)
            {
                Console.WriteLine(item);
            }

            #endregion

        }
    }
}
