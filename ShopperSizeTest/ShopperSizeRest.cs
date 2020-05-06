using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShopperSizerREST.Controllers;
using ShopperSizerREST.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopperSizeTest
{
    [TestClass]
    public class ShopperSizeRest
    {
        [TestMethod] 
        public void GetAllNumbers()
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
