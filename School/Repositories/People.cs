using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Repositories
{
    public class People : Repository
    {
        public void Persist(IEnumerable<Person> people)
        {
            var dataTable = new DataTable();
            dataTable.Columns.Add("Id", typeof (Guid));
            dataTable.Columns.Add("FirstName", typeof (string));
            dataTable.Columns.Add("CountryCode", typeof (string));
            foreach (var person in people)
            {
                dataTable.Rows.Add(person.Id, person.FirstName, person.CountryCode);
            }
            Persist(dataTable);
        }

        private static void Persist(DataTable dataTable)
        {
            using (var sqlConnection = new SqlConnection(ConnectionString))
            {
                using (var sqlCommand = new SqlCommand("PersistPeople", sqlConnection)
                {
                    CommandType = CommandType.StoredProcedure
                })
                {
                    sqlConnection.Open();
                    var sqlParameter = sqlCommand.Parameters.AddWithValue("@Person", dataTable);
                    sqlParameter.SqlDbType = SqlDbType.Structured;
                    sqlParameter.TypeName = "Person";
                    sqlCommand.ExecuteNonQuery();
                }
            }
        }

        public static void Persist(Person person)
        {
            var dataTable = new DataTable();
            dataTable.Columns.Add("Id", typeof (Guid));
            dataTable.Columns.Add("FirstName", typeof (string));
            dataTable.Columns.Add("CountryCode", typeof (string));
            dataTable.Rows.Add(person.Id, person.FirstName, person.CountryCode);
            Persist(dataTable);
        }
    }
}