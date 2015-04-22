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
            People.Persist(new Repositories.Person {Id = Id, FirstName = FirstName, CountryCode = Country.Code});
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
            var country = Countries.RetrieveRandomOne();
            return new Country {Code = country.Code, Name = country.Name};
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