using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class Transaction
    {
        public decimal Balance { get; private set; } = 0.00M;
        
        public Transaction()
        {

        }
        /// <summary>
        /// Enters the amount into the balance of
        /// the current transaction
        /// </summary>
        /// <param name="amountEntered"></param>
        /// <returns></returns>
        public decimal FeedMoney(decimal amountEntered)
        {
            return this.Balance += amountEntered;
        }

        public decimal MakeChange()
        {
            return 0M;
        }


    }
}
