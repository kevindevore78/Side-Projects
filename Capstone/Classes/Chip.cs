using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class Chip : Product
    {
        public Chip(string name, decimal price, string typeName) : base(name, price, typeName)
        {

        }

        public override void Sound()
        {
            Console.WriteLine("Crunch Crunch, Yum!");
        }
    }
}
