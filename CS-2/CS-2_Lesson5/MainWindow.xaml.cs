using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace CS_2_Lesson5
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		ObservableCollection<Worker> items = new ObservableCollection<Worker>();
		ObservableCollection<Employees.Department> departments = new ObservableCollection<Employees.Department>();
		private static int Id = 0;
		Worker selectedWorker;

		public MainWindow()
		{
			InitializeComponent();

			//MainGrid.MouseUp += MainGrid_MouseUp;
			FillList();
		}

		//private void MainGrid_MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
		//{
		//	MessageBox.Show("Координаты " + e.GetPosition(this).ToString());
		//}

		private void FillList()
		{
			items.Add(new FullTimeWorker(Id = ++Id, "Ivanov", "Vasya", new DateTime(1975, 01, 15), 3000));
			items.Add(new FullTimeWorker(Id = ++Id, "Petrov", "Petya", new DateTime(1985, 06, 27), 6000));
			items.Add(new FullTimeWorker(Id = ++Id, "Sydorov", "Kolya", new DateTime(1968, 03, 03), 8000));
			lbEmployee.ItemsSource = items;

			departments.Add(Employees.Department.None);
			departments.Add(Employees.Department.Администрация);
			departments.Add(Employees.Department.Бухгалтерия);
			departments.Add(Employees.Department.ИТ_Отдел);
			departments.Add(Employees.Department.СнабжениеСклад);
			lbDepartment.ItemsSource = departments;
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			items.Add(new PartTimeWorker(Id = ++Id, "Krukov", "Sergey", new DateTime(1993, 11, 12), 7000));
		}

		private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			ComboBox comboBox = (ComboBox)sender;
			selectedWorker = (Worker)comboBox.SelectedItem;

			if (selectedWorker is Worker)
			{
				tbPosition.Text = $"{selectedWorker.GetType().Name}";
				tbDescribe.Text = $"Id: {selectedWorker.Id}. Возраст: {selectedWorker.Age}.\nЗаработная плата: {selectedWorker.Salary}.\n" +
					$"Часовая ставка: {selectedWorker.OneHourSalary:F2}.\nСреднемесячный заработок: {selectedWorker.AvgMonthSalary}.";
			}
		}

		private void lbDepartment_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (selectedWorker != null)
			{
				
			}
		}
	}
}
