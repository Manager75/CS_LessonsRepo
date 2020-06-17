using CS_2_Lesson5.Employees;
using System;

namespace CS_2_Lesson5
{
	abstract class Worker : IComparable
	{
        public Worker(int Id, string SurName, string Name, DateTime BirthDay, int Salary)
        {
            this.Id = Id;
            this.SurName = SurName;
            this.Name = Name;
            this.BirthDay = BirthDay;
            this.Salary = Salary;
        }
        public int Id { get; private set; }
        public string SurName { get; private set; }
        public string Name { get; private set; }
        public DateTime BirthDay { get; private set; }
        public int Age { get; set; }
        public Department Department { get; set; }
        public int Salary { get; set; }
        public double AvgMonthSalary { get; set; }
		public double OneHourSalary => Salary / (20.8 * 8);

		protected abstract double SalaryAccounting { get; }

		public int CompareTo(object obj)
		{
            if (OneHourSalary < ((Worker)obj).OneHourSalary) return 1;
            if (OneHourSalary > ((Worker)obj).OneHourSalary) return -1;
            return 0;
        }

		public override string ToString()
        {
            return $"{SurName} {Name}";
        }
    }
}
