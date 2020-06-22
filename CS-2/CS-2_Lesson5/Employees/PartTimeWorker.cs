using System;

namespace CS_2_Lesson5
{
	public class PartTimeWorker : Worker
	{
		public PartTimeWorker(int Id, int DepartmentId, string SurName, string Name, DateTime BirthDay, double Salary) 
			: base(Id, DepartmentId, SurName, Name, BirthDay)
		{
			this.Salary = Salary;
			AvgMonthSalary = SalaryAccounting;
		}

		protected override double SalaryAccounting => AvgMonthSalary = 20.8 * 8 * OneHourSalary;

		//public override string ToString()
		//{
		//	return "PartTimeWorker " + base.ToString();
		//}
	}
}
