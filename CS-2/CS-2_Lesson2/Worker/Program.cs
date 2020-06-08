using System;
using System.Collections.Generic;

namespace Worker
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
                int variant = r.Next(0, 2);
                if (variant == 0)
                    workers.Add(new FullTimeWorker($"Имя_{i}", r.Next(20, 40), r.Next(5000, 8000)));
                else workers.Add(new PartTimeWorker($"Имя_{i}", r.Next(20, 40), r.Next(5000, 8000)));
            }

            Console.WriteLine("Список сотрудников до сортировки:");
            foreach (var e in workers) { Console.WriteLine(e); }
            Console.WriteLine("-------------------------------");

            Console.WriteLine("Список сотрудников после сортировки:");
            workers.Sort();
            foreach (var e in workers) { Console.WriteLine(e); }

            Console.ReadLine();

        }
    }
}
