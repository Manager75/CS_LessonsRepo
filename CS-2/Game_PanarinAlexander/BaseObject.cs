using System;
using System.Drawing;

namespace Game_PanarinAlexander
{
    /// <summary>
    /// Базовый класс для появления объектов на звездном поле
    /// </summary>
	abstract class BaseObject : ICollision
	{
        protected Point Pos; // координаты
        protected Point Dir; // направление
        protected Size Size; // размер
        
        protected BaseObject(Point pos, Point dir, Size size)
        {
            try
			{
                Pos = pos;
                Dir = dir;
                Size = size;

                GameObjectException innerException = new GameObjectException();
                if (pos.X < 0 || pos.X > Game.Width)
                    throw new ArgumentOutOfRangeException($"Неправильная высота - pos.Y: {pos.Y}.");
                if (pos.Y < 0 || pos.Y > Game.Height)
                    throw new ArgumentOutOfRangeException($"Неправильная высота - pos.Y: {pos.Y}.");
                if (Size.Width < 0 || Size.Width > 200)
                    throw new GameObjectException($"Ошибка создания объекта.", innerException);
                if (Size.Height < 0 || Size.Height > 200)
                    throw new GameObjectException($"Ошибка создания объекта.", innerException);
            }
            catch (ArgumentOutOfRangeException e)
			{
                Console.WriteLine(e.Message);
                if (Pos.X < 0) Dir.X = -Dir.X;
                if (Pos.X > Game.Width) Dir.X = -Dir.X;
                if (Pos.Y < 0) Dir.Y = -Dir.Y;
                if (Pos.Y > Game.Height) Dir.Y = -Dir.Y;
            }
            catch (GameObjectException)
			{
                Random random = new Random();
                int r = random.Next(10, 30);

                if (Size.Width < 0 || Size.Width > 200)
                    Size.Width = r;
                if (Size.Height < 0 || Size.Height > 200)
                    Size.Height = r;
            }
        }

        public abstract void Draw();

        /// <summary>
        /// Передвижение объекта пока он не встретится со стеной в игре, тогда объект меняет направление
        /// </summary>
        public abstract void Update();
        
	    // Так как переданный объект тоже должен будет реализовывать интерфейс ICollision, мы 
	    // можем использовать его свойство Rect и метод IntersectsWith для обнаружения пересечения с
	    // нашим объектом (а можно наоборот)
	    public bool Collision(ICollision o) => o.Rect.IntersectsWith(this.Rect);
        public Rectangle Rect => new Rectangle(Pos, Size);

        public virtual void FlyAway(BaseObject _obj)
        {
            // ToDo доделать варианты правильного разлета Пули и Астероида
            if (Dir.X > 0 && _obj.Dir.X > 0 || Dir.X < 0 && _obj.Dir.X < 0)
			{
                if (Dir.X > _obj.Dir.X)
                {
                    _obj.Dir.X = Dir.X;
                }
                else
                {
                    Dir.X = _obj.Dir.X;
                }
            }

            if (Dir.X >= 0)
            {
                Pos.X = Rect.Left;
                Dir.X = -Dir.X;
            }
            else 
            {
                Pos.X = Rect.Right;
                Dir.X = Math.Abs(Dir.X);
            }

            if (_obj.Dir.X >= 0)
            {
                _obj.Pos.X = _obj.Rect.Left;
                _obj.Dir.X = -_obj.Dir.X;
            }
            else
            {
                _obj.Pos.X = _obj.Rect.Right;
                _obj.Dir.X = Math.Abs(_obj.Dir.X);
            }
        }
    }
}
