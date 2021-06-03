using System;
using Capstone.Classes;
using System.Collections.Generic;

namespace Capstone
{
    class Program
    {
        static void Main(string[] args)
        {

            Chips one = new Chips("Cheetos", 1.00M);
            Inventory inventory1 = new Inventory(one, 5);
            VendingMachine myVendingMachine = new VendingMachine();
            myVendingMachine.Stock.Add("a1", inventory1);
            Chips two = new Chips("Lays", 1.50M);
            Inventory inventory2 = new Inventory(two, 5);
            myVendingMachine.Stock.Add("a2", inventory2);
            Chips three = new Chips("Pringles", 2.00M);
            Inventory inventory3 = new Inventory(three, 5);
            myVendingMachine.Stock.Add("a3", inventory3);



            while (true)
            {

                Console.WriteLine("(1) Display Vending Machine Items");
                Console.WriteLine("(2) Purchase");
                Console.WriteLine("(3) Exit");
                string userSelection = Console.ReadLine();
                Console.Clear();

                while (true)

                    if (userSelection == "1")
                    {
                        // Print all items with their quantity remaining
                        foreach (KeyValuePair<string, Inventory> saleItems in myVendingMachine.Stock)
                        {
                            Console.WriteLine(saleItems.Value.Product.Name + " " + "$" + (saleItems.Value.Product.Price) + " quantity = " + saleItems.Value.Stock);


                        }
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine("Click 'Enter' to Continue");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    }

                    else if (userSelection == "2")
                    {

                        // Guiding through the purchasing process menu
                        Console.WriteLine("(1) Feed Money");
                        Console.WriteLine("(2) Select Product");
                        Console.WriteLine("(3) Finish Transaction");
                        Console.WriteLine();
                        Console.WriteLine($"Current Money Provided: {myVendingMachine.Transaction.Balance}"); //Populate current balance = $0 to start -- bankaccount class tie
                        string purchaseSelection = Console.ReadLine();
                        Console.Clear();

                        if (purchaseSelection == "1")
                        {
                            // Add Money to bank account -- transaction class tie
                            Console.WriteLine("Please add $1, $2, $5, or $10 bills and press 'Enter'");
                            string moneyAdded = Console.ReadLine();
                            myVendingMachine.Transaction.FeedMoney(decimal.Parse(moneyAdded));
                            Console.Clear();

                        }
                        else if (purchaseSelection == "2")
                        {
                            // Select Product list populates
                            Console.WriteLine("(1) Chips");
                            Console.WriteLine("(2) Candy");
                            Console.WriteLine("(3) Drinks");
                            Console.WriteLine("(4) Gum");
                            Console.WriteLine("(5) Return to previous menu");
                            string productSelection = Console.ReadLine();
                            Console.Clear();

                            if (productSelection == "1")
                            {
                                // populate the list of chips available
                                Console.WriteLine("Place holder for chip menu");
                                Console.ReadLine();
                                Console.Clear();
                            }
                            else if (productSelection == "2")
                            {
                                // populate the Candy available
                                Console.WriteLine("Place holder for candy menu");
                                Console.ReadLine();
                                Console.Clear();
                            }
                            else if (productSelection == "3")
                            {
                                //populate the Drinks available 
                                Console.WriteLine("Place holder for drinks available");
                                Console.ReadLine();
                                Console.Clear();
                            }
                            else if (productSelection == "4")
                            {
                                // populate gum available 
                                Console.WriteLine("Place holder for gum");
                                Console.ReadLine();
                                Console.Clear();
                            }
                            else if (productSelection == "5")
                            {
                                //return to main menu
                                
                            }
                        }
                        else if (purchaseSelection == "3")
                        {
                            //retrun to main menu
                            //return change due 
                            Console.WriteLine("Here is your change due in the appropiate coins!");
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.WriteLine("Press 'Enter' to return to the Main menu");
                            Console.ReadLine();
                            Console.Clear();
                            break;
                        }

                    }
                    else if (userSelection == "3")
                    {
                        // Exit
                        Console.WriteLine("Thank you for giving us your money");
                        return;
                    }
                    else if (userSelection == "4")
                    {
                        Console.WriteLine("Hidden Menu to Display Transaction Log");
                        Console.WriteLine();
                        Console.WriteLine("Press 'Enter' to return to the Main menu");
                        Console.ReadLine();
                        Console.Clear();
                        break;

                    }

            }
        }
    }
}
