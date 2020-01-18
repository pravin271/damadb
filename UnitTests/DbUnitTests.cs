using DamaDb.Interface;
using NUnit.Framework;

namespace UnitTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void TestDatabaseConnection()
        {
            Database db = new Database("clientdb.dama");
            var exists = System.IO.File.Exists("clientdb.dama");
            if (exists)
                Assert.Pass();
            else
                Assert.Fail();
        }
    }
}