using Capstone.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace CapstoneTests
{
    [TestClass]
    public class InventoryTests
    {
        [TestMethod]
        [DataRow("sucker", "0.50", "Candy", 3, 2)]
        [DataRow("sucker", "0.50", "Candy", 4, 3)]
        [DataRow("sucker", "0.50", "Candy", 5, 4)]
        [DataRow("sucker", "0.50", "Candy", 1, 0)]
        [DataRow("sucker", "0.50", "Candy", 0, 0)]
        public void TestScenarios(string name, string priceAsString, string typeName, int stock, int expected)
        {
            decimal price = decimal.Parse(priceAsString);
            Candy candy = new Candy(name, price, typeName);
            Inventory widget = new Inventory(candy, stock);


            widget.LowerStock();


            Assert.AreEqual(expected, widget.Stock);
        }
    }
}
