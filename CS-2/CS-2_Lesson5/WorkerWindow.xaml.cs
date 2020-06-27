using System.Data;
using System.Windows;

namespace CS_2_Lesson5
{
	/// <summary>
	/// Interaction logic for WorkerWindow.xaml
	/// </summary>
	public partial class WorkerWindow : Window
	{
		public DataRow resultRow { get; set; }
		public WorkerWindow(DataRow dataRow)
		{
			InitializeComponent();
			resultRow = dataRow;
		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			surNametextBox.Text = resultRow["SurName"].ToString();
			firstNametextBox.Text = resultRow["FirstName"].ToString();
			birthdaytextBox.Text = resultRow["Birthday"].ToString();
			departmentIdtextBox.Text = resultRow["DepartmentId"].ToString();
			salarytextBox.Text = resultRow["Salary"].ToString();
		}

		private void saveButton_Click(object sender, RoutedEventArgs e)
		{
			resultRow["SurName"] = surNametextBox.Text;
			resultRow["FirstName"] = firstNametextBox.Text;
			resultRow["Birthday"] = birthdaytextBox.Text;
			resultRow["DepartmentId"] = departmentIdtextBox.Text;
			resultRow["Salary"] = salarytextBox.Text;
			this.DialogResult = true;
		}

		private void cancelButton_Click(object sender, RoutedEventArgs e)
		{
			DialogResult = false;
		}
	}
}
