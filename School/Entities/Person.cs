using System;
using System.Collections.Generic;
using System.Linq;

namespace Entities
{
    public class Person
    {
        public object Name { get; set; }

        protected void RandomPopulate()
        {
            Name = RandomName();
        }

        private object RandomName()
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