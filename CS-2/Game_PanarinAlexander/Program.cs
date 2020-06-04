using System;
using System.Windows.Forms;

namespace Game_PanarinAlexander
{
	class Program
	{
		static void Main(string[] args)
		{
			Form form = new Form(); // создаю новое окно
			form.Width = 800;
			form.Height = 600;
			Game.Init(form); // иницилизирую Буффер в котором строится графика и связываю его с окном
			form.Show();
			Game.Draw();
			Application.Run(form);
		}
	}
}
