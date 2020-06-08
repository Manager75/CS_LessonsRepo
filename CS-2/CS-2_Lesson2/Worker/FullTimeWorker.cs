

namespace Worker
{
	class FullTimeWorker : Worker
	{
		public FullTimeWorker(string Name, int Age, int Salary) : base(Name, Age, Salary)
		{
		}

		protected override double SalaryAccounting => AvgMonthSalary = Salary;

		public override string ToString()
		{
			return "FullTimeWorker " + base.ToString();
		}
	}
}
