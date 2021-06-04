using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class Inventory
    {
        public Product Product { get; private set; }
        public int Stock { get; private set; }
        
        /// <summary>
        /// Constructs an Inventory object that has a 
        /// product object and the quantity of that 
        /// product in stock.
        /// </summary>
        /// <param name="product"></param>
        /// <param name="stock"></param>
        public Inventory(Product product, int stock)
        {
            this.Product = product;
            this.Stock = stock;
        }

        /// <summary>
        /// When a sale occurs, this method is called
        /// to take out of stock what was sold
        /// </summary>
        public void LowerStock()
        {
            this.Stock--;
        } 
    }
}
