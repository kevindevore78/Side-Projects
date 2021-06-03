using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public abstract class Product
    {
        public string Name { get; set; }
        public decimal Price { get; private set; }

        /// <summary>
        /// Constructs a product Class with a name and price
        /// </summary>
        /// <param name="name">string</param>
        /// <param name="price">In decimal value</param>
        public Product(string name, decimal price)
        {
            this.Name = name;
            this.Price = price;
        }

        public abstract void Sound();
    }
}
