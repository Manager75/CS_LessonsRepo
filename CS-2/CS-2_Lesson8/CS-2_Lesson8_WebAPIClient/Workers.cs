using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_2_Lesson8_WebAPIClient
{
	class Workers
	{
        public int Id { get; set; }
        public int DepartmentId { get; set; }
        public string SurName { get; set; }
        public string FirstName { get; set; }
        public string Birthday { get; set; }
        public double Salary { get; set; }
    }
}
