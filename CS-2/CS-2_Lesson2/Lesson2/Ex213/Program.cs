using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Ex213
{
     
    class Program
    {
        static void Main(string[] args)
        {
            //IComparable

            Random r = new Random();

            List<Worker> workers = new List<Worker>();

            for (int i = 0; i < 5; i++)
            {
                workers.Add(new Worker($"Имя_{i}", r.Next(20, 40), r.Next(5000, 8000)));
            }

            foreach (var e in workers) { Console.WriteLine(e); }

            Console.WriteLine();
            Console.ReadLine();

            workers.Sort();


            foreach (var e in workers) { Console.WriteLine(e); }

            #region Ex0


            ////Console.ReadLine();

            ////workers.Sort();

            ////Console.WriteLine();

            ////foreach (var e in workers) { Console.WriteLine(e); }
            ////System.IO.File.WriteAllText("data.json", JsonConvert.SerializeObject(workers));
            //List<Worker> list = JsonConvert.DeserializeObject<List<Worker>>(System.IO.File.ReadAllText("data.json"));

            #endregion
        }

       
    }

}