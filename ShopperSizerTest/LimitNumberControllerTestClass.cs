using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShopperSizerREST.Controllers;
using ShopperSizerREST.Models;

namespace ShopperSizerTest
{
    [TestClass]
    public class LimitNumberControllerTestClass
    {
        private LimitNumberController lnc;

        [TestInitialize]
        public void init()
        {
            lnc = new LimitNumberController();
        }

        [TestMethod]
        public void TestPut()
        {
            int expected = 50;
            LimitNumber ln= new LimitNumber(1,expected);
            var result = lnc.Put(1, ln);
            Assert.AreEqual(expected,result.LimitTal);
        }
        [TestMethod]
        public void TestGet()
        {
            int expected = 200000000;
            LimitNumber ln = new LimitNumber(1, expected);
            lnc.Put(1,ln);
            int actual = lnc.Get()[0].LimitTal;
            Assert.AreEqual(expected,actual);
        }
    }
}
