using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace CS_2_Lesson8_WebAPIService.Models
{
	public class DataWorkers
	{
		private SqlConnection sqlConnection;

		public DataWorkers()
		{
			//db = new demoLesson7Entities();

			string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;
                                        Initial Catalog=CS2Lesson7;
                                        Integrated Security=True;
                                        Pooling=True";

			sqlConnection = new SqlConnection(connectionString);
			sqlConnection.Open();
		}

        public List<Workers> GetList()
        {
            List<Workers> list = new List<Workers>();

            string sql = @"SELECT * FROM dbWorkers";

            using (SqlCommand com = new SqlCommand(sql, sqlConnection))
            {
                using (SqlDataReader reader = com.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(
                            new Workers()
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                DepartmentId = Convert.ToInt32(reader["DepartmentId"]),
                                SurName = reader["SurName"].ToString(),
                                FirstName = reader["FirstName"].ToString(),
                                Birthday = reader["Birthday"].ToString(),
                                Salary = Convert.ToDouble(reader["Salary"])
                            });
                    }
                }
            }

            return list;

            //var r = db.People.Where(e => e.Id > 1).Select(e => new { e.FIO });
            //Debug.WriteLine(r);
            //File.WriteAllText(@"e:\1.txt", r.ToString());
            //return db.People.ToList();
        }

        public Workers GetWorkerById(int Id)
        {
            string sql = $@"SELECT * FROM dbWorkers WHERE Id={Id}";
            Workers temp = new Workers();
            using (SqlCommand com = new SqlCommand(sql, sqlConnection))
            {
                using (SqlDataReader reader = com.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        temp = new Workers()
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            DepartmentId = Convert.ToInt32(reader["DepartmentId"]),
                            SurName = reader["SurName"].ToString(),
                            FirstName = reader["FirstName"].ToString(),
                            Birthday = reader["Birthday"].ToString(),
                            Salary = Convert.ToDouble(reader["Salary"])
                        };
                    }
                }

            }
            return temp;

            //var r = db.People.First(e => e.Id == Id);
            //return r;
        }

        public bool AddWorker(Workers Worker)
        {
            try
            {
                string sqlAdd = $@" INSERT INTO dbWorkers(DepartmentId, SurName, FirstName, Birthday, Salary)
                               VALUES(N'{Worker.DepartmentId}',
                                      N'{Worker.SurName}',
                                      N'{Worker.FirstName}',
                                      N'{Worker.Birthday}',
                                      N'{Worker.Salary}') ";

                using (var com = new SqlCommand(sqlAdd, sqlConnection))
                {
                    com.ExecuteNonQuery();
                }
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}