using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Entities
{
    public class Person
    {
        private readonly string _connectionString = ConfigurationManager.ConnectionStrings["Database"].ConnectionString;

        internal Person()
        {
            RandomPopulate();
            Persist();
        }

        public Person(Guid id, string firstName, Country country)
        {
            Persist(id, firstName, country);
            Id = id;
            FirstName = firstName;
            Country = country;
        }

        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public Country Country { get; set; }

        private void Persist()
        {
            Persist(Id, FirstName, Country);
        }

        private void Persist(Guid id, string name, Country country)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                using (var sqlCommand = new SqlCommand("SetPeople", sqlConnection)
                {
                    CommandType = CommandType.StoredProcedure
                })
                {
                    sqlConnection.Open();
                    var dataTable = new DataTable();
                    dataTable.Columns.Add("Id", typeof (Guid));
                    dataTable.Columns.Add("FirstName", typeof (string));
                    dataTable.Columns.Add("CountryCode", typeof (string));
                    dataTable.Rows.Add(id, name, country.Code);
                    var sqlParameter = sqlCommand.Parameters.AddWithValue("@Person", dataTable);
                    sqlParameter.SqlDbType = SqlDbType.Structured;
                    sqlParameter.TypeName = "Person";
                    sqlCommand.ExecuteNonQuery();
                }
            }
        }

        protected void RandomPopulate()
        {
            Id = RandomId();
            FirstName = RandomFirstName();
            Country = RandomCountry();
        }

        private Guid RandomId()
        {
            return Guid.NewGuid();
        }

        private Country RandomCountry()
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                using (var sqlCommand = new SqlCommand("GetRandomCountry", sqlConnection)
                {
                    CommandType = CommandType.StoredProcedure
                })
                {
                    sqlConnection.Open();

                    //SqlParameter custId = cmd.Parameters.AddWithValue("@CustomerId", 10);
                    Country country = null;
                    using (var sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        if (sqlDataReader.Read())
                        {
                            country = new Country
                            {
                                Code = sqlDataReader["Code"].ToString(),
                                Name = sqlDataReader["Name"].ToString()
                            };
                        }
                    }

                    //return (Guid) sqlCommand.ExecuteScalar();
                    return country;
                }
            }
        }

        private string RandomFirstName()
        {
            return
                new List<string>
                {
                    "Hugo",
                    "Daniel",
                    "Pablo",
                    "Alejandro",
                    "Álvaro",
                    "Adrián",
                    "David",
                    "Mario",
                    "Diego",
                    "Javier"
                }.OrderBy(s => Guid.NewGuid()).First();
        }
    }
}