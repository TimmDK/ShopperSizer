using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShopperSizerREST.Controllers;
using ShopperSizerREST.Models;

namespace ShopperSizerTest
{
    [TestClass]
    public class UsersControllerTestClass
    {
        private UsersController usersController;

        [TestInitialize]
        public void init()
        {
            usersController = new UsersController();
        }

        [TestMethod]
        public void TestPutUsername()
        {
            string expected = "test";
            User user = new User(1,expected,"password");
            var result = usersController.Put(1, user);
            Assert.AreEqual(expected, result.Username);
        }

        [TestMethod]
        public void TestPutPassword()
        {
            string expected = "test";
            User user = new User(1, "username", expected);
            var result = usersController.Put(1, user);
            Assert.AreEqual(expected, result.Password);
        }

        [TestMethod]
        public void TestGet()
        {
            string expected = "expected";
            User user = new User(1, expected,"password");
            usersController.Put(1, user);
            string actual = usersController.Get()[0].Username;
            Assert.AreEqual(expected, actual);
        }
    }
}

