using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace CS_2_Lesson5
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		//Company company;
		//Department selectedDepartment;
		//Worker selectedWorker;
		CS2Lesson7Entities dbCompany;

		SqlConnection connection;
		SqlDataAdapter adapter;
		DataTable dt;

		public MainWindow()
		{
			InitializeComponent();

			dbCompany = new CS2Lesson7Entities();
			
			//company = new Company(10, 100);
			//this.DataContext = company;

			//MainGrid.MouseUp += MainGrid_MouseUp;
		}

		//private void MainGrid_MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
		//{
		//	MessageBox.Show("Координаты " + e.GetPosition(this).ToString());
		//}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			// Строка подключения к MS SQL Server
			var connectionStringBuilder = new SqlConnectionStringBuilder
			{
				DataSource = @"(localdb)\MSSQLLocalDB",
				InitialCatalog = "CS2Lesson7"
			};

			connection = new SqlConnection(connectionStringBuilder.ConnectionString);
			adapter = new SqlDataAdapter();

			#region select

			SqlCommand command =
				new SqlCommand("SELECT Id, DepartmentId, SurName, FirstName, Birthday, Salary FROM dbWorkers",
				connection);
			adapter.SelectCommand = command;

			#endregion

			#region insert

			command = new SqlCommand(@"INSERT INTO dbWorkers (DepartmentId, SurName, FirstName, Birthday, Salary) 
                          VALUES (@DepartmentId, @SurName, @FirstName, @Birthday, @Salary); SET @Id = @@IDENTITY;",
						  connection);

			command.Parameters.Add("@DepartmentId", SqlDbType.Int, 3, "DepartmentId");
			command.Parameters.Add("@SurName", SqlDbType.NVarChar, -1, "SurName");
			command.Parameters.Add("@FirstName", SqlDbType.NVarChar, -1, "FirstName");
			command.Parameters.Add("@Birthday", SqlDbType.NVarChar, -1, "Birthday");
			command.Parameters.Add("@Salary", SqlDbType.Float, 10, "Salary");

			SqlParameter param = command.Parameters.Add("@Id", SqlDbType.Int, 0, "Id");

			param.Direction = ParameterDirection.Output;

			adapter.InsertCommand = command;

			#endregion

			#region update

			command = new SqlCommand(@"UPDATE dbWorkers 
									SET DepartmentId = @DepartmentId,
										SurName = @SurName,
										FirstName = @FirstName,
                                        Birthday = @Birthday, 
                                        Salary = @Salary 
									WHERE Id = @Id", connection);

			command.Parameters.Add("@DepartmentId", SqlDbType.Int, 3, "DepartmentId");
			command.Parameters.Add("@SurName", SqlDbType.NVarChar, -1, "SurName");
			command.Parameters.Add("@FirstName", SqlDbType.NVarChar, -1, "FirstName");
			command.Parameters.Add("@Birthday", SqlDbType.NVarChar, -1, "Birthday");
			command.Parameters.Add("@Salary", SqlDbType.Float, 10, "Salary");
			param = command.Parameters.Add("@Id", SqlDbType.Int, 0, "Id");
			param.SourceVersion = DataRowVersion.Original;

			adapter.UpdateCommand = command;

			#endregion

			#region delete

			command = new SqlCommand("DELETE FROM dbWorkers WHERE Id = @Id", connection);
			param = command.Parameters.Add("@Id", SqlDbType.Int, 0, "Id");
			param.SourceVersion = DataRowVersion.Original;
			adapter.DeleteCommand = command;

			#endregion

			dt = new DataTable();
			adapter.Fill(dt);
			
			this.DataContext = dt.DefaultView;
		}

		/// <summary>
		/// Список Работников Департамента
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void cbDepartment_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			//ComboBox listBoxDepartments = (ComboBox)sender;
			//selectedDepartment = (Department)listBoxDepartments.SelectedItem;

			//if (selectedDepartment is Department)
			//	listWorkers.ItemsSource = company.DepartmenWorkers(selectedDepartment.DepartmentId);
		}

		private void listWorkers_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			//ListView listViewWorkers = (ListView)sender;
			//selectedWorker = (Worker)listViewWorkers.SelectedItem;

			//if (selectedWorker is Worker)
			//{
			//	cbEmployee.SelectedItem = selectedWorker;
			//}
		}
		private void AddWorker_Click(object sender, RoutedEventArgs e)
		{
			// добавим новую строку в нашу базу данных
			DataRow newRow = dt.NewRow();
			WorkerWindow editWindow = new WorkerWindow(newRow);
			editWindow.ShowDialog(); // такой вызов блокирует основное окно пока не закончит работу данное окно

			if (editWindow.DialogResult.Value)
			{
				dt.Rows.Add(editWindow.resultRow);
				adapter.Update(dt);
			}
		}

		private void DelWorker_Click(object sender, RoutedEventArgs e)
		{
			DataRowView newRow = (DataRowView)listWorkers.SelectedItem;

			newRow.Row.Delete();
			adapter.Update(dt);
		}

		private void EditWorker_Click(object sender, RoutedEventArgs e)
		{
			DataRowView newRow = (DataRowView)listWorkers.SelectedItem;
			newRow.BeginEdit();

			WorkerWindow editWindow = new WorkerWindow(newRow.Row);
			editWindow.ShowDialog();

			if (editWindow.DialogResult.HasValue && editWindow.DialogResult.Value)
			{
				newRow.EndEdit();
				adapter.Update(dt);
			}
			else
			{
				newRow.CancelEdit();
			}
		}

		private void cbEmployee_TextChanged(object sender, TextChangedEventArgs e)
		{
			DataRowView newRow = (DataRowView)listWorkers.SelectedItem;
			newRow.CancelEdit();

		}
	}
}
