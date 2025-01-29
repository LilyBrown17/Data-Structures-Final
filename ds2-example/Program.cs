using System;
using System.Collections.Generic;

class TrainStop {
    public required string _stationName { get; set; }
    public required string _arrivalTime { get; set; }
    public required string _departureTime { get; set; }
}

class TrainSchedule {
    // Linked List to store stops
    private LinkedList<TrainStop> trainScedule;

    public TrainSchedule() {
        // Initialize list
        trainScedule = new LinkedList<TrainStop>();
    }

    // Add new train stop to list end
    public void AddStop(string stationName, string arrivalTime, string departureTime) {
        var newStop = new TrainStop {
            _stationName = stationName,
            _arrivalTime = arrivalTime,
            _departureTime = departureTime
        };

        // Add stop to list end
        trainScedule.AddLast(newStop);
    }

    // Remove stop by station name
    public void RemoveStop(string stationName) {
        var node = trainScedule.First;
        while (node != null) {
            if (node.Value._stationName == stationName) {
                // Remove node from list
                trainScedule.Remove(node);
                return;
            }
            // If stop not found, check next node
            node = node.Next;
        }
    }

    // Display schedule
    public void DisplaySchedule() {
        if (trainScedule.Count == 0) {
            Console.WriteLine("There are no stops scheduled.");
            return;
        }

        Console.WriteLine("Train Schedule:");
        foreach (var stop in trainScedule) {
            Console.WriteLine($"{stop._stationName}: Arrives at {stop._arrivalTime}, Departs at {stop._departureTime}");
        }
    }
}

class Program {
    static void Main(string[] args) {
        TrainSchedule trainScedule = new TrainSchedule();

        // Add stops
        trainScedule.AddStop("London", "10:00 AM", "10:15 AM");
        trainScedule.AddStop("Glasgow", "11:00 AM", "11:15 AM");
        trainScedule.AddStop("Bristol", "12:00 PM", "12:15 PM");

        // Display schedule
        trainScedule.DisplaySchedule();

        // Remove stop
        Console.WriteLine("Removing Glasgow...");
        trainScedule.RemoveStop("Glasgow");

        // Display updated schedule
        trainScedule.DisplaySchedule();
    }
}
