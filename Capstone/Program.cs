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
            Chip one = new Chip("Cheetos", 1.00M);
            Inventory inventory1 = new Inventory(one, 5);
            myVendingMachine.Stock.Add("a1", inventory1);
            Chip two = new Chip("Lays", 1.50M);
            Inventory inventory2 = new Inventory(two, 5);
            myVendingMachine.Stock.Add("a2", inventory2);
            Chip three = new Chip("Pringles", 2.00M);
            Inventory inventory3 = new Inventory(three, 5);
            myVendingMachine.Stock.Add("a3", inventory3);   // Need to display slot number


            while (true)
            {
                // Generates header
                string vendHeader = FiggleFonts.Standard.Render("                    Vendo-Matic 800");
                // Creation of main menu
                Console.WriteLine(vendHeader);
                Console.CursorLeft = 45;
                Console.WriteLine("(1) Vending Machine Items");
                Console.CursorLeft = 45;
                Console.WriteLine("(2) Purchase");
                Console.CursorLeft = 45;
                Console.WriteLine("(3) Exit");
                Console.CursorLeft = 50;
                string userSelection = Console.ReadLine(); // Main menu selection 
                Console.Clear();

                while (true)

                    if (userSelection == "1")
                    {
                        Console.WriteLine(vendHeader); // Generates header
                        foreach (KeyValuePair<string, Inventory> saleItems in myVendingMachine.Stock) // Print all items with their quantity remaining
                        {
                            Console.CursorLeft = 45;
                            Console.WriteLine(saleItems.Key.Substring(0) + " | " + saleItems.Value.Product.Name + " | " + "$" + (saleItems.Value.Product.Price) + " | quantity = " + saleItems.Value.Stock);
                            
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
                        Console.WriteLine(vendHeader);// Generates header
                        Console.CursorLeft = 45;
                        Console.WriteLine("(1) Add Money");
                        Console.CursorLeft = 45;
                        Console.WriteLine("(2) Select Product");
                        Console.CursorLeft = 45;
                        Console.WriteLine("(3) Finish Transaction");
                        Console.CursorLeft = 45;
                        Console.WriteLine();
                        Console.CursorLeft = 45;
                        Console.WriteLine($"Current Balance: {myVendingMachine.Transaction.Balance}"); //Populate current balance = $0 to start -- transaction class tie
                        Console.WriteLine();
                        Console.CursorLeft = 55;
                        string purchaseSelection = Console.ReadLine(); // Where menu selection is entered
                        Console.Clear();

                        if (purchaseSelection == "1")
                        {
                            // Add Money to transaction class -- transaction class tie
                            Console.WriteLine(vendHeader); // Generates header
                            Console.CursorLeft = 35;
                            Console.WriteLine("Please add $1, $2, $5, or $10 bills and press 'Enter'");
                            Console.WriteLine();
                            Console.CursorLeft = 50;
                            Console.WriteLine($"Current Balance: {myVendingMachine.Transaction.Balance}"); // gets customer balance and displays
                            Console.WriteLine();
                            Console.CursorLeft = 60;
                            string moneyAdded = Console.ReadLine(); // Where money is entered
                            //if ((moneyAdded == )
                            //{
                            //    myVendingMachine.Transaction.FeedMoney(decimal.Parse(moneyAdded)); // Error if 'Enter' is pressed and no number is entered
                            //}
                            myVendingMachine.Transaction.FeedMoney(decimal.Parse(moneyAdded)); // Error if 'Enter' is pressed and no number is entered
                            Console.Clear();

                        }
                        else if (purchaseSelection == "2")
                        {
                            // Select Product list populates
                            // User can select an option. The users balance follows through out
                            Console.WriteLine(vendHeader); // Generates header
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
                            Console.WriteLine($"Current Balance: {myVendingMachine.Transaction.Balance}"); // gets customer balance and displays
                            Console.WriteLine();
                            Console.CursorLeft = 60;
                            string productSelection = Console.ReadLine(); // Where product is selected 
                            Console.Clear();

                            if (productSelection == "1")
                            {
                                // populate the list of chips available
                                Console.WriteLine(vendHeader); // Generates header
                                Console.CursorLeft = 45;
                                Console.WriteLine($"Current Balance: {myVendingMachine.Transaction.Balance}"); // gets customer balance and displays
                                Console.WriteLine();
                                Console.CursorLeft = 45;
                                Console.WriteLine("Place holder for chip menu");

                                Console.ReadLine();
                                Console.Clear();
                            }
                            else if (productSelection == "2")
                            {
                                // populate the Candy available
                                Console.WriteLine(vendHeader); // Generates header
                                Console.CursorLeft = 45;
                                Console.WriteLine($"Current Balance: {myVendingMachine.Transaction.Balance}"); // gets customer balance and displays
                                Console.WriteLine();
                                Console.CursorLeft = 45;
                                Console.WriteLine("Place holder for candy menu");
                                Console.CursorLeft = 45;
                                Console.ReadLine();
                                Console.Clear();
                            }
                            else if (productSelection == "3")
                            {
                                //populate the Drinks available 
                                Console.WriteLine(vendHeader); // Generates header
                                Console.CursorLeft = 45;
                                Console.WriteLine($"Current Balance: {myVendingMachine.Transaction.Balance}"); // gets customer balance and displays
                                Console.WriteLine();
                                Console.CursorLeft = 45;
                                Console.WriteLine("Place holder for drinks available");
                                Console.ReadLine();
                                Console.Clear();
                            }
                            else if (productSelection == "4")
                            {
                                // populate gum available 
                                Console.WriteLine(vendHeader); // Generates header
                                Console.CursorLeft = 45;
                                Console.WriteLine($"Current Balance: {myVendingMachine.Transaction.Balance}"); // gets customer balance and displays
                                Console.WriteLine();
                                Console.CursorLeft = 45;
                                Console.WriteLine("Place holder for gum");
                                Console.ReadLine();
                                Console.Clear();
                            }
                            else if (productSelection == "5")
                            {
                                //return to purchasing menu

                            }
                        }
                        else if (purchaseSelection == "3")
                        {
                            //retrun to main menu
                            //return change due 
                            Console.WriteLine(vendHeader); // Generates header
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
                        // Exit program
                        string ending = FiggleFonts.Tombstone.Render("Thanks for giving us your money!"); //Creates ending text
                        Console.WriteLine(ending);
                        return;
                    }
                    else if (userSelection == "4")
                    {
                        // Hidden menu that displays all transactions 
                        Console.WriteLine(vendHeader); // Generates header
                        Console.CursorLeft = 45;
                        Console.WriteLine("Hidden Menu to Display Transaction Log");
                        Console.WriteLine();
                        Console.CursorLeft = 45;
                        Console.WriteLine("Press 'Enter' to return to the Main menu");
                        Console.ReadLine();
                        Console.Clear();
                        break;

                    }
                    else if ((userSelection != "1") || (userSelection != "2") || (userSelection != "3") || (userSelection != "4")) //Logic to avoid entering invalid choice
                    {
                        break;
                    }


            }
        }
    }
}
