using Capstone.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace CapstoneTests
{
    [TestClass]
    public class VendingMachineTests
    {
        [TestMethod]
        [DataRow(5,4, DisplayName = "Test that stock will lower one")]
        [DataRow(1,0, DisplayName = "Test that stock will lower one")]
        [DataRow(0,0, DisplayName = "Test that stock will not go lower than zero")]
        public void VendTestSenarios(int stockQuantity, int expected)
        {
            VendingMachine vendingMachine = new VendingMachine();
            Chip chip = new Chip("pringles", 1.50M, "chip");
            Inventory inventory = new Inventory(chip, stockQuantity);

            vendingMachine.Stock.Add("A1", inventory);

            vendingMachine.Vend("A1");

            Assert.AreEqual(expected, vendingMachine.Stock["A1"].Stock);
            
        }
    

        
    }
}
