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
        private static BufferedGraphicsContext _context;
        public static BufferedGraphics Buffer;
        public static BaseObject[,] _objs; // массив объектов - звездного поля

        // Свойства
        // Ширина и высота игрового поля
        public static int Width { get; set; }
        public static int Height { get; set; }
        static Game() {}
        
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
            // Связываем буфер в памяти с графическим объектом, чтобы рисовать в буфере
            Buffer = _context.Allocate(g, new Rectangle(0, 0, Width, Height));

            Load(); // создание объектов на звездном поле

            Timer timer = new Timer { Interval = 100 };
            timer.Start();
            timer.Tick += Timer_Tick; // Событие Timer Tick - происходит, когда указанный интервал таймера истек и таймер включен.
        }

        private static void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
            Update();
        }
        /// <summary>
        /// Отрисовываются все объекты на звездном поле
        /// </summary>
        public static void Draw()
        {
            Buffer.Graphics.Clear(Color.Black);
            foreach (BaseObject obj in _objs)
            {
                obj.Draw();
            }
            Buffer.Render(); // Когда графический кадр сформирован, выводим его на экран методом Render.
        }
        /// <summary>
        /// Создаются объекты, которые будут на звездном поле
        /// </summary>
        public static void Load()
        {
            int countObjs_1 = 4;
            int countObjs_2 = 10;
            _objs = new BaseObject[countObjs_1, countObjs_2];
            Random random = new Random();
            int size;

            for (int count = 0; count < countObjs_1; count++)
            {
                for (int i = 0; i < countObjs_2; i++)
                {
                    if (count == 0)
                    {
                        size = random.Next(5, 30);
                        _objs[count, i] = new BaseObject(new Point(100, i * 20), new Point(15 - random.Next(i), 15 - random.Next(i)), new Size(size, size));
                    }
                    else if (count == 1)
                    {
                        _objs[count, i] = new Star(new Point(300, random.Next(Height)), new Point(-i, 0), new Size(5, 5));
                    }
                    else if (count == 2)
                    {
                        size = random.Next(10, 50);
                        _objs[count, i] = new StarGold(new Point(500, i * 20), new Point(15 - random.Next(i), 15 - random.Next(i)), new Size(size, size));
                    }
                    else if (count == 3)
                    {
                        size = random.Next(1, 20);
                        _objs[count, i] = new StarBlue(new Point(300, random.Next(Height)), new Point(-i, 0), new Size(size, size));
                    }
                }
            }   
        }
        /// <summary>
        /// Меняются координаты всех объектов в зависимости от встречи с препятствием (стены)
        /// </summary>
        public static void Update()
        {
            foreach (BaseObject obj in _objs)
            {
                obj.Update();
            }
        }
    }
}
