using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Ex210
{
    class Program
    {
        static void Main(string[] args)
        {
            
            List<HeroBase> bases = new List<HeroBase>();

            bases.Add(new HeroIntelligence());

            Console.WriteLine(bases[0].GetType());

           

            //HeroBase hero = new HeroBase();


            // StreamReader
            // StringWriter
            // MemoryStream



            //Stream stream = new Stream();




        }
    }
}
