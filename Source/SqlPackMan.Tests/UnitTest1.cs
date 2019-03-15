using NUnit.Framework;
using SqlPackMan.Models;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            string db = "[PackManContext-f70699d6-6d28-46ee-bc49-26e99d8c7d95]";
            string name = "Environment";
            DbObjectDAL dal = new DbObjectDAL();
            string type = dal.GetDbObjectType(name,db);


            Assert.Pass();
        }
    }
}