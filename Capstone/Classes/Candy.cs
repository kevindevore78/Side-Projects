using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class Candy: Product
    {
        public Candy(string name, decimal price, string typeName) : base(name, price, typeName)
        {

        }

        public override string Sound()
        {
            return "Munch Munch, Yum!";
        }
    }
}
