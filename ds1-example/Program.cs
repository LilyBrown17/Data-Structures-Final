using System;
using System.Collections.Generic;

public class Program {
    // Create the queue
    public static Queue<string> customers = new Queue<string>();

    public static void Main() {
        Console.WriteLine("Enter customer names (type 'done' to finish):");

        // Set up the initial queue
        while (true) {
            //Get customer name and check if empty
            string customerName = Console.ReadLine() ?? string.Empty;
            if (string.IsNullOrWhiteSpace(customerName)) {
                continue;
            } 
	    
            // If "done" is typed, finish adding names
            if (customerName.ToLower() == "done") {
                break;
            }

            // Add each customer to the queue
            customers.Enqueue(customerName);
        }
        
        // Iterate through the queue
        while (customers.Count > 0) {
            // Serve the next customer in the queue
            string customer = customers.Dequeue(); 
            Console.WriteLine($"Serving {customer}");
            
            // Ask if a new customer should be added
            Console.WriteLine("Press 'N' to add a new customer, or any other key to continue service.");
	    
            // If 'N' is pressed, add a new customer to the queue
            if (Console.ReadKey().Key == ConsoleKey.N) {
                Console.Write("\nEnter new customer name: ");
		
                //Get new customer name and check if empty
                string newCustomer = Console.ReadLine() ?? string.Empty;
                if (string.IsNullOrWhiteSpace(newCustomer)) {
                    continue;
                } 

                // Add new customer to the queue
                customers.Enqueue(newCustomer);
            }
        }

        Console.WriteLine("No more customers in the queue.");
    }
}
