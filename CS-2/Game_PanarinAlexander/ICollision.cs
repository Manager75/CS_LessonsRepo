using System.Drawing;

namespace Game_PanarinAlexander
{
	/// <summary>
	/// Для определения столкновений опишем интерфейс ICollision. 
	/// Он закладывает поведение, по которому два объекта, поддерживающие его, могут определить, столкнулись ли они. 
	/// Для определения столкновения используем метод IntersectsWith структуры Rect:
	/// </summary>
	interface ICollision
	{
		bool Collision(ICollision obj);
		Rectangle Rect { get; }
	}
}
