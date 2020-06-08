using System;

namespace Worker
{
	class PartTimeWorker : Worker, IComparable
	{
		public PartTimeWorker(string Name, int Age, int Salary) : base(Name, Age, Salary)
		{
		}

		protected override double SalaryAccounting => AvgMonthSalary = 20.8 * 8 * OneHourSalary;

		public override string ToString()
		{
			return "PartTimeWorker " + base.ToString();
		}
	}
}
