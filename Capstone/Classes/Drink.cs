using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class Drink : Product
    {
        public Drink(string name, decimal price) : base(name, price)
        {

        }

        public override void Sound()
        {
            Console.WriteLine("Glug Glug, Yum!");
        }
    }
}
