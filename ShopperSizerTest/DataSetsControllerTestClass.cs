using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShopperSizerREST.Controllers;
using ShopperSizerREST.Models;

namespace ShopperSizerTest
{
    [TestClass]
    public class DataSetsControllerTestClass
    {
        private DataSetsController _controller;
        //vi kan ikke teste hen over en database, så vi har besluttet os for ikke at unit teste denne controller
        [TestInitialize]
        public void testInit()
        {
            //_controller = new DataSetsController(new DataSetContext(new DbContextOptions<DataSetContext>()));
            //vi kan ikke teste hen over en database, så vi har besluttet os for ikke at unit teste denne controller
        }
        //[TestMethod]
        //public async Task test()
        //{
        //    //vi kan ikke teste hen over en database, så vi har besluttet os for ikke at unit teste denne controller
        //    DataSet set1 = new DataSet();
        //    set1.Count = 50;
        //    var result = await _controller.PostDataSet(set1);
        //    Assert.AreEqual(50,result.Value.Count);
        //}

        //vi kan ikke teste hen over en database, så vi har besluttet os for ikke at unit teste denne controller

    }
}
