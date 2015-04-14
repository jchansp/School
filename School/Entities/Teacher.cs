using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Entities
{
    public class Teacher : Person
    {
        private readonly string _connectionString = ConfigurationManager.ConnectionStrings["Database"].ConnectionString;

        internal Teacher()
        {
            Persist();
        }

        public Teacher(Guid id, string firstName, Country country)
            : base(id, firstName, country)
        {
            Id = id;
            Persist(id);
        }

        private void Persist()
        {
            Persist(Id);
        }

        private void Persist(Guid id)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                using (var sqlCommand = new SqlCommand("SetTeachers", sqlConnection)
                {
                    CommandType = CommandType.StoredProcedure
                })
                {
                    sqlConnection.Open();
                    var dataTable = new DataTable();
                    dataTable.Columns.Add("Id", typeof (Guid));
                    dataTable.Rows.Add(id);
                    var sqlParameter = sqlCommand.Parameters.AddWithValue("@Teacher", dataTable);
                    sqlParameter.SqlDbType = SqlDbType.Structured;
                    sqlParameter.TypeName = "Teacher";
                    sqlCommand.ExecuteNonQuery();
                }
            }
        }
    }
}