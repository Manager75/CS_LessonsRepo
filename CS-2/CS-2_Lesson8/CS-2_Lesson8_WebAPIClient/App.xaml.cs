using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace CS_2_Lesson8_WebAPIClient
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
            wnd.Title = MainWindow.FindResource("Company").ToString();

            // Отображаем окно
            wnd.Show();
        }
    }
}
