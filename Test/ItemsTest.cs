using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic;
using System.Collections.Generic;

namespace Test
{
    [TestClass]
    public class ItemsTest
    {
        [TestMethod]
        public void Test_ShopRecommendation()
        {
            //arange
            KeyValuePair<string, double> expected = new KeyValuePair<string, double>("IKI", 1.98);
            ItemContainer items = new ItemContainer
            {
                new Item("Duona", "Maxima", 0.89),
                new Item("Svogūnai", "Maxima", 0.29),
                new Item("Ledai", "Maxima", 0.59),
                new Item("Sultys Cido", "Maxima", 1.09)
            };
            items[0].BoughtAgain("IKI", 0.01);
            items.UpdateExistingShops();

            //act
            KeyValuePair<string, double> actual = items.ShopRecommendation();

            //assert
            Assert.AreEqual(expected.Key, actual.Key);
            Assert.AreEqual(expected.Value, actual.Value, 0.001);

        }
    }
}
