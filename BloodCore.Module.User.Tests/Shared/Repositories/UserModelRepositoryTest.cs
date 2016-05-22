using BloodCore.Module.User.Shared.Models;
using BloodCore.Module.User.Shared.Repositories;
using BloodCore.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace BloodCore.Module.User.Tests.Shared.Repositories
{
    [TestClass]
    public class UserModelRepositoryTest : PersistenceTest
    {
        private UserModelRepository Repository { get; set; }

        [TestInitialize]
        public void Initialize()
        {
            Repository = new UserModelRepository { Connection = Connection };
        }

        [TestMethod]
        public void UserModelRepository_Can_Get_All_Users()
        {
            var users = Repository.Get();
            Assert.IsNotNull(users);
            Assert.IsTrue(users.Count() > 0);

            var user = users.FirstOrDefault();
            Assert.AreEqual("Test", user.Username);
            Assert.AreEqual("test@example.com", user.Email);
            Assert.AreEqual("foo", user.Salt);
            Assert.AreEqual("bar", user.PasswordHash);
            Assert.IsTrue(DateTime.MinValue < user.CreatedAtUtc);
            Assert.IsTrue(DateTime.MinValue < user.UpdatedAtUtc);
        }

        [TestMethod]
        public void UserModelRepository_Can_Insert_New_User()
        {
            var user = new UserModel
            {
                Username = "HelloWorld",
                Email = "helloworld@example.com",
                Salt = "fooz",
                PasswordHash = "baz",
            };

            Assert.IsFalse(Repository.Get().Any(u => u.Username == "HelloWorld"));
            Assert.IsTrue(Repository.Save(user) > 0);

            var fetch = Repository.Get().FirstOrDefault(u => u.Username == "HelloWorld");
            Assert.IsTrue(fetch.Id > 0);
            Assert.AreEqual(user.Username, fetch.Username);
            Assert.AreEqual(user.Email, fetch.Email);
            Assert.AreEqual(user.Salt, fetch.Salt);
            Assert.AreEqual(user.PasswordHash, fetch.PasswordHash);
        }

        [TestMethod]
        public void UserModelRepository_Can_Update_Existing_User()
        {
            var user = Repository.Get().FirstOrDefault(u => u.Username == "Test");
            Assert.AreNotEqual("fooey", user.Salt);
            user.Salt = "fooey";
            Assert.IsTrue(Repository.Save(user) > 0);
            
            user = Repository.Get().FirstOrDefault(u => u.Username == "Test");
            Assert.AreEqual("fooey", user.Salt);
        }
    }
}
