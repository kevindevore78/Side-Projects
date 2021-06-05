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
            VendingMachine myVendingMachine = new VendingMachine(); // create object myVendingMachine
            myVendingMachine.Restock(@"C:\Users\Student\git\dotnet-capstone-1-team-3\vendingmachine.csv"); // Install Items dictionary

            while (true)
            {
                // Generates header
                Console.ForegroundColor = ConsoleColor.Red;
                string vendHeader = FiggleFonts.Standard.Render("                    Vendo-Matic 800");
                // Creation of main menu
                Console.WriteLine(vendHeader);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.CursorLeft = 45;
                Console.WriteLine("(1) Vending Machine Items");
                Console.CursorLeft = 45;
                Console.WriteLine("(2) Purchase");
                Console.CursorLeft = 45;
                Console.WriteLine("(3) Exit");
                Console.WriteLine();
                Console.CursorLeft = 50;
                string userSelection = Console.ReadLine(); // Main menu selection 
                Console.Clear();

                while (true)

                    if (userSelection == "1")
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(vendHeader); // Generates header
                        Console.ForegroundColor = ConsoleColor.White;
                        foreach (KeyValuePair<string, Inventory> saleItems in myVendingMachine.Stock) // Print all items with their quantity remaining
                        {
                            Console.CursorLeft = 45;
                            Console.WriteLine(saleItems.Key.Substring(0) + " | " + saleItems.Value.Product.Name + " | " + "$" + (saleItems.Value.Product.Price) + " | quantity = " + saleItems.Value.Stock);
                        }
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.CursorLeft = 50;
                        Console.WriteLine("Click 'Enter' to Continue");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    }

                    else if (userSelection == "2")
                    {

                        // Guiding through the purchasing process menu
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(vendHeader);// Generates header
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.CursorLeft = 45;
                        Console.WriteLine("(1) Add Money");
                        Console.CursorLeft = 45;
                        Console.WriteLine("(2) Select Product");
                        Console.CursorLeft = 45;
                        Console.WriteLine("(3) Finish Transaction");
                        Console.CursorLeft = 45;
                        Console.WriteLine();
                        Console.CursorLeft = 45;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"Current Balance: ${myVendingMachine.Transaction.Balance}"); //Populate current balance = $0 to start -- transaction class tie
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.CursorLeft = 55;
                        string purchaseSelection = Console.ReadLine(); // Where menu selection is entered
                        Console.Clear();

                        if (purchaseSelection == "1")
                        {
                            // Add Money to transaction class -- transaction class tie
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(vendHeader); // Generates header
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.CursorLeft = 35;
                            Console.WriteLine("Please add $1, $2, $5, or $10 bills and press 'Enter'");
                            Console.WriteLine();
                            Console.CursorLeft = 47;
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"Current Balance: ${myVendingMachine.Transaction.Balance}"); // gets customer balance and displays
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine();
                            Console.CursorLeft = 55;
                            Console.Write("$ ");
                            string moneyAdded = Console.ReadLine(); // Where money is entered
                            Console.WriteLine();
                            if ((moneyAdded == "1") || (moneyAdded == "2") || (moneyAdded == "5") || (moneyAdded == "10"))
                            {
                                Console.CursorLeft = 53;
                                Console.WriteLine("Thank you!");
                                myVendingMachine.Transaction.FeedMoney(decimal.Parse(moneyAdded)); // Adds money to transaction if correct $ amount
                                Console.ReadLine();
                                Console.Clear();
                            }
                            else if ((moneyAdded != "1") || (moneyAdded != "2") || (moneyAdded != "5") || (moneyAdded != "10"))
                            {
                                Console.Beep(440, 200);
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.CursorLeft = 45;
                                Console.WriteLine("Please add correct dollar amount!!"); // Tells user they added wrong dollar amount
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.ReadLine();

                            }
                            Console.Clear();
                        }
                        else if (purchaseSelection == "2")
                        {
                            // Select Product list populates
                            // User can select an option. The users balance follows through out
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(vendHeader); // Generates header
                            Console.ForegroundColor = ConsoleColor.White;
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
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"Current Balance: ${myVendingMachine.Transaction.Balance}"); // gets customer balance and displays
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine();
                            Console.CursorLeft = 60;
                            string productSelection = Console.ReadLine(); // Where product is selected 
                            Console.Clear();

                            if (productSelection == "1")
                            {

                                // populate the list of chips available
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine(vendHeader); // Generates header
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.CursorLeft = 55;
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine($"Current Balance: ${myVendingMachine.Transaction.Balance}"); // gets customer balance and displays
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine();
                                Console.CursorLeft = 45;
                                foreach (KeyValuePair<string, Inventory> saleItems in myVendingMachine.Stock) // Adds Chips to the chip menu
                                {
                                    if (saleItems.Value.Product.TypeName == "Chip" && saleItems.Value.Stock >= 1)
                                    {
                                        Console.CursorLeft = 45;
                                        Console.WriteLine(saleItems.Key.Substring(0) + " | " + saleItems.Value.Product.Name + " | " + "$" + saleItems.Value.Product.Price + " | quantity = " + saleItems.Value.Stock);
                                    }
                                    if (saleItems.Value.Product.TypeName == "Chip" && saleItems.Value.Stock == 0)
                                    {
                                        Console.CursorLeft = 45;
                                        Console.WriteLine(saleItems.Key.Substring(0) + " | " + saleItems.Value.Product.Name + " | " + "$" + (saleItems.Value.Product.Price) + "| Sold Out ");
                                    }

                                }
                                Console.WriteLine();
                                Console.WriteLine();
                                Console.CursorLeft = 65;
                                string itemSelection = Console.ReadLine().ToUpper();
                                List<string> possibleSlots = myVendingMachine.ReturnPossibleSlots();
                                // If the user has entered a valid slot 
                                if (possibleSlots.Contains(itemSelection))
                                {

                                    // If the item is in stock
                                    if (myVendingMachine.Stock[itemSelection].Stock > 0)
                                    {
                                        bool saleMade = myVendingMachine.Vend(itemSelection);
                                        if (saleMade == true) // If sale is made
                                        {
                                            Console.Clear();                                           
                                            Console.WriteLine();
                                            Console.WriteLine();
                                            Console.WriteLine();
                                            Console.WriteLine();
                                            Console.ForegroundColor = ConsoleColor.Yellow;
                                            Console.CursorLeft = 25;
                                            Console.WriteLine(myVendingMachine.Stock[itemSelection].Product.Name + "   " + "" + " Price: $" + myVendingMachine.Stock[itemSelection].Product.Price + "    " + "Remaining balance: $" + myVendingMachine.Transaction.Balance + "   " + myVendingMachine.Stock[itemSelection].Product.Sound());
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.WriteLine();
                                            Console.WriteLine();
                                            Console.WriteLine();
                                            Console.CursorLeft = 50;
                                            Console.WriteLine("Press 'Enter' to continue");
                                            Console.ReadLine();
                                            Console.Clear();
                                        }
                                        else if (saleMade == false) // If funds are too low
                                        {
                                            Console.Clear();
                                            Console.Beep(440, 200);
                                            Console.WriteLine();
                                            Console.WriteLine();
                                            Console.WriteLine();
                                            Console.WriteLine();
                                            Console.WriteLine();
                                            Console.WriteLine();
                                            Console.ForegroundColor = ConsoleColor.Yellow;                                           
                                            Console.WriteLine(FiggleFonts.Standard.Render("   Please add more money"));
                                            Console.WriteLine();
                                            Console.WriteLine();
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.CursorLeft = 45;
                                            Console.WriteLine("Press 'Enter' to continue");
                                            Console.ReadLine();
                                            Console.Clear();
                                        }
                                    }
                                    else
                                    {
                                        Console.Clear(); // If Item is sold out
                                        Console.Beep(440, 200);
                                        Console.WriteLine();
                                        Console.WriteLine();
                                        Console.WriteLine();
                                        Console.WriteLine();
                                        Console.WriteLine();
                                        Console.WriteLine();
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine(FiggleFonts.Standard.Render("                                   Sold Out !!!!"));
                                        Console.WriteLine();
                                        Console.WriteLine();
                                        Console.ForegroundColor = ConsoleColor.White;
                                        Console.CursorLeft = 43;
                                        Console.WriteLine("Press 'Enter' to continue");
                                        Console.ReadLine();
                                        Console.Clear();
                                    }
                                }Console.Clear();
                            }
                            else if (productSelection == "2")
                            {
                                // populate the Candy available
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine(vendHeader); // Generates header
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.CursorLeft = 50;
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine($"Current Balance: ${myVendingMachine.Transaction.Balance}"); // gets customer balance and displays
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine();
                                Console.CursorLeft = 45;
                                foreach (KeyValuePair<string, Inventory> saleItems in myVendingMachine.Stock) // Adds Candy to the machine
                                {
                                    if (saleItems.Value.Product.TypeName == "Candy" && saleItems.Value.Stock >= 1) // Displays amount if greater than 0
                                    {
                                        Console.CursorLeft = 45;
                                        Console.WriteLine(saleItems.Key.Substring(0) + " | " + saleItems.Value.Product.Name + " | " + "$" + (saleItems.Value.Product.Price) + " | quantity = " + saleItems.Value.Stock);
                                    }
                                    if (saleItems.Value.Product.TypeName == "Candy" && saleItems.Value.Stock == 0) // Displays sold out if amount is 0
                                    {
                                        Console.CursorLeft = 45;
                                        Console.WriteLine(saleItems.Key.Substring(0) + " | " + saleItems.Value.Product.Name + " | " + "$" + (saleItems.Value.Product.Price) + "| Sold Out ");
                                    }

                                }
                                Console.WriteLine();
                                Console.WriteLine();
                                Console.CursorLeft = 60;
                                string itemSelection = Console.ReadLine().ToUpper();
                                List<string> possibleSlots = myVendingMachine.ReturnPossibleSlots();
                                // If the user has entered a valid slot 
                                if (possibleSlots.Contains(itemSelection))
                                {

                                    // If the item is in stock
                                    if (myVendingMachine.Stock[itemSelection].Stock > 0)
                                    {
                                        bool saleMade = myVendingMachine.Vend(itemSelection);
                                        if (saleMade == true) // If sale is made
                                        {
                                            Console.Clear();
                                            Console.WriteLine();
                                            Console.WriteLine();
                                            Console.WriteLine();
                                            Console.WriteLine();
                                            Console.ForegroundColor = ConsoleColor.Yellow;
                                            Console.CursorLeft = 25;
                                            Console.WriteLine(myVendingMachine.Stock[itemSelection].Product.Name + "   " + "" + " Price: $" + myVendingMachine.Stock[itemSelection].Product.Price + "    " + "Remaining balance: $" + myVendingMachine.Transaction.Balance + "   " + myVendingMachine.Stock[itemSelection].Product.Sound());
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.WriteLine();
                                            Console.WriteLine();
                                            Console.WriteLine();
                                            Console.CursorLeft = 50;
                                            Console.WriteLine("Press 'Enter' to continue");
                                            Console.ReadLine();
                                            Console.Clear();
                                        }
                                        else if (saleMade == false) // If funds are too low
                                        {
                                            Console.Clear();
                                            Console.Beep(440, 200);
                                            Console.WriteLine();
                                            Console.WriteLine();
                                            Console.WriteLine();
                                            Console.WriteLine();
                                            Console.WriteLine();
                                            Console.WriteLine();
                                            Console.ForegroundColor = ConsoleColor.Yellow;
                                            Console.WriteLine(FiggleFonts.Standard.Render("   Please add more money"));
                                            Console.WriteLine();
                                            Console.WriteLine();
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.CursorLeft = 45;
                                            Console.WriteLine("Press 'Enter' to continue");
                                            Console.ReadLine();
                                            Console.Clear();
                                        }
                                    }
                                    else
                                    {
                                        Console.Clear(); // If Item is sold out
                                        Console.Beep(440, 200);
                                        Console.WriteLine();
                                        Console.WriteLine();
                                        Console.WriteLine();
                                        Console.WriteLine();
                                        Console.WriteLine();
                                        Console.WriteLine();
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine(FiggleFonts.Standard.Render("                                   Sold Out !!!!"));
                                        Console.WriteLine();
                                        Console.WriteLine();
                                        Console.ForegroundColor = ConsoleColor.White;
                                        Console.CursorLeft = 43;
                                        Console.WriteLine("Press 'Enter' to continue");
                                        Console.ReadLine();
                                        Console.Clear();
                                    }
                                }
                                Console.Clear();
                            }
                            else if (productSelection == "3")
                            {
                                //populate the Drinks available 
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine(vendHeader); // Generates header
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.CursorLeft = 50;
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine($"Current Balance: ${myVendingMachine.Transaction.Balance}"); // gets customer balance and displays
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine();
                                Console.CursorLeft = 45;
                                foreach (KeyValuePair<string, Inventory> saleItems in myVendingMachine.Stock) // Adds Drinks to the machine
                                {
                                    if (saleItems.Value.Product.TypeName == "Drink" && saleItems.Value.Stock >= 1)// Displays amount if greater than 0
                                    {
                                        Console.CursorLeft = 45;
                                        Console.WriteLine(saleItems.Key.Substring(0) + " | " + saleItems.Value.Product.Name + " | " + "$" + (saleItems.Value.Product.Price) + " | quantity = " + saleItems.Value.Stock);
                                    }
                                    if (saleItems.Value.Product.TypeName == "Drink" && saleItems.Value.Stock == 0)// Displays sold out if amount is 0
                                    {
                                        Console.CursorLeft = 45;
                                        Console.WriteLine(saleItems.Key.Substring(0) + " | " + saleItems.Value.Product.Name + " | " + "$" + (saleItems.Value.Product.Price) + "| Sold Out ");
                                    }

                                }
                                Console.WriteLine();
                                Console.WriteLine();
                                Console.CursorLeft = 60;
                                string itemSelection = Console.ReadLine().ToUpper();
                                List<string> possibleSlots = myVendingMachine.ReturnPossibleSlots();
                                // If the user has entered a valid slot 
                                if (possibleSlots.Contains(itemSelection))
                                {

                                    // If the item is in stock
                                    if (myVendingMachine.Stock[itemSelection].Stock > 0)
                                    {
                                        bool saleMade = myVendingMachine.Vend(itemSelection);
                                        if (saleMade == true)// If sale is made
                                        {
                                            Console.Clear();
                                            Console.WriteLine();
                                            Console.WriteLine();
                                            Console.WriteLine();
                                            Console.WriteLine();
                                            Console.ForegroundColor = ConsoleColor.Yellow;
                                            Console.CursorLeft = 25;
                                            Console.WriteLine(myVendingMachine.Stock[itemSelection].Product.Name + "   " + "" + " Price: $" + myVendingMachine.Stock[itemSelection].Product.Price + "    " + "Remaining balance: $" + myVendingMachine.Transaction.Balance + "   " + myVendingMachine.Stock[itemSelection].Product.Sound());
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.WriteLine();
                                            Console.WriteLine();
                                            Console.WriteLine();
                                            Console.CursorLeft = 50;
                                            Console.WriteLine("Press 'Enter' to continue");
                                            Console.ReadLine();
                                            Console.Clear();
                                        }
                                        else if (saleMade == false)// If funds are too low
                                        {
                                            Console.Clear();
                                            Console.Beep(440, 200);
                                            Console.WriteLine();
                                            Console.WriteLine();
                                            Console.WriteLine();
                                            Console.WriteLine();
                                            Console.WriteLine();
                                            Console.WriteLine();
                                            Console.ForegroundColor = ConsoleColor.Yellow;
                                            Console.WriteLine(FiggleFonts.Standard.Render("   Please add more money"));
                                            Console.WriteLine();
                                            Console.WriteLine();
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.CursorLeft = 45;
                                            Console.WriteLine("Press 'Enter' to continue");
                                            Console.ReadLine();
                                            Console.Clear(); ;
                                        }
                                    }
                                    else
                                    {
                                        Console.Clear(); // If Item is sold out
                                        Console.Beep(440, 200);
                                        Console.WriteLine();
                                        Console.WriteLine();
                                        Console.WriteLine();
                                        Console.WriteLine();
                                        Console.WriteLine();
                                        Console.WriteLine();
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine(FiggleFonts.Standard.Render("                                   Sold Out !!!!"));
                                        Console.WriteLine();
                                        Console.WriteLine();
                                        Console.ForegroundColor = ConsoleColor.White;
                                        Console.CursorLeft = 43;
                                        Console.WriteLine("Press 'Enter' to continue");
                                        Console.ReadLine();
                                        Console.Clear();
                                    }
                                }
                                Console.Clear();
                            }
                            else if (productSelection == "4")
                            {
                                // populate gum available 
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine(vendHeader); // Generates header
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.CursorLeft = 50;
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine($"Current Balance: ${myVendingMachine.Transaction.Balance}"); // gets customer balance and displays
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine();
                                Console.CursorLeft = 45;
                                foreach (KeyValuePair<string, Inventory> saleItems in myVendingMachine.Stock) // Adds gum to the machine
                                {
                                    if (saleItems.Value.Product.TypeName == "Gum" && saleItems.Value.Stock >= 1)// Displays amount if greater than 0
                                    {
                                        Console.CursorLeft = 45;
                                        Console.WriteLine(saleItems.Key.Substring(0) + " | " + saleItems.Value.Product.Name + " | " + "$" + (saleItems.Value.Product.Price) + " | quantity = " + saleItems.Value.Stock);
                                    }
                                    if (saleItems.Value.Product.TypeName == "Gum" && saleItems.Value.Stock == 0)// Displays sold out if amount is 0
                                    {
                                        Console.CursorLeft = 45;
                                        Console.WriteLine(saleItems.Key.Substring(0) + " | " + saleItems.Value.Product.Name + " | " + "$" + (saleItems.Value.Product.Price) + "| Sold Out ");
                                    }

                                }
                                Console.WriteLine();
                                Console.WriteLine();
                                Console.CursorLeft = 60;
                                string itemSelection = Console.ReadLine().ToUpper();
                                List<string> possibleSlots = myVendingMachine.ReturnPossibleSlots();
                                // If the user has entered a valid slot 
                                if (possibleSlots.Contains(itemSelection))
                                {

                                    // If the item is in stock
                                    if (myVendingMachine.Stock[itemSelection].Stock > 0)
                                    {
                                        bool saleMade = myVendingMachine.Vend(itemSelection);
                                        if (saleMade == true)// If sale is made
                                        {
                                            Console.Clear();
                                            Console.WriteLine();
                                            Console.WriteLine();
                                            Console.WriteLine();
                                            Console.WriteLine();
                                            Console.ForegroundColor = ConsoleColor.Yellow;
                                            Console.CursorLeft = 25;
                                            Console.WriteLine(myVendingMachine.Stock[itemSelection].Product.Name + "   " + "" + " Price: $" + myVendingMachine.Stock[itemSelection].Product.Price + "    " + "Remaining balance: $" + myVendingMachine.Transaction.Balance + "   " + myVendingMachine.Stock[itemSelection].Product.Sound());
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.WriteLine();
                                            Console.WriteLine();
                                            Console.WriteLine();
                                            Console.CursorLeft = 50;
                                            Console.WriteLine("Press 'Enter' to continue");
                                            Console.ReadLine();
                                            Console.Clear();
                                        }
                                        else if (saleMade == false)
                                        {
                                            Console.Clear();
                                            Console.Beep(440, 200);
                                            Console.WriteLine();
                                            Console.WriteLine();
                                            Console.WriteLine();
                                            Console.WriteLine();
                                            Console.WriteLine();
                                            Console.WriteLine();
                                            Console.ForegroundColor = ConsoleColor.Yellow;
                                            Console.WriteLine(FiggleFonts.Standard.Render("   Please add more money"));
                                            Console.WriteLine();
                                            Console.WriteLine();
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.CursorLeft = 45;
                                            Console.WriteLine("Press 'Enter' to continue");
                                            Console.ReadLine();
                                            Console.Clear();
                                        }
                                    }
                                    else
                                    {
                                        Console.Clear(); // If Item is sold out
                                        Console.Beep(440, 200);
                                        Console.WriteLine();
                                        Console.WriteLine();
                                        Console.WriteLine();
                                        Console.WriteLine();
                                        Console.WriteLine();
                                        Console.WriteLine();
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine(FiggleFonts.Standard.Render("                                   Sold Out !!!!"));
                                        Console.WriteLine();
                                        Console.WriteLine();
                                        Console.ForegroundColor = ConsoleColor.White;
                                        Console.CursorLeft = 43;
                                        Console.WriteLine("Press 'Enter' to continue");
                                        Console.ReadLine();
                                        Console.Clear();
                                    }
                                }
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
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(vendHeader); // Generates header
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.CursorLeft = 40;
                            int[] change = myVendingMachine.Transaction.MakeChange();
                            Console.CursorLeft = 35;
                            Console.WriteLine("Here is your change. Thank you for using the Vendo-Matic 800");
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine();
                            Console.CursorLeft = 55;
                            Console.WriteLine("Quarters: " + change[0]); // generates quarters for change back
                            Console.CursorLeft = 55;
                            Console.WriteLine("Dimes: " + change[1]); // generate dimes for change back
                            Console.CursorLeft = 55;
                            Console.WriteLine("Nickles: " + change[2]); // generates nickles for change back
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.White;
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
                        Console.ForegroundColor = ConsoleColor.Green;
                        string ending = FiggleFonts.Tombstone.Render("Thanks for giving us your money!"); //Creates ending text
                        Console.WriteLine(ending);
                        Console.ForegroundColor = ConsoleColor.Black;

                        return;
                    }
                    else if (userSelection == "4")
                    {
                        // Hidden menu that displays all transactions 
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(vendHeader); // Generates header
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.CursorLeft = 45;
                        string returnLog = (Logger.ReturnLog());
                        string[] returnLogArray = returnLog.Split('\n');
                        foreach (string line in returnLogArray)
                        {
                            Console.CursorLeft = 45;
                            Console.WriteLine(line);
                        }
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
