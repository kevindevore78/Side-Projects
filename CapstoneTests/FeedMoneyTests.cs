using Capstone.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace CapstoneTests
{
    [TestClass]
    public class FeedMoneyTests
    {
        [TestMethod]
        [DataRow("1", "1", DisplayName = "Test for one dollar input")]
        [DataRow("2", "2", DisplayName = "Test for two dollar input")]
        [DataRow("5", "5", DisplayName = "Test for five dollar input")]
        [DataRow("10", "10", DisplayName = "Test for ten dollar input")]
        [DataRow("-1", "0", DisplayName = "Test for negative one dollar input")]
        [DataRow("7", "0", DisplayName = "Test for seven dollar input")]
        public void TestScenarios(string amountEnteredToday, string expected)
        {
            decimal amountEntered = decimal.Parse(amountEnteredToday);
            Transaction dollar = new Transaction();

            dollar.FeedMoney(amountEntered);

            Assert.AreEqual(decimal.Parse(expected), dollar.Balance);


        }
    }
}
