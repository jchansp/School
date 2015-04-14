using System;

namespace Entities
{
    public class Student : Person
    {
        internal Student()
        {
        }

        public Student(Guid id, string firstName, Country country) : base(id, firstName, country)
        {
        }
    }
}