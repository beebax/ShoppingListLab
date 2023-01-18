using System.Collections.Generic;
using System.Diagnostics;

Dictionary<string, decimal> inventory = new Dictionary<string, decimal>();
inventory.Add("eggs", 5.30m);
inventory.Add("milk", 4.35m);
inventory.Add("bread", 3.12m);
inventory.Add("coffee", 9.45m);
inventory.Add("cheese", 6.78m);
inventory.Add("yogurt", 1.75m);
inventory.Add("cereal", 3.38m);
inventory.Add("juice", 2.65m);

List<string> cart = new List<string>();

//START SHOPPING
string stillShopping;
Console.WriteLine("Welcome to our supermarket!");
Console.WriteLine();
Console.WriteLine("Item\t\tPrice");
Console.WriteLine("=======================");
foreach (KeyValuePair<string, decimal> kvp in inventory)
{
    Console.WriteLine($"{kvp.Key}\t\t${kvp.Value}");
}

do
{
    //TAKE ORDER
    Console.WriteLine();
    Console.Write("What item would you like to order? ");
    string input = Console.ReadLine().ToLower();

    if (inventory.ContainsKey(input))
    {
        cart.Add(input);
        Console.WriteLine("Adding " + input + " to cart at $" + inventory[input]);
    }
    else
    {
        Console.WriteLine("I'm sorry, we don't carry that here.");
    }

    Console.WriteLine();
    Console.WriteLine("Would you like order anything else? Press 'y' to continue, any other key to end.");
    stillShopping = Console.ReadLine();
}
while (stillShopping == "y");

Dictionary<string, decimal> whatYouBought = new Dictionary<string, decimal>();

//display receipt
Console.WriteLine();
Console.WriteLine("Thanks for your order! You purchased...");
Console.WriteLine();
Console.WriteLine("Item\t\tPrice");
Console.WriteLine("=======================");
decimal totalBill = 0;
foreach (string c in cart)
{
    //display item and price
    Console.WriteLine($"{c}\t\t{inventory[c]}");

    //add to running bill
    totalBill += inventory[c];

    //export info to final purchase list
    whatYouBought.Add(c, inventory[c]);
}

Console.WriteLine();
Console.WriteLine("Your total today was $" + totalBill);

Console.WriteLine();
Console.WriteLine($"The most expensive item you ordered was {whatYouBought.MaxBy(kvp => kvp.Value).Key} for {whatYouBought.Values.Max()}.");
Console.WriteLine($"The least expensive item you ordered was {whatYouBought.MinBy(kvp => kvp.Value).Key} for {whatYouBought.Values.Min()}.");

Console.WriteLine();
Console.WriteLine("Thank you for shopping with us today. Goodbye!");