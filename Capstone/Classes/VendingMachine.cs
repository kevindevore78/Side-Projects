using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Capstone.Classes
{
    public class VendingMachine
    {
        public Dictionary<string, Inventory> Stock { get; private set; } =
            new Dictionary<string, Inventory>();
        public Transaction Transaction { get; private set; } = new Transaction();

        /// <summary>
        /// Constructs a Vending machine object and also
        /// creates a logfile.txt for logging
        /// </summary>
        public VendingMachine()
        {
            string logFilePath = Logger.logFile;
            string salesReportFilePath = Logger.salesReportFile;
            string tempSalerReportFilePath = Logger.tempSalesReportFile;
            try
            {
                using (StreamWriter logFileWriter = new StreamWriter(logFilePath, true))
                using (StreamWriter salesReportWriter = new StreamWriter(salesReportFilePath, true))
                using (StreamWriter tempSalesReportWriter = new StreamWriter(tempSalerReportFilePath)) { }

            }
            catch
            {
                Console.WriteLine("Failed to create a log file.");
            }


        }

        /// <summary>
        /// Returns a list of the possible selection slots
        /// for the vending machine
        /// </summary>
        /// <returns>List of string</returns>
        public List<string> ReturnPossibleSlots()
        {
            List<string> listToReturn = new List<string>();
            foreach(KeyValuePair<string, Inventory> kvp in this.Stock)
            {
                listToReturn.Add(kvp.Key);
            }
            return listToReturn;
        }

        /// <summary>
        /// Reads through a file to restock the vending machin
        /// </summary>
        /// <param name="restockFile">Needs a text file to read from, containing '|'
        /// delimited values</param>
        public void Restock(string restockFile)
        {
            try
            {
                using (StreamReader reader = new StreamReader(restockFile))
                {
                    while (!reader.EndOfStream)
                    {
                        string thisLine = reader.ReadLine();
                        string[] restockInfo = thisLine.Split('|');

                        if(restockInfo[3] == "Chip")
                        {
                            Chip chip = new Chip(restockInfo[1], decimal.Parse(restockInfo[2]), "Chip");
                            Inventory inventory = new Inventory(chip, 5);
                            this.Stock.Add(restockInfo[0], inventory);
                        }
                        else if (restockInfo[3] == "Candy")
                        {
                            Candy candy = new Candy(restockInfo[1], decimal.Parse(restockInfo[2]), "Candy");
                            Inventory inventory = new Inventory(candy, 5);
                            this.Stock.Add(restockInfo[0], inventory);
                        }
                        else if (restockInfo[3] == "Drink")
                        {
                            Drink drink = new Drink(restockInfo[1], decimal.Parse(restockInfo[2]), "Drink");
                            Inventory inventory = new Inventory(drink, 5);
                            this.Stock.Add(restockInfo[0], inventory);
                        }
                        else if (restockInfo[3] == "Gum")
                        {
                            Gum gum = new Gum(restockInfo[1], decimal.Parse(restockInfo[2]), "Gum");
                            Inventory inventory = new Inventory(gum, 5);
                            this.Stock.Add(restockInfo[0], inventory);
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Text file not found");
            }
        }


        /// <summary>
        /// Must be uppercase (Letter)(Number)
        /// ex. A1, B2, C3
        /// </summary>
        /// <param name="slotLocation"></param>
        public bool Vend(string slotLocation)
        {
            foreach(KeyValuePair<string, Inventory> kvp in this.Stock)
            {
                if(slotLocation == kvp.Key)
                {
                    if(kvp.Value.Stock > 0)
                    {
                        kvp.Value.LowerStock();
                        Logger.Log(
                            (kvp.Value.Product.Name + " " + kvp.Key),
                            (this.Transaction.Balance),
                            (this.Transaction.Balance - kvp.Value.Product.Price));
                        Logger.AppendToSalesReport(kvp.Value.Product.Name);
                        return this.Transaction.MakeSale(kvp.Value.Product.Price);
                    }
                    else
                    {
                        return false;
                    }

                }
            }
            return false;
        }
    }
}
