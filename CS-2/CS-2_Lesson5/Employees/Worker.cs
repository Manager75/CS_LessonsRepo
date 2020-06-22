using System;
using System.ComponentModel;

namespace CS_2_Lesson5
{
	public abstract class Worker : IComparable, INotifyPropertyChanged
	{
        string surName;
        string name;
        DateTime birthDay;
        double salary;
        double avgMonthSalary;

        public Worker(int Id, int DepartmentId, string SurName, string Name, DateTime BirthDay)
        {
            this.Id = Id;
            this.DepartmentId = DepartmentId;
            this.SurName = SurName;
            this.Name = Name;
            this.BirthDay = BirthDay;
            Age = Convert.ToInt32(DateTime.Today.Year) - Convert.ToInt32(BirthDay.Year);
        }
        public int Id { get; private set; }
        public int DepartmentId { get; private set; }
        public string SurName 
        { 
            get => surName;
            set 
            { 
                surName = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SurName))); // аргумент - Фамилия
            } 
        }
        public string Name
		{
            get => name;
			set
			{
                name = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Name))); // аргумент - Имя
            }
		}
        public DateTime BirthDay
		{
            get => birthDay;
			set
			{
                birthDay = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(BirthDay))); // аргумент - Дата рождения
			}
		}
        public int Age { get; private set; }
        public double Salary
		{
            get => salary;
			set
			{
                salary = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Salary))); // аргумент - Зараплата
			}
		}
        public double AvgMonthSalary
		{
            get => avgMonthSalary;
			set
			{
                avgMonthSalary = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AvgMonthSalary))); // аргумент - Среднемесячная зарплата
			}
		}
		public double OneHourSalary => Salary / (20.8 * 8);

		protected abstract double SalaryAccounting { get; }

		public event PropertyChangedEventHandler PropertyChanged;

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
