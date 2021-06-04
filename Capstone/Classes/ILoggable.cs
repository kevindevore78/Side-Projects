using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Capstone.Classes
{
    public interface ILoggable
    {
        public string LogFile { get; }

        public void Log(string logFile, string transactionType, decimal value1, decimal value2)
        {
            try
            {
                using (StreamWriter write = new StreamWriter(logFile))
                {
                    write.WriteLine($"{DateTime.Today} {DateTime.Now} {transactionType}: " +
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
