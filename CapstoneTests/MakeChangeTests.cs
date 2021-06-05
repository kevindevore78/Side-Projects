using Capstone.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace CapstoneTests
{
    [TestClass]
    public class MakeChangeTests
    {
        [TestMethod]
        [DataRow("2", "1.65", new int[] {1,1,0}, DisplayName = "Make change to return 1 quarter, 1 dime")]
        [DataRow("2", "1.95", new int[] {0,0,1}, DisplayName = "Make change to return 1 nickle")]
        [DataRow("2", "1.60", new int[] {1,1,1}, DisplayName = "Make change to return 1 quarter, 1 dime, 1 nickle")]
        [DataRow("2", "1.90", new int[] {0,1,0}, DisplayName = "Make change to return 1 dime")]
        [DataRow("2", "2", new int[] {0,0,0}, DisplayName = "To return no change")]
        [DataRow("5", "2.70", new int[] {9,0,1}, DisplayName = "Make change to return 9 quarter, 1 nickle")]
        public void TestScenarios(string amountEnteredAsString, string costOfItemAsString, int[] expected)
        {
            decimal amountEntered = decimal.Parse(amountEnteredAsString);
            decimal costOfItem = decimal.Parse(costOfItemAsString);
            Transaction dollar = new Transaction();

            dollar.FeedMoney(amountEntered);
            dollar.MakeSale(costOfItem);
            int[] actual = dollar.MakeChange();

            CollectionAssert.AreEqual(actual, expected);
        }
    }
}
