using System;
using System.Windows.Forms;
using System.Drawing;

namespace Game_PanarinAlexander
{
    /*Чтобы убрать мерцание в игре, будем выводить графику в промежуточный буфер.
     * Когда графический кадр сформирован, выводим его на экран методом Render.
     * Для получения графического буфера используется класс BufferedGraphicsManager
     * и его свойство Current. Для связи буфера и графики применяем метод Allocate.
    */
    static class Game
    {
        static Timer _timer = new Timer() /*{ Interval = 100 }*/;
        public static Random random = new Random();

        static BufferedGraphicsContext _context;
        public static BufferedGraphics Buffer;
        public static BaseObject[,] _objs; // массив объектов - звездного поля
        public static Bullet _bullet;
        public static Asteroid[] _asteroids;
        private static Ship _ship = new Ship(new Point(10, 400), new Point(5, 5), new Size(10, 10)); // корабль
        private static FirstAidKit _firstAidKit; // аптечка

        // Свойства
        // Ширина и высота игрового поля
        public static int Width { get; set; }
        public static int Height { get; set; }
        static Game() { }

        public static void Init(Form form)
        {
            // Графическое устройство для вывода графики            
            Graphics g;
            // Предоставляет доступ к главному буферу графического контекста для текущего приложения
            _context = BufferedGraphicsManager.Current;
            g = form.CreateGraphics();
            // Создаем объект (поверхность рисования) и связываем его с формой
            // Запоминаем размеры формы
            Width = form.ClientSize.Width;
            Height = form.ClientSize.Height;

            if (Width <= 0 || Width > 1000)
                throw new ArgumentOutOfRangeException("Width", Width, "Неправильная ширина.");
            if (Height <= 0 || Height > 1000)
                throw new ArgumentOutOfRangeException("Height", Height, "Неправильная высота.");

            // Связываем буфер в памяти с графическим объектом, чтобы рисовать в буфере
            Buffer = _context.Allocate(g, new Rectangle(0, 0, Width, Height));

            Load(); // создание объектов на звездном поле

            _timer.Start();
            _timer.Tick += Timer_Tick; // Событие Timer Tick - происходит, когда указанный интервал таймера истек и таймер включен.

            form.KeyDown += Form_KeyDown; // Событие - происходит, когда будет нажата клавиша.
            
            Ship.MessageDie += Finish;
			Ship.MessageFirstAidKit += Help; // вызываю помощь в случае повреждения корабля.
			BaseObject.EventPost += Log.LogConsole; // журнал событий в консоле.
            BaseObject.EventPost += Log.LogFile; // журнал событий в файл.
            BaseObject.EventPost += Log.LogStreamWrite; // журнал событий в поток.
        }

