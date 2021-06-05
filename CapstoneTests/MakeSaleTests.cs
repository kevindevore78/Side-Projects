using Capstone.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace CapstoneTests
{
    [TestClass]
    public class MakeSaleTests
    {
        [TestMethod]
        [DataRow("1", "0", true, "1", DisplayName = "A 1 is inserted and a sale can be made" )]
        [DataRow("1.75", "0.25", true, "2", DisplayName = "A 2 is inserted and a sale can be made")]
        [DataRow("1.75", "1", false, "1", DisplayName = "A 1 is inserted and a sale can't be made")]
        [DataRow("3", "0", false, "0", DisplayName = "A 3 can't be inserted so no balance no sale")]
        public void TestScenarios(string costOfItemAsString, string expectedBalance, bool expected, string amountEnteredAsString)
        {
            decimal amountEntered = decimal.Parse(amountEnteredAsString);
            decimal costOfItem = decimal.Parse(costOfItemAsString);
            Transaction dollar = new Transaction();
            

            dollar.FeedMoney(amountEntered);
            bool actual = dollar.MakeSale(costOfItem);

            Assert.AreEqual(decimal.Parse(expectedBalance), dollar.Balance);
            Assert.AreEqual(expected, actual);

        }
    }
}
