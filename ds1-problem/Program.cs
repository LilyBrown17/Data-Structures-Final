using System;
using System.Collections.Generic;

public class Program {
    // Create the regular queues
    public static List<Queue<string>> checkoutLines = new List<Queue<string>> {
        new Queue<string>(), new Queue<string>(), new Queue<string>()
    };

    // Create the VIP queue
    public static Queue<string> vipQueue = new Queue<string>();

    public static void Main() {
        GetCustomers();
        ProcessCustomers();
        Console.WriteLine("All customers have been served!");
    }

    // TODO: Get the initial list of customer names and assign them to the correct queues
    public static void GetCustomers() {
        Console.WriteLine("Enter customer names (type 'done' to finish):");
        while (true) {
            string customerName = Console.ReadLine() ?? string.Empty;
            if (string.IsNullOrWhiteSpace(customerName)) {
                continue;
            }

            if (customerName.ToLower() == "done") { 
                break;
            }

            Console.WriteLine("Enter 'VIP' for VIP customer or 'Normal' for regular:");
            string customerType = Console.ReadLine() ?? string.Empty;
            if (string.IsNullOrWhiteSpace(customerType)) {
                continue;
            }

            // TODO: Assign customer to the correct queue
        }
    }

    // Find shortest line and add regular customer
    public static void FindShortestLine(string name) {
        Queue<string> shortestLine = checkoutLines[0];
        foreach (var line in checkoutLines) {
            if (line.Count < shortestLine.Count) {
                shortestLine = line;
            }
        }
        
        // Add to the correct queue
        shortestLine.Enqueue(name);
    }

    // TODO: Process all customers and serve VIP customers
    public static void ProcessCustomers() {
        while (true) {
            // TODO: If there are any VIP customers, serve them

            // TODO: Check for regular customers and serve them

            // TODO: If all queues are empty, exit

            // Ask to add a new customer during processing.
            Console.WriteLine("Press 'N' to add a new customer, or any other key to continue.");
            if (Console.ReadKey().Key == ConsoleKey.N) {
                GetNewCustomer();
            }
        }
    }

    // TODO: Serve a regular customer from the shortest line.
    public static bool ServeRegularCustomer() {
        // TODO: Find the first non-empty regular queue

        // TODO: Serve the first customer and return true

        // If all regular queues are empty, return false
        return false;
    }

    // TODO: Add a new customer to the queues
    public static void GetNewCustomer() {
        Console.Write("\nEnter new customer name: ");
        string newCustomer = Console.ReadLine() ?? string.Empty;
        if (string.IsNullOrWhiteSpace(newCustomer)) {
            return;
        }

        Console.WriteLine("Enter 'VIP' for VIP customer or 'Normal' for regular:");
        string customerType = Console.ReadLine() ?? string.Empty;
        if (string.IsNullOrWhiteSpace(customerType)) {
            return;
        }

        // TODO: Assign customer to the correct queue
    }
}