		private static void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
            Update();
        }
        private static void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey) _bullet = new Bullet(new Point(_ship.Rect.X + 10, _ship.Rect.Y + 4), new Point(10, 0), new Size(4, 1));
            if (e.KeyCode == Keys.Up) _ship.Up();
            if (e.KeyCode == Keys.Down) _ship.Down();
        }
        private static void Help()
        {
            if (_firstAidKit == null)
				_firstAidKit = new FirstAidKit(new Point(random.Next(Width), random.Next(Height)), new Point(random.Next(1,10), random.Next(1,10)), new Size(10, 10));
        }

        /// <summary>
        /// Создаются объекты, которые будут на звездном поле
        /// </summary>
        public static void Load()
        {
            int countObjs_1 = 3;
            int countObjs_2 = 10;
            int size;
            _objs = new BaseObject[countObjs_1, countObjs_2];
            _asteroids = new Asteroid[3];

            for (int count = 0; count < countObjs_1; count++)
            {
                for (int i = 0; i < countObjs_2; i++)
                {
                    if (count == 0)
                    {
                        size = random.Next(10, 50);
                        _objs[count, i] = new StarGold(new Point(100, i * 20), new Point(15 - random.Next(i), 15 - random.Next(i)), new Size(size, size));
                    }
                    else if (count == 1)
                    {
                        _objs[count, i] = new Star(new Point(300, random.Next(Height)), new Point(-i, 0), new Size(5, 5));
                    }
                    else if (count == 2)
                    {
                        size = random.Next(1, 20);
                        _objs[count, i] = new StarBlue(new Point(300, random.Next(Height)), new Point(i, 0), new Size(size, size));
                    }
                }
            }

            for (var i = 0; i < _asteroids.Length; i++)
            {
                int r = random.Next(10, 30);
                //_asteroids[i] = new Asteroid(new Point(Width, 200), new Point(-r/3, r), new Size(250, r)); // Проверка разлета в разные стороны при столкновении
                _asteroids[i] = new Asteroid(new Point(1000, random.Next(0, Game.Height)), new Point(r / 5, r), new Size(r, r));
            }
        }

        /// <summary>
        /// Отрисовываются все объекты на звездном поле
        /// </summary>
        public static void Draw()
        {
            Buffer.Graphics.Clear(Color.Black);

            foreach (BaseObject obj in _objs) // Объекты - звезды
                obj.Draw();

            foreach (Asteroid a in _asteroids) // Объекты - астероиды 
                a?.Draw();

            _bullet?.Draw(); // Пуля

            _ship?.Draw();
            if (_ship != null)
			{
                Buffer.Graphics.DrawString("Energy:" + _ship.Energy, SystemFonts.DefaultFont, Brushes.White, 0, 0);
                Buffer.Graphics.DrawString("GamePoints:" + _ship.GamePoints, SystemFonts.DefaultFont, Brushes.White, 0, 15);
            }

            _firstAidKit?.Draw();

            Buffer.Render(); // Когда графический кадр сформирован, выводим его на экран методом Render.
        }

        /// <summary>
        /// Меняются координаты всех объектов в зависимости от встречи с препятствием (стены)
        /// </summary>
        public static void Update()
        {
            foreach (BaseObject obj in _objs)
                obj.Update();

            _bullet?.Update();
            _firstAidKit?.Update();

            for (var i = 0; i < _asteroids.Length; i++)
            {
                int r = random.Next(1, 10);

                if (_asteroids[i] == null)
                    continue;

                _asteroids[i].Update();

                if (_bullet != null && _bullet.Collision(_asteroids[i]))
                {
                    System.Media.SystemSounds.Hand.Play();
                    _ship.GamePoints++;
                    _asteroids[i] = null;
                    _bullet = null;
                    continue;
                }

                // вызов аптечки происходит после повреждения корабля
                if (_firstAidKit != null)
				{
                    if (_firstAidKit.Collision(_asteroids[i]))
                        Help();
                    if (_firstAidKit.Collision(_ship))
					{
                        _ship?.EnergyHigh(r);
                        _firstAidKit = null;
                    }
                } 

                if (!_ship.Collision(_asteroids[i]))
                    continue;

                _ship?.EnergyLow(r);
                System.Media.SystemSounds.Asterisk.Play();
                if (_ship.Energy <= 0)
                    _ship?.Die();
            }

            // Пример когда пуля сталкивается с астероидом и они оба меняют направление движения.
            //foreach (Asteroid a in _asteroids)
            //{
            //    a.Update();
            //    // BaseObject, как предок через наследование, передает Collision
            //    if (a.Collision(_bullet)) 
            //    { 
            //        System.Media.SystemSounds.Hand.Play();
            //        a.FlyAway(_bullet); // при столкновении объекты разлетаются в разные стороны
            //    }
            //}
        }

        public static void Finish()
        {
            _timer.Stop();
            Buffer.Graphics.DrawString("The End", new Font(FontFamily.GenericSansSerif, 60, FontStyle.Underline), Brushes.White, 200, 100);
            Buffer.Render();
        }
    }
}
