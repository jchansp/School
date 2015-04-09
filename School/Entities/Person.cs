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
        internal Person()
        {
            RandomPopulate();
            Persist();
        }

        public Person(Guid id, string name, Guid countryId)
        {
            Persist(id, name, countryId);
            Id = id;
            Name = name;
            CountryId = countryId;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid CountryId { get; set; }

        private void Persist()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["Database"].ConnectionString;
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                using (var sqlCommand = new SqlCommand("PersistPerson", sqlConnection)
                {
                    CommandType = CommandType.StoredProcedure
                })
                {
                    sqlConnection.Open();

                    sqlCommand.Parameters.AddWithValue("@Id", Id);
                    sqlCommand.Parameters.AddWithValue("@Name", Name);
                    sqlCommand.Parameters.AddWithValue("@CountryId", CountryId);

                    sqlCommand.ExecuteNonQuery();
                }
            }
        }

        private void Persist(Guid id, string name, Guid country)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["Database"].ConnectionString;
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                using (var sqlCommand = new SqlCommand("PersistPerson", sqlConnection)
                {
                    CommandType = CommandType.StoredProcedure
                })
                {
                    sqlConnection.Open();

                    var idSqlParameter = sqlCommand.Parameters.AddWithValue("@Id", id);
                    var nameSqlParameter = sqlCommand.Parameters.AddWithValue("@Name", name);
                    var countrySqlParameter = sqlCommand.Parameters.AddWithValue("@CountryId", country);

                    //using (var dr = command.ExecuteReader())
                    //{
                    //    if (dr.Read())
                    //    {
                    //        Label1.Text = dr["Name"].ToString();
                    //    }
                    //}

                    sqlCommand.ExecuteNonQuery();
                }
            }
        }

        protected void RandomPopulate()
        {
            Id = RandomId();
            Name = RandomName();
            CountryId = RandomCountry();
        }

        private Guid RandomId()
        {
            return Guid.NewGuid();
        }

        private Guid RandomCountry()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["Database"].ConnectionString;
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                using (var sqlCommand = new SqlCommand("GetRandomCountryId", sqlConnection)
                {
                    CommandType = CommandType.StoredProcedure
                })
                {
                    sqlConnection.Open();

                    //SqlParameter custId = cmd.Parameters.AddWithValue("@CustomerId", 10);

                    //using (var dr = command.ExecuteReader())
                    //{
                    //    if (dr.Read())
                    //    {
                    //        Label1.Text = dr["Name"].ToString();
                    //    }
                    //}

                    return (Guid) sqlCommand.ExecuteScalar();
                }
            }
        }

        private string RandomName()
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