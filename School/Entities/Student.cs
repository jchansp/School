using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Entities
{
    public class Student : Person
    {
        private readonly string _connectionString = ConfigurationManager.ConnectionStrings["Database"].ConnectionString;

        internal Student()
        {
            Persist();
        }

        public Student(Guid id, string firstName, Country country)
            : base(id, firstName, country)
        {
        }

        internal new void Persist()
        {
            Persist(Id);
        }

        private void Persist(Guid id)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                using (var sqlCommand = new SqlCommand("SetStudents", sqlConnection)
                {
                    CommandType = CommandType.StoredProcedure
                })
                {
                    sqlConnection.Open();
                    var dataTable = new DataTable();
                    dataTable.Columns.Add("Id", typeof(Guid));
                    dataTable.Rows.Add(id);
                    var sqlParameter = sqlCommand.Parameters.AddWithValue("@Student", dataTable);
                    sqlParameter.SqlDbType = SqlDbType.Structured;
                    sqlParameter.TypeName = "Student";
                    sqlCommand.ExecuteNonQuery();
                }
            }
        }
    }
}