

using System;

namespace CS_2_Lesson5
{
	class FullTimeWorker : Worker
	{
		public FullTimeWorker(int Id, string SurName, string Name, DateTime BirthDay, int Salary) : base(Id, SurName, Name, BirthDay, Salary)
		{
			Age = Convert.ToInt32(DateTime.Today.Year) - Convert.ToInt32(BirthDay.Year);
			AvgMonthSalary = SalaryAccounting;
		}

		protected override double SalaryAccounting => AvgMonthSalary = Salary;

		//public override string ToString()
		//{
		//	return "FuulTimeWorker " + base.ToString();
		//}
	}
}
