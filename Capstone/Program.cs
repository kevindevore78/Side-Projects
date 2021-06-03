using System;
using Capstone.Classes;
using System.Collections.Generic;
using Figgle;

namespace Capstone
{
    class Program
    {
        static void Main(string[] args)
        {
            VendingMachine myVendingMachine = new VendingMachine();
            Chips one = new Chips("Cheetos", 1.00M);
            Inventory inventory1 = new Inventory(one, 5);
            myVendingMachine.Stock.Add("a1", inventory1);
            Chips two = new Chips("Lays", 1.50M);
            Inventory inventory2 = new Inventory(two, 5);
            myVendingMachine.Stock.Add("a2", inventory2);
            Chips three = new Chips("Pringles", 2.00M);
            Inventory inventory3 = new Inventory(three, 5);
            myVendingMachine.Stock.Add("a3", inventory3);


            while (true)
            {
                string vendHeader = FiggleFonts.Standard.Render("                   Vend Master 5000");

                Console.WriteLine(vendHeader);
                Console.CursorLeft = 45;
                Console.WriteLine("(1) Vending Machine Items");
                Console.CursorLeft = 45;
                Console.WriteLine("(2) Purchase");
                Console.CursorLeft = 45;
                Console.WriteLine("(3) Exit");
                Console.CursorLeft = 50;
                string userSelection = Console.ReadLine();
                Console.Clear();

                while (true)

                    if (userSelection == "1")
                    {
                        // Print all items with their quantity remaining
                        Console.WriteLine(vendHeader);
                        foreach (KeyValuePair<string, Inventory> saleItems in myVendingMachine.Stock)
                        {
                            Console.CursorLeft = 45;
                            Console.WriteLine(saleItems.Value.Product.Name + " " + "$" + (saleItems.Value.Product.Price) + " quantity = " + saleItems.Value.Stock);

                        }

                        Console.WriteLine();
                        Console.WriteLine();
                        Console.CursorLeft = 45;
                        Console.WriteLine("Click 'Enter' to Continue");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    }

                    else if (userSelection == "2")
                    {

                        // Guiding through the purchasing process menu
                        Console.WriteLine(vendHeader);
                        Console.CursorLeft = 45;
                        Console.WriteLine("(1) Add Money");
                        Console.CursorLeft = 45;
                        Console.WriteLine("(2) Select Product");
                        Console.CursorLeft = 45;
                        Console.WriteLine("(3) Finish Transaction");
                        Console.CursorLeft = 45;
                        Console.WriteLine();
                        Console.CursorLeft = 45;
                        Console.WriteLine($"Current Balance: {myVendingMachine.Transaction.Balance}"); //Populate current balance = $0 to start -- bankaccount class tie
                        Console.WriteLine();
                        Console.CursorLeft = 55;
                        string purchaseSelection = Console.ReadLine();
                        Console.Clear();

                        if (purchaseSelection == "1")
                        {
                            // Add Money to bank account -- transaction class tie
                            Console.WriteLine(vendHeader);
                            Console.CursorLeft = 35;
                            Console.WriteLine("Please add $1, $2, $5, or $10 bills and press 'Enter'");
                            Console.WriteLine();
                            Console.CursorLeft = 50;
                            Console.WriteLine($"Current Balance: {myVendingMachine.Transaction.Balance}");
                            Console.WriteLine();
                            Console.CursorLeft = 60;
                            string moneyAdded = Console.ReadLine();
                            myVendingMachine.Transaction.FeedMoney(decimal.Parse(moneyAdded)); // Error if 'Enter' is pressed and no number is entered
                            Console.Clear();

                        }
                        else if (purchaseSelection == "2")
                        {
                            // Select Product list populates
                            Console.WriteLine(vendHeader);
                            Console.CursorLeft = 45;
                            Console.WriteLine("(1) Chips");
                            Console.CursorLeft = 45;
                            Console.WriteLine("(2) Candy");
                            Console.CursorLeft = 45;
                            Console.WriteLine("(3) Drinks");
                            Console.CursorLeft = 45;
                            Console.WriteLine("(4) Gum");
                            Console.CursorLeft = 45;
                            Console.WriteLine("(5) Return to previous menu");
                            Console.WriteLine();
                            Console.CursorLeft = 45;
                            Console.WriteLine($"Current Balance: {myVendingMachine.Transaction.Balance}");
                            Console.WriteLine();
                            Console.CursorLeft = 60;
                            string productSelection = Console.ReadLine();
                            Console.Clear();

                            if (productSelection == "1")
                            {
                                // populate the list of chips available
                                Console.WriteLine(vendHeader);
                                Console.CursorLeft = 45;
                                Console.WriteLine("Place holder for chip menu");
                                Console.ReadLine();
                                Console.Clear();
                            }
                            else if (productSelection == "2")
                            {
                                // populate the Candy available
                                Console.WriteLine(vendHeader);
                                Console.CursorLeft = 45;
                                Console.WriteLine("Place holder for candy menu");
                                Console.ReadLine();
                                Console.Clear();
                            }
                            else if (productSelection == "3")
                            {
                                //populate the Drinks available 
                                Console.WriteLine(vendHeader);
                                Console.CursorLeft = 45;
                                Console.WriteLine("Place holder for drinks available");
                                Console.ReadLine();
                                Console.Clear();
                            }
                            else if (productSelection == "4")
                            {
                                // populate gum available 
                                Console.WriteLine(vendHeader);
                                Console.CursorLeft = 45;
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
                            Console.WriteLine(vendHeader);
                            Console.CursorLeft = 40;
                            Console.WriteLine("Here is your change due in the appropiate coins!");
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.CursorLeft = 40;
                            Console.WriteLine("Press 'Enter' to return to the Main menu");
                            Console.CursorLeft = 60;
                            Console.ReadLine();
                            Console.Clear();
                            break;
                        }

                    }
                    else if (userSelection == "3")
                    {
                        // Exit
                        string ending = FiggleFonts.Tombstone.Render("Thanks for giving us your money!");
                        Console.WriteLine(ending);
                        return;
                    }
                    else if (userSelection == "4")
                    {
                        Console.WriteLine(vendHeader);
                        Console.CursorLeft = 45;
                        Console.WriteLine("Hidden Menu to Display Transaction Log");
                        Console.WriteLine();
                        Console.CursorLeft = 45;
                        Console.WriteLine("Press 'Enter' to return to the Main menu");
                        Console.ReadLine();
                        Console.Clear();
                        break;

                    }
                    else if ((userSelection!= "1")||(userSelection!= "2")|| (userSelection != "3")||(userSelection!="4"))
                    {
                        break;
                    }


            }
        }
    }
}
