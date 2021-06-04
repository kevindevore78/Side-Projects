using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Capstone.Classes
{
    public class VendingMachine: ILoggable
    {
        public Dictionary<string, Inventory> Stock { get; private set; } =
            new Dictionary<string, Inventory>();
        public Transaction Transaction { get; private set; } = new Transaction();
        public string LogFile { get; private set; }

        public VendingMachine()
        {
            
        }

        public string[] ReturnPossibleSlots()
        {
            string[] arrayToReturn = new string[this.Stock.Count];
            //incrementer
            int i = 0;
            foreach(KeyValuePair<string, Inventory> kvp in this.Stock)
            {
                arrayToReturn[0] = kvp.Key;
                i++;
            }
            return arrayToReturn;
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
        public void Vend(string slotLocation)
        {
            foreach(KeyValuePair<string, Inventory> kvp in this.Stock)
            {
                if(slotLocation == kvp.Key)
                {
                    kvp.Value.LowerStock();
                    this.Log(
                        this.LogFile,
                        (kvp.Value.Product + " " + kvp.Key),
                        (this.Transaction.Balance),
                        (this.Transaction.Balance - kvp.Value.Product.Price));
                    this.Transaction.MakeSale(kvp.Value.Product.Price);
                }
            }
        }

        public void Log(string logFile, string transactionType, decimal value1, decimal value2)
        {
        }
    }
}
