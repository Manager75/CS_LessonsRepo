using System;
using System.Drawing;

namespace Game_PanarinAlexander
{
	class Ship : BaseObject
	{
        public static event Message MessageDie; // событие о гибели корабля
        public static event Message MessageFirstAidKit; // событие о вызове помощи-лечение корабля

        private int _energy = 100;
        public int Energy => _energy;
        public int GamePoints { get; set; }

        public Ship(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }
        public override void Draw()
        {
            Game.Buffer.Graphics.FillEllipse(Brushes.Wheat, Pos.X, Pos.Y, Size.Width, Size.Height);
        }
        public override void Update()
        {
        }
        public void Up()
        { 
            if (Pos.Y > 0) Pos.Y = Pos.Y + Dir.Y;
            //else Pos.Y = 0 + Dir.Y; // Todo разобраться почему исчезает корабль?
        }
        public void Down()
        { 
            if (Pos.Y < Game.Height) Pos.Y = Pos.Y - Dir.Y;
            //else Pos.Y = Game.Height - Dir.Y;
        }
        public void Die()
        {
            MessageDie?.Invoke();
            PublicMessage($"Корабль погиб. Время гибели: {DateTime.Now}");
        }
        /// <summary>
        /// Уменьшение энергии корабля
        /// </summary>
        /// <param name="n"></param>
        public void EnergyLow(int n)
        {
            _energy -= n;
            MessageFirstAidKit?.Invoke();
            PublicMessage($"Корабль теряет энергию. Минус: {n} energy. {DateTime.Now.TimeOfDay}");
        }
        /// <summary>
        /// Увеличение энергии корабля
        /// </summary>
        /// <param name="n"></param>
        public void EnergyHigh(int n)
        {
            _energy += n;
            PublicMessage($"Корабль добавил энергии. Плюс: {n} energy. {DateTime.Now.TimeOfDay}");
        }
    }
}
