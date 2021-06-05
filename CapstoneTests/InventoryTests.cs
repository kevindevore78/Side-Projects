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
        [DataRow("sucker", "0.50", "Candy", 3, 2, DisplayName = "Test for one candy out inventory goes down by one")]
        [DataRow("sucker", "0.50", "Candy", 4, 3, DisplayName = "Test for one candy out inventory goes down by one")]
        [DataRow("sucker", "0.50", "Candy", 5, 4, DisplayName = "Test for one candy out inventory goes down by one")]
        [DataRow("sucker", "0.50", "Candy", 1, 0, DisplayName = "Test for one candy out inventory goes down by one")]
        [DataRow("sucker", "0.50", "Candy", 0, 0, DisplayName = "Test for no candy available to dispense")]
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
