using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace CS_2_Lesson5
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            // Создаем первое окно
            MainWindow wnd = new MainWindow();
            // Определяем необходимые свойства окна
            wnd.Title = MainWindow.FindResource("strHelloWPF").ToString();

            //if (e.Args.Length == 1)
            //    MessageBox.Show("Параметр: \n\n" + e.Args[0]);

            // Отображаем окно
            wnd.Show();
        }
    }
}
