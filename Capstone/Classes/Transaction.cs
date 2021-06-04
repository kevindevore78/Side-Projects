using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class Transaction
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
            Logger.Log("FEED MONEY", amountEntered, this.Balance);
            this.Balance += amountEntered;
        }

        /// <summary>
        /// Takes money out of the users balance
        /// </summary>
        /// <param name="costOfItem"></param>
        /// <returns>bool</returns>
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
            Logger.Log("GIVE CHANGE", this.Balance, 0.00M);
        }
    }
}
