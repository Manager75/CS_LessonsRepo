using System;

namespace CS_2_Lesson5
{
	public class FullTimeWorker : Worker
	{
		public FullTimeWorker(int Id, int DepartmentId, string SurName, string Name, DateTime BirthDay, double Salary) 
			: base(Id, DepartmentId, SurName, Name, BirthDay)
		{
			this.Salary = Salary;
			AvgMonthSalary = SalaryAccounting;
		}

		protected override double SalaryAccounting => AvgMonthSalary = Salary;

		//public override string ToString()
		//{
		//	return "FuulTimeWorker " + base.ToString();
		//}
	}
}
