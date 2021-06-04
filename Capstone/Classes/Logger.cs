using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Capstone.Classes
{
    public static class Logger
    {
        public static string logFile = Path.Combine(Directory.GetCurrentDirectory(), "logFile.txt");

        public static void Log(string transactionType, decimal value1, decimal value2)
        {
            try
            {
                using (StreamWriter write = new StreamWriter(logFile, true))
                {
                    write.WriteLine($"{DateTime.Today.Date.Date} {DateTime.Now} {transactionType}: " +
                        $"${value1} ${value2}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unable to write to file.");
            }
        }
    }
}
