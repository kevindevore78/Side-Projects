using System;

namespace Capstone
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {

                Console.WriteLine("(1) Display Vending Machine Items");
                Console.WriteLine("(2) Purchase");
                Console.WriteLine("(3) Exit");
                string userSelection = Console.ReadLine();
                Console.Clear();


                if (userSelection == "1")
                {
                    // Print all items with their quantity remaining
                    Console.WriteLine("Display Vending Machine Items");
                    Console.WriteLine("Click 'Enter' to Continue");
                    Console.ReadLine();
                    Console.Clear();
                }
                else if (userSelection == "2")
                {
                    // Guiding through the purchasing process menu
                    Console.WriteLine("(1) Feed Money");
                    Console.WriteLine("(2) Select Product");
                    Console.WriteLine("(3) Finish Transaction");
                    Console.WriteLine();
                    Console.WriteLine("Current Money Provided: "); //Populate current balance = $0 to start 
                    string purchaseSelection = Console.ReadLine();
                    Console.Clear();

                    if (purchaseSelection == "1")
                    {
                        // Add Money to bank account
                        Console.WriteLine("Please add $1, $2, $5, or $10 bills and press 'Enter'");
                        Console.ReadLine();
                        Console.Clear();
                        
                    }
                    else if (purchaseSelection == "2")
                    {
                        // Select Product list populates
                        Console.WriteLine("(1) Chips");
                        Console.WriteLine("(2) Candy");
                        Console.WriteLine("(3) Drinks");
                        Console.WriteLine("(4) Gum");
                        string productSelection = Console.ReadLine();
                        Console.Clear();
                    }
                    else if (purchaseSelection == "3")
                    {
                        Console.WriteLine("Have you completed your transac");
                    }

                }
                else if (userSelection == "3")
                {
                    // Exit
                    Console.WriteLine("Thank you for giving us your money");
                    return;
                }
            }


        }
    }
}
