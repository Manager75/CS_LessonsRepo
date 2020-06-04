using System.Drawing;

namespace Game_PanarinAlexander
{
	class StarGold : BaseObject
	{
		private readonly Image newImage = Image.FromFile(@"..\icons\GoldStar.png"); // нужна загрузка картинки один раз, чтобы экономно использовать память.

		public StarGold(Point pos, Point dir, Size size) : base(pos, dir, size){}
		public override void Draw()
		{
			Game.Buffer.Graphics.DrawImage(newImage, Pos.X, Pos.Y, Size.Width, Size.Height);
		}

		// метод Update в этом классе не переопределяется, чтобы продемонстрировать Наследование.
	}
}
