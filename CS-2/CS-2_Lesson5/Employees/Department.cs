using System.ComponentModel;

namespace CS_2_Lesson5
{
	public class Department : INotifyPropertyChanged
	{
		string departmentName;
		/// <summary>
		/// Name of Department
		/// </summary>
		public string DepartmentName 
		{ 
			get => departmentName;
			set 
			{
				departmentName = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(DepartmentName))); // аргумент - Имя департамента.
			}
		}

		/// <summary>
		/// Id of Department
		/// </summary>
		public int DepartmentId { get; private set; }

		public Department(string Name, int Id)
		{
			DepartmentName = Name;
			DepartmentId = Id;
		}

		public event PropertyChangedEventHandler PropertyChanged;
	}
}
