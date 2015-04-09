﻿using System;
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

        public Person(Guid id, string name, Country country)
        {
            Persist(id, name, country);
            Id = id;
            Name = name;
            Country = country;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public Country Country { get; set; }

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
                    sqlCommand.Parameters.AddWithValue("@CountryId", Country.Id);

                    sqlCommand.ExecuteNonQuery();
                }
            }
        }

        private void Persist(Guid id, string name, Country country)
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
                    var countrySqlParameter = sqlCommand.Parameters.AddWithValue("@Country", country);

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
            Country = RandomCountry();
        }

        private Guid RandomId()
        {
            return Guid.NewGuid();
        }

        private Country RandomCountry()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["Database"].ConnectionString;
            using (var sqlConnection = new SqlConnection(connectionString))
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
                                Id = new Guid(sqlDataReader["Id"].ToString()),
                                Name = sqlDataReader["Name"].ToString()
                            };
                        }
                    }

                    //return (Guid) sqlCommand.ExecuteScalar();
                    return country;
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