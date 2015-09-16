using NUnit.Framework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assert = NUnit.Framework.Assert;

namespace Bluevolt.POC.Business
{
    [TestFixture]
    public class UserDetailsTests
    {
        [Test]
        public void SearchUserTest()
        {
            TestData.TestData.PopulateUserData();
            var user = new UserDetails();
            var searchResults = user.Search(new UserDetailsSearch() { ID = 2 });
            Assert.AreEqual(1, searchResults.Items.Count);
        }

        [Test]
        public void AddUserTest()
        {
            TestData.TestData.PopulateUserData();
            var user = new UserDetails();
            var result = user.Save(new UserDetails{
                ID = 1,
                FirstName ="Test",
                LastName = "User",
                Gender = "M",
                Password = "12345",
                Email = "test@test.com",
                UserName = "testuser"
            });
            Assert.AreEqual(true, result);
        }

        [Test]
        public void RemoveUserTest()
        {
            TestData.TestData.PopulateUserData();
            var user = new UserDetails();
            var result = user.Remove(new UserDetails { ID = 2 });
            Assert.AreEqual(true, result);
        }
    }

    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            TestData.TestData.PopulateUserData();
            var user = new UserDetails();
            var searchResults = user.Search(new UserDetailsSearch() { ID = 2 });
            Assert.AreEqual(1, searchResults.Items.Count);
        }
    }
}
