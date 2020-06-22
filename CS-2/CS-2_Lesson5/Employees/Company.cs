using System;
using System.Collections.ObjectModel;

namespace CS_2_Lesson5
{
	public class Company
	{
		public ObservableCollection<Department> departments { get; set; }
		public ObservableCollection<Worker> workers { get; set; }

		public Company(int CountDepartment, int CountWorkers)
		{
			departments = new ObservableCollection<Department>();
			workers = new ObservableCollection<Worker>();
			Random r = new Random();

			for (int i = 0; i < CountDepartment; i++)
				departments.Add(new Department($"Dep_{i + 1}", i));
			for (int i = 0; i < CountWorkers; i++)
			{
				if (i % 2 == 0)
					workers.Add(new FullTimeWorker(
						i,
						r.Next(CountDepartment),
						$"Surname_FullTime: {i + 1}",
						$"Name_{r.Next(CountWorkers)}",
						new DateTime(r.Next(1950, DateTime.Now.Year), r.Next(1, 12), r.Next(1, 28)),
						r.Next(1000, 20000)));
				else
					workers.Add(new PartTimeWorker(
						i,
						r.Next(CountDepartment),
						$"Surname_PartTime: {i + 1}",
						$"Name_{r.Next(CountWorkers)}",
						new DateTime(r.Next(1950, DateTime.Now.Year), r.Next(1, 12), r.Next(1, 28)),
						r.Next(1000, 20000)));
			}
		}
		/// <summary>
		/// Метод удаления Департамента и его сотрудников.
		/// </summary>
		/// <param name="Id"></param>
		public void DeleteDepartment (int Id)
		{
			for (int i = workers.Count-1; i >= 0; i--)
			{
				if (workers[i].DepartmentId == Id)
					workers.RemoveAt(i);
			}

			for (int i = departments.Count-1; i >= 0; i--)
			{
				if (departments[i].DepartmentId == Id)
					departments.RemoveAt(i);
			}
		}

		/// <summary>
		/// Сотрудники выбранного Департамента
		/// </summary>
		/// <param name="DepartmentId"></param>
		/// <returns></returns>
		public ObservableCollection<Worker> DepartmenWorkers (int DepartmentId)
		{
			ObservableCollection<Worker> departmentWorkers = new ObservableCollection<Worker>();
			foreach (var item in workers)
				if (item.DepartmentId == DepartmentId)
					departmentWorkers.Add(item);
			return departmentWorkers;
		}

		/// <summary>
		/// Выбранный сотрудник по Имени
		/// </summary>
		/// <param name="Name"></param>
		/// <returns></returns>
		public ObservableCollection<Worker> FindWorker (string Name)
		{
			ObservableCollection<Worker> findWorker = new ObservableCollection<Worker>();
			foreach (var item in workers)
				if (item.Name == Name)
					findWorker.Add(item);
			return findWorker;
		}
	}
}
