using System;
using System.Collections.Generic;
using System.Drawing;

namespace Game_PanarinAlexander
{
	class Asteroid : BaseObject, ICloneable, IComparable<Asteroid>
	{
		/// <summary>
		/// Возникает в момент пересечения с чем-либо
		/// </summary>
		public static event Action<string, int> CollisionAsteroid;

		public int Power { get; set; }

		public Asteroid(Point pos, Point dir, Size size) : base(pos, dir, size)
		{
			Power = 1;
			PublicMessage($"{DateTime.Now}: Астероид создан\n");
		}

		public override void Draw()
		{
			Game.Buffer.Graphics.FillEllipse(Brushes.White, Pos.X, Pos.Y, Size.Width, Size.Height);
		}

		public override void Update()
		{
			Pos.X = Pos.X + Dir.X;
			if (Pos.X < 0)
				Pos.X = Game.Width - Size.Width;
			if (Pos.X > Game.Width)
				Pos.X = 0 + Size.Width;
		}

		public object Clone()
		{
			// Создаем копию нашего робота
			Asteroid asteroid = new Asteroid(
				new Point(Pos.X, Pos.Y),
				new Point(Dir.X, Dir.Y),
				new Size(Size.Width, Size.Height))
			{ Power = Power }; // Не забываем скопировать новому астероиду Power нашего астероида
			//asteroid.Power = Power;
			return asteroid;
		}

		// Реализация Интерфейса без обобщения:
		//int IComparable.CompareTo(object obj)
		//{
		//	if (obj is Asteroid temp)
		//	{
		//		if (Power > temp.Power)
		//			return 1;
		//		if (Power < temp.Power)
		//			return -1;
		//		else
		//			return 0;
		//	}
		//	throw new ArgumentException("Parameter is not а Asteroid!");
		//}

		int IComparable<Asteroid>.CompareTo(Asteroid obj)
		{
			if (Power > obj.Power)
				return 1;
			if (Power < obj.Power)
				return -1;
			return 0;
		}
	}
}
