using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class Gum : Product
    {
        public Gum(string name, decimal price) : base(name, price)
        {

        }

        public override void Sound()
        {
            Console.WriteLine("Chew Chew, Yum!");
        }
    }
}
