using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class Inventory
    {
        public Product Product { get; private set; }
        public int Stock { get; private set; }
        
        public Inventory(Product product, int stock)
        {
            this.Product = product;
            this.Stock = stock;
        }

        public void LowerStock()
        {
            this.Stock--;
        } 
    }
}
