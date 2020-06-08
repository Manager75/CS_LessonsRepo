using System.Drawing;

namespace Game_PanarinAlexander
{
	class StarBlue : BaseObject
	{
		private readonly Image newImage = Image.FromFile(@"..\icons\BlueStar.jpg"); // нужна загрузка картинки один раз, чтобы экономно использовать память.

		public StarBlue(Point pos, Point dir, Size size) : base(pos, dir, size){}
		public override void Draw()
		{
			Game.Buffer.Graphics.DrawImage(newImage, Pos.X, Pos.Y, Size.Width, Size.Height);
		}

		public override void Update()
		{
			Pos.X -= Dir.X;
			if (Pos.X < 0)
				Pos.X = Game.Width - Size.Width;
			if (Pos.X > Game.Width)
				Pos.X = 0 + Size.Width;
		}
	}
}
