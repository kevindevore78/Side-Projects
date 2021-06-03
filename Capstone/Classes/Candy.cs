using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class Candy: Product
    {
        public Candy(string name, decimal price): base(name, price)
        {

        }

        public override void Sound()
        {
            Console.WriteLine("Munch Munch, Yum!");
        }
    }
}
