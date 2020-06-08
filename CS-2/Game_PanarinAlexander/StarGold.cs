using System.Drawing;

namespace Game_PanarinAlexander
{
	class StarGold : BaseObject
	{
		private readonly Image newImage = Image.FromFile(@"..\icons\GoldStar.png"); // нужна загрузка картинки один раз, чтобы экономно использовать память.

		public StarGold(Point pos, Point dir, Size size) : base(pos, dir, size) { }
		public override void Draw()
		{
			Game.Buffer.Graphics.DrawImage(newImage, Pos.X, Pos.Y, Size.Width, Size.Height);
		}

		public override void Update()
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
