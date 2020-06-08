﻿using System.Drawing;

namespace Game_PanarinAlexander
{
	class Bullet : BaseObject
	{
		public Bullet(Point pos, Point dir, Size size) : base(pos, dir, size) {}

        public override void Draw()
        {
            Game.Buffer.Graphics.DrawRectangle(Pens.OrangeRed, Pos.X, Pos.Y, Size.Width, Size.Height);
        }
        public override void Update()
        {
            Pos.X = Pos.X + Dir.X;
            if (Pos.X < 0)
                Pos.X = Game.Width - Size.Width;
            if (Pos.X > Game.Width)
                Pos.X = 0 + Size.Width;
        }
    }
}
