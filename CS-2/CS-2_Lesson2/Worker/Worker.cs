using System;

namespace Worker
{
	abstract class Worker : IComparable
	{
        public Worker(string Name, int Age, int Salary)
        {
            this.Name = Name;
            this.Age = Age;
            this.Salary = Salary;
        }

        protected string Name { get; set; }
        protected int Age { get; set; }
        protected int Salary { get; set; }
        protected double AvgMonthSalary { get; set; }
		protected double OneHourSalary => Salary / (20.8 * 8);

		protected abstract double SalaryAccounting { get; }

		public int CompareTo(object obj)
		{
            if (OneHourSalary < ((Worker)obj).OneHourSalary) return 1;
            if (OneHourSalary > ((Worker)obj).OneHourSalary) return -1;
            return 0;
        }

		public override string ToString()
        {
            return $"{this.Name} {this.Age} {this.Salary}";
        }
    }
}
