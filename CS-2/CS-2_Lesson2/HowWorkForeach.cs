using System;
using System.Collections;

namespace CS_2_Lesson2
{
	// Пример необходимости реализации интерфейсов IEnumerable и IEnumerator
	// Здесь показано, как научить foreach работать с вашими данными
	// Для циклического обращения к элементам коллекции зачастую проще (да и лучше) организовать 
	// цикл foreach, чем пользоваться непосредственно методами интерфейса IEnumerator
	// Если требуется создать класс, содержащий объекты, перечисляемые в цикле foreach, то 
	// в этом классе следует реализовать интерфейсы IEnumerator и IEnumerable
	// Чтобы обратиться к объекту определяемого пользователем класса в цикле foreach, 
	// необходимо реализовать интерфейсы IEnumerator и IEnumerable в их обобщенной или 
	// необобщенной форме.

	class MyClass : IEnumerable, IEnumerator
	{
		// Наш пользовательский тип данных
		private readonly int[] _a;

		public MyClass(int n)
		{
			_a = new int[n];
			// Заполняем его произвольными данными
			for (var i = 0; i < n; i++) _a[i] = i;
		}
		// Первоначально индекс указывает на -1, так как к переходу к следующему мы увеличим его на 1
		private int _i = -1;
		// Реализуем интерфейс IEnumerable
		// Этот интерфейс должен только вернуть объект типа IEnumerator, который будет заниматься перечислением элементов
		//----------------------------------------------
		//public IEnumerator GetEnumerator()
		//{
		//	return this;
		//}
		//----------------------------------------------
		// Теперь реализуем интерфейс IEnumerator
		//-------------------------------------
		public bool MoveNext()
		{
			if (_i == _a.Length - 1)
			{
				Reset();
				return false;
			}
			_i++;
			return true;
		}
		public void Reset()
		{
			_i = -1;
		}
		public object Current => _a[_i];
		//----------------------------------------------
		// Или реализуем интерфейс IEnumerable с помощью yield
		public IEnumerator GetEnumerator()
		{
			for (int i = 0; i < _a.Length; i++)
				yield return _a[i]; // означает возврат каждого значения цикла по одному из очереди пока цикл не закончится.
		}
	}

	//class Program
	//{
	//	static void Main(string[] args)
	//	{
	//		MyClass my = new MyClass(5);
	//		foreach (var m in my)
	//			Console.Write("{0,4}", m); // 4-е знака для каждой переменой m

	//		Console.ReadKey();
	//	}
	//}
}
