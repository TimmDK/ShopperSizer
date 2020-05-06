using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShopperSizerREST.Controllers;
using ShopperSizerREST.Models;
using System.Collections.Generic;

namespace ShopperSizerTest
{
    [TestClass]
    public class ShopperSizerTestClass
    {
        [TestMethod]
        public void TestAll()
        {
            //Arange
            List<LiveNumber> list = new List<LiveNumber>() { new LiveNumber(1, 1) };

            LiveNumberController ln = new LiveNumberController();

            List<LiveNumber> result = ln.Get();
            //Act
            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(list.Count, result.Count);
        }

        [TestMethod]
        public void TestGet()
        {
            List<LiveNumber> list = new List<LiveNumber>() { new LiveNumber(1, 1), new LiveNumber(2, 2) };

            LiveNumberController ln = new LiveNumberController();

            LiveNumber result = ln.Get(1);

            Assert.IsNotNull(result);
            Assert.AreEqual(list[0].Id, result.Id);
        }


        [TestMethod]
        public void TestPut()
        {
            List<LiveNumber> list = new List<LiveNumber>() { new LiveNumber(1, 1), new LiveNumber(2, 2) };

            LiveNumberController ln = new LiveNumberController();

            var result = ln.Put(1, new LiveNumber(1, 4));

            Assert.AreEqual(4, result.Number);
        }

    }
}
