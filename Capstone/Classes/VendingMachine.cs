using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class VendingMachine
    {
        public Dictionary<string, Inventory> Stock { get; } =
            new Dictionary<string, Inventory>();
        public Transaction Transaction { get; set; }

        public void Vend()
        {

        }
    }
}
