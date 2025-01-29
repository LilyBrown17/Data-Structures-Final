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
        Console.WriteLine("All customers have been served.");
    }

    // Get the initial list of customer names and assign them to the correct queues
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

            Console.WriteLine("Enter 'VIP' for VIP customers or 'Normal' for regular customers:");
            string customerType = Console.ReadLine() ?? string.Empty;
            if (string.IsNullOrWhiteSpace(customerType)) {
                continue;
            }

            // Assign customer to the correct queue
            if (customerType.ToLower() == "vip") {
                // Assign VIP customer to queue
                vipQueue.Enqueue(customerName);
            }
            else {
                // Assign regular customer to shortest line
                FindShortestLine(customerName);
            }
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

    // Process all customers and serve VIP customers
    public static void ProcessCustomers() {
        while (true) {
            // If there are any VIP customers, serve them
            if (vipQueue.Count > 0) {
                string currentVip = vipQueue.Dequeue();
                Console.WriteLine($"Serving VIP customer: {currentVip}");
            }
            // Check for regular customers and serve them
            else if (!ServeRegularCustomer()) {
                // If all queues are empty, exit
                break;
            }

            // Ask to add new customer
	        Console.WriteLine("Press 'N' to add a new customer, or any other key to continue.");
            
            // If N is pressed, get new customer
            if (Console.ReadKey().Key == ConsoleKey.N) {
                GetNewCustomer();
            }
        }
    }

    // Serve regular customers
    public static bool ServeRegularCustomer() {
        // Find the first non-empty regular queue
        foreach (var line in checkoutLines) {
            if (line.Count > 0) {
                //Serve the first customer and return true
                string currentCustomer = line.Dequeue();
                Console.WriteLine($"Serving {currentCustomer} from checkout line.");
                return true;
            }
        }

        // If all regular queues are empty, return false
        return false;
    }

    // Add a new customer to the queues
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
        
        // Assign customer to the correct queue
        if (customerType.ToLower() == "vip") {
            // Assign VIP customer to queue
            vipQueue.Enqueue(newCustomer);
        }
        else {
            // Assign regular customer to shortest line
            FindShortestLine(newCustomer);
        }
    }
}
