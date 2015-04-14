using System;

namespace Entities
{
    public class Teacher : Person
    {
        internal Teacher()
        {
        }

        public Teacher(Guid id, string firstName, Country country)
            : base(id, firstName, country)
        {
        }
    }
}