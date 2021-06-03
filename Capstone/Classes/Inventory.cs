﻿using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Capstone.Classes
{
    public class Inventory
    {
        public Product Product { get; set; }
        public int Stock { get; set; }
        
        public Inventory(Product product, int stock)
        {
            this.Product = product;
            this.Stock = stock;
        }

        public void Sell()
        {
            
        }

        public void Restock()
        {

        }

        public void Log()
        {

        }
    }
}