using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Repositories.Tests
{
    [TestClass]
    public class People
    {
        [TestMethod]
        public void Repositories_People_PersistTest()
        {
            Repositories.People.Persist(new Person
            {
                Id = Guid.NewGuid(),
                FirstName = Guid.NewGuid().ToString(),
                CountryCode = Repositories.Countries.RetrieveRandomOne().Code
            });
        }
    }
}