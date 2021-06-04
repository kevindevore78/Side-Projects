using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class Gum : Product
    {
        public Gum(string name, decimal price, string typeName) : base(name, price, typeName)
        {

        }

        public override string Sound()
        {
            return "Chew Chew, Yum!";
        }
    }
}
