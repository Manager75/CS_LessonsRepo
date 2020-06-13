using System;
using System.Collections.Generic;
using System.Linq;

namespace CS_2_Lesson4
{
	class Program
	{
        static void Main(string[] args)
		{
            // Задание 2. из Методички к Уроку №4.

            // 1. Дана коллекция List<T>. Требуется подсчитать, сколько раз каждый элемент встречается в данной коллекции:
            // a) для целых, с плавающей точкой чисел, для строк;
            //List<int> listInt = new List<int>();
            //List<double> listInt = new List<double>();
            List<string> listInt = new List<string>();

            // заполняю коллекцию случайными числами, чтобы подсчитать повторяющиеся числа в коллекции
            Random random = new Random();
			for (int i = 0; i < 10; i++)
                listInt.Add(random.Next(10).ToString());
            foreach (var item in listInt)
                Console.Write($"{item}\t");

            Console.WriteLine("----------------------------------------");

            //1-й вариант решения. Linq - группировка повторяющихся элементов внутри списка
            var listCountRepeat1 = from c in listInt
                                   group c by c;
			Console.WriteLine($"Group By: Всего найдено {listCountRepeat1.Count(x => x.Count() > 1)} совпадений одинаковых чисел в списке.");
            foreach (var item in listCountRepeat1)
                Console.WriteLine($"{item.Key}"); //ToDo не понимаю как убрать пустые элементы?

            Console.WriteLine("----------------------------------------");

            //2-й вариант решения. Linq - группировка повторяющихся элементов внутри списка
            var listCountRepeat2 = listInt.Where(x => listInt.Count(y => x == y) > 1).Distinct();
            Console.WriteLine($"Where: Всего найдено {listCountRepeat2.Count()} совпадений одинаковых чисел в списке.");

			foreach (var item in listCountRepeat2)
			{
                int count = 0;
				foreach (var i in listInt)
                    if (item == i) count++;
                Console.WriteLine($"Число {item} повторяется - {count} раз.");
            }

            Console.WriteLine("----------------------------------------");

            // Задание 3. из Методички к уроку №4.
            Dictionary<string, int> dict = new Dictionary<string, int>()
            {
                ["four"] = 4,
                ["two"] = 2,
                ["one"] = 1,
                ["three"] = 3,
            };
            //1. Начальные данные:
            //var d = dict.OrderBy(delegate(KeyValuePair<string, int> pair) { return pair.Value; });
            
            //2. Свернуть обращение к OrderBy с использованием лямбда-выражения.
            //var d = dict.OrderBy(pair => pair.Value);
            
            //3. Развернуть обращение к OrderBy с использованием делегата.
            var d = dict.OrderBy(SortByValue);

            Console.WriteLine("OrderBy разные варианты решения задачи:");
            foreach (var pair in d)
                Console.WriteLine("{0} - {1}", pair.Key, pair.Value);

            Console.ReadKey();
        }
        static int SortByValue(KeyValuePair<string, int> pair)
		{
            return pair.Value;
		}
    }
}
