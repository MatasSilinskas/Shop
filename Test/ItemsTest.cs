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
            //Testas grąžina neigiamą rezultatą, rodo, kad 2.86 != 2.86 :D
            //arange
            KeyValuePair<string, double> expected = new KeyValuePair<string, double>("Maxima", 2.86);
            Items items = new Items
            {
                new Item("Duona", "Maxima", 0.89),
                new Item("Svogūnai", "Maxima", 0.29),
                new Item("Ledai", "Maxima", 0.59),
                new Item("Sultys Cido", "Maxima", 1.09)
            };

            //act
            KeyValuePair<string, double> actual = items.ShopRecommendation();

            //assert
            Assert.AreEqual(expected, actual);
        }
    }
}
