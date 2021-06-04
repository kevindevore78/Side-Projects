using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class Transaction: ILoggable
    {
        public decimal Balance { get; private set; } = 0.00M;
        public string LogFile { get; }
        
        public Transaction()
        {

        }
        /// <summary>
        /// Enters the amount into the balance of
        /// the current transaction
        /// </summary>
        /// <param name="amountEntered"></param>
        /// <returns></returns>
        public void FeedMoney(decimal amountEntered)
        {
            if(amountEntered != 1 && amountEntered != 2 && 
                amountEntered != 5 && amountEntered != 10)
            {
                Console.WriteLine("Enter an accepted $ amount.");
                return;
            }
            Log(this.LogFile, "FEED MONEY", amountEntered, this.Balance);
            this.Balance += amountEntered;
        }

        /// <summary>
        /// Takes money out of the users balance
        /// </summary>
        /// <param name="costOfItem"></param>
        public bool MakeSale(decimal costOfItem)
        {
            if(this.Balance >= costOfItem)
            {
                this.Balance -= costOfItem;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Returns the money left in the balance
        /// to the user
        /// </summary>
        /// <returns></returns>
        public void MakeChange()
        {
            Log(this.LogFile, "GIVE CHANGE", this.Balance, 0.00M);
        }

        public void Log(string logFile, string transactionType, decimal value1, decimal value2)
        {

        }


    }
}
