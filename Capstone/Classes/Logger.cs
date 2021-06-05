using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Capstone.Classes
{
    public static class Logger
    {
        public static string logFile = Path.Combine(Directory.GetCurrentDirectory(), "logFile.txt");
        public static string salesReportFile = Path.Combine(Directory.GetCurrentDirectory(), "salesReportFile.txt");
        public static string tempSalesReportFile = Path.Combine(Directory.GetCurrentDirectory(), "tempSalesReportFile.txt");


        /// <summary>
        ///A static method that Writes a data stream to a log file
        ///to log any transaction made.
        /// </summary>
        /// <param name="transactionType"></param>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        public static void Log(string transactionType, decimal value1, decimal value2)
        {
            try
            {
                using (StreamWriter write = new StreamWriter(logFile, true))
                {
                    write.WriteLine($"{DateTime.Now} {transactionType}: " +
                        $"${value1} ${value2}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unable to write to file.");
            }
        }

        /// <summary>
        /// Returns the log file as a string
        /// </summary>
        /// <returns>string</returns>
        public static string ReturnLog()
        {
            try
            {
                using(StreamReader reader = new StreamReader(logFile))
                {
                    return reader.ReadToEnd();
                }
            }
            catch(Exception ex)
            {
                return "Failed to return log file.";
            }
        }
        /// <summary>
        /// Checks to make sure out sales report is up to date
        /// </summary>
        /// <param name="Stock">Dicitonary of current Stock</param>
        public static void CheckSalesReportProducts(Dictionary<string, Inventory> Stock)
        {
            //Check to see if we need to add a item to our sales report
            try
            {

                using(StreamReader reader = new StreamReader(salesReportFile))
                using (StreamWriter writer = new StreamWriter(tempSalesReportFile))
                {
                    string file = reader.ReadToEnd();
                    //for each element in stock, check to see if
                    //it exists in the sales report
                    foreach (KeyValuePair<string, Inventory> kvp in Stock)
                    {
                        if (!file.Contains(kvp.Value.Product.Name))
                        {
                            writer.WriteLine($"{kvp.Value.Product.Name}|0");
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("SalesReport file was not able to be read or written.");
            }

            //add item to our sales report
            try
            {
                using (StreamReader reader = new StreamReader(tempSalesReportFile))
                using (StreamWriter writer = new StreamWriter(salesReportFile, true))
                {
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        writer.WriteLine(line);
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Could not write or read file");
            }

        }

        /// <summary>
        /// Updates the sales report text file given the
        /// name of an item called nameofitemsold
        /// </summary>
        /// <param name="nameOfItemSold"></param>
        public static void AppendToSalesReport(string nameOfItemSold)
        {
            try
            {
                using (StreamReader reader = new StreamReader(salesReportFile))
                using (StreamWriter writer = new StreamWriter(tempSalesReportFile))
                {
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        string[] lineSplit = line.Split('|');
                        if (lineSplit[0] == nameOfItemSold)
                        {
                            int updatedInt = int.Parse(lineSplit[1]);
                            updatedInt++;
                            writer.WriteLine($"{lineSplit[0]}|{updatedInt}");
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("SalesReport file was not able to be read or written.");
            }
        }

        public static string PrintSalesReport()
        {
            try
            {
                using(StreamReader reader = new StreamReader(salesReportFile))
                {
                    return reader.ReadToEnd();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Could not read from sales report file");
            }
            return "";
        }
    }
}
