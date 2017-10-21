using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Logic.Tests
{
    [TestClass()]
    public class StoreListTests
    {
        [TestMethod()]
        public void CalculatePriceTest()
        {
            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.GetCultureInfo("en-US");
            double expected = 3.1;
            List<string> items = new List<string>();
            items.Add("Duona");
            items.Add("Sviestas");
            //StoreList storeList = new StoreList(items);
            //double actual = storeList.CalculatePrice("maxima");
            //Assert.AreEqual(expected, actual);
        }
    }
}