using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex213
{
    public class Worker
    {
        public Worker(string Name, int Age, int Salary)
        {
            this.Name = Name;
            this.Age = Age;
            this.Salary = Salary;
        }

        public string Name { get; set; }
        public int Age { get; set; }
        public int Salary { get; set; }

        public override string ToString()
        {
            return $"{this.Name} {this.Age} {this.Salary} ";
        }

    } 
}
