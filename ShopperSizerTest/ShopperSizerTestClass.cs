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
    }
}
