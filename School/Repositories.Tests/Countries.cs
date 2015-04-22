using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Repositories.Tests
{
    [TestClass]
    public class Countries
    {
        [TestMethod]
        public void Repositories_Countries_RetrieveRandomOneTest()
        {
            Assert.IsNotNull(Repositories.Countries.RetrieveRandomOne());
        }
    }
}