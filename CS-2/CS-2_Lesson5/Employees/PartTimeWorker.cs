using System;

namespace CS_2_Lesson5
{
	class PartTimeWorker : Worker
	{
		public PartTimeWorker(int Id, string SurName, string Name, DateTime BirthDay, int Salary) : base(Id, SurName, Name, BirthDay, Salary)
		{
			Age = Convert.ToInt32(DateTime.Today.Year) - Convert.ToInt32(BirthDay.Year);
			AvgMonthSalary = SalaryAccounting;
		}

		protected override double SalaryAccounting => AvgMonthSalary = 20.8 * 8 * OneHourSalary;

		//public override string ToString()
		//{
		//	return "PartTimeWorker " + base.ToString();
		//}
	}
}
