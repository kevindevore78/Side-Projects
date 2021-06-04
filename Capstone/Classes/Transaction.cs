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
            Logger.Log("FEED MONEY", amountEntered, this.Balance + amountEntered);
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
        ///Returns the money left in the balance
        /// to the user
        /// </summary>
        /// <returns>Returns an int array where
        /// [0] is quarters
        /// [1] is dimes
        /// [2] is nickels</returns>
        public int[] MakeChange()
        {

            Logger.Log("GIVE CHANGE", this.Balance, 0.00M);

            int[] changeInQuartersDimesNickels = new int[3];

            decimal quarters = this.Balance / 0.25M;
            changeInQuartersDimesNickels[0] = (int)Math.Round(quarters, 0);
            this.Balance = this.Balance - changeInQuartersDimesNickels[0];

            decimal dimes = this.Balance / 0.10M;
            changeInQuartersDimesNickels[1] = (int)Math.Round(dimes, 0);
            this.Balance = this.Balance - changeInQuartersDimesNickels[1];

            decimal nickels = this.Balance / 0.05M;
            changeInQuartersDimesNickels[2] = (int)Math.Round(nickels, 0);
            this.Balance = this.Balance - changeInQuartersDimesNickels[2];

            return changeInQuartersDimesNickels;
        }
    }
}
