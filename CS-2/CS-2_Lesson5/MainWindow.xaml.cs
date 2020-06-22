using System.Windows;
using System.Windows.Controls;

namespace CS_2_Lesson5
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		Company company;
		Department selectedDepartment;
		Worker selectedWorker;

		public MainWindow()
		{
			InitializeComponent();

			company = new Company(10, 100);
			this.DataContext = company;
			AddWorker.Click += AddWorker_Click;

			//MainGrid.MouseUp += MainGrid_MouseUp;
		}

		//private void MainGrid_MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
		//{
		//	MessageBox.Show("Координаты " + e.GetPosition(this).ToString());
		//}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			//items.Add(new PartTimeWorker(Id = ++Id, "Krukov", "Sergey", new DateTime(1993, 11, 12), 7000));
		}

		private void cbEmployee_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			ComboBox comboBoxWorkers = (ComboBox)sender;
			selectedWorker = (Worker)comboBoxWorkers.SelectedItem;

			if (selectedWorker is Worker)
				listWorkers.ItemsSource = company.FindWorker(selectedWorker.Name);
		}

		/// <summary>
		/// Список Работников Департамента
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void cbDepartment_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			ComboBox listBoxDepartments = (ComboBox)sender;
			selectedDepartment = (Department)listBoxDepartments.SelectedItem;

			if (selectedDepartment is Department)
				listWorkers.ItemsSource = company.DepartmenWorkers(selectedDepartment.DepartmentId);
		}

		private void listWorkers_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			ListView listViewWorkers = (ListView)sender;
			selectedWorker = (Worker)listViewWorkers.SelectedItem;

			if (selectedWorker is Worker)
			{
				cbEmployee.SelectedItem = selectedWorker;
			}
		}
		private void AddWorker_Click(object sender, RoutedEventArgs e)
		{
			
		}
	}
}
