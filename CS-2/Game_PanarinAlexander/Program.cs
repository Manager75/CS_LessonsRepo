using System;
using System.Windows.Forms;

namespace Game_PanarinAlexander
{
	class Program
	{
		static void Main(string[] args)
		{
			// создаю новое окно
			Form form = new Form
			{
				Width = Screen.PrimaryScreen.Bounds.Width,
				Height = Screen.PrimaryScreen.Bounds.Height
			};
			form.Width = 800;
			form.Height = 600;
			Game.Init(form); // иницилизирую Буффер в котором строится графика и связываю его с окном
			form.Show();
			Game.Draw();
			Application.Run(form);
		}
	}
}
