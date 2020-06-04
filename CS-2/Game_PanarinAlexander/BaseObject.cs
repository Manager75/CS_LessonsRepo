using System.Drawing;

namespace Game_PanarinAlexander
{
    /// <summary>
    /// Базовый класс для появления объектов на звездном поле
    /// </summary>
	class BaseObject
	{
        protected Point Pos; // координаты
        protected Point Dir; // направление
        protected Size Size; // размер
        private readonly Image newImage = Image.FromFile(@"..\icons\OrangeStar.jpg"); // нужна загрузка картинки один раз, чтобы экономно использовать память.

        public BaseObject(Point pos, Point dir, Size size)
        {
            Pos = pos;
            Dir = dir;
            Size = size;
        }
        public virtual void Draw()
        {
            //Game.Buffer.Graphics.DrawEllipse(Pens.White, Pos.X, Pos.Y, Size.Width, Size.Height);
            Game.Buffer.Graphics.DrawImage(newImage, Pos.X, Pos.Y, Size.Width, Size.Height);
        }
        /// <summary>
        /// Передвижение объекта пока он не встретится со стеной в игре, тогда объект меняет направление
        /// </summary>
        public virtual void Update()
        {
            Pos.X += Dir.X;
            Pos.Y += Dir.Y;
            if (Pos.X < 0) Dir.X = -Dir.X;
            if (Pos.X > Game.Width) Dir.X = -Dir.X;
            if (Pos.Y < 0) Dir.Y = -Dir.Y;
            if (Pos.Y > Game.Height) Dir.Y = -Dir.Y;
        }
    }
}
