using System;

namespace Repositories
{
    public class Person
    {
        private readonly string _countryId;
        private readonly string _firstName;
        private readonly Guid _id;

        public Person(Guid id, string firstName, string countryId)
        {
            _id = id;
            _firstName = firstName;
            _countryId = countryId;
        }

        public Guid Id
        {
            get { return _id; }
        }

        public string FirstName
        {
            get { return _firstName; }
        }

        public string CountryId
        {
            get { return _countryId; }
        }
    }
}