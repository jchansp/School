using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Repositories;

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

        protected Person(Guid id, string firstName, Country country)
        {
            Id = id;
            FirstName = firstName;
            Country = country;
            Persist();
        }

        protected Guid Id { get; set; }
        private string FirstName { get; set; }
        private Country Country { get; set; }

        private void Persist()
        {
            People.Persist(new Repositories.Person(Id, FirstName, Country.Code));
        }

        private void RandomPopulate()
        {
            Id = RandomId();
            FirstName = RandomFirstName();
            Country = RandomCountry();
        }

        private static Guid RandomId()
        {
            return Guid.NewGuid();
        }

        private Country RandomCountry()
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                using (var sqlCommand = new SqlCommand("RetrieveRandomCountry", sqlConnection)
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

        private static string RandomFirstName()
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