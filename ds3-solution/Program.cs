using System.Collections;

class Node {
    public int Data { get; set; }

    public string Name { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data, string name) {
        this.Data = data;
        this.Name = name;
    }

    public void Insert(int value, string name) {
        // If value already in Tree, do not add
        if (value == Data) {
            // Do nothing
        }
        // If value is less than current Node, move left
        else if (value < Data) {
            // If no further Nodes, insert left
            if (Left is null) {
                Left = new Node(value, name);
            }
            // Continue to the next Subtree
            else {
                Left.Insert(value, name);
            }  
        }
        // If value is greater than current Node, move right 
        else {
            // If no further Nodes, insert right
            if (Right is null) {
                Right = new Node(value, name);
            }
            // Continue to the next Subtree
            else {
                Right.Insert(value, name);
            }
        }
    }

    public bool Contains(int value) {
	    // If value is equal to current Node, return true
        if (value == Data) {
            return true;
        }
	    // If value is less than current Node, move left
        else if (value < Data) {
	        // If no further Nodes, return false
            if (Left is null) {
                return false;
            }
            // Continue to the next Subtree
            else {
                return Left.Contains(value);
            }
        }
	    // If value is greater than current Node, move right
        else {
            // If no further Nodes, return false
            if (Right is null) {
                return false;
            }
            // Continue to the next Subtree
            else {
                return Right.Contains(value);
            }
        }
    }
}

class BinarySearchTree : IEnumerable<(int, string)> {
    private Node? root;

    public void Insert(int value, string name) {
        Node node = new Node(value, name);
        if (root is null) {
            root = node; // Assigns the new Node to the Root Node
        }
        else {
            root.Insert(value, name); // Calls the Node class's Insert function
        }
    }

    // Check to see if the tree contains a certain value (returns true if found, false if not found)
    public bool Contains(int value) {
        return root != null && root.Contains(value);
    }

    /// Yields all values in the tree
    IEnumerator IEnumerable.GetEnumerator() {
        // call the generic version of the method
        return GetEnumerator();
    }

    /// Iterate forward through the BST
    public IEnumerator<(int, string)> GetEnumerator() {
        var values = new List<(int, string)>();
        TraverseForward(root, values);
        foreach (var value in values) {
            yield return value;
        }
    }

    private void TraverseForward(Node? node, List<(int, string)> values) {
        if (node is not null) {
            TraverseForward(node.Left, values);
            values.Add((node.Data, node.Name));
            TraverseForward(node.Right, values);
        }
    }
}

class Program {
    static void Main(string[] args) {
        BinarySearchTree schedule = new BinarySearchTree();

        // Add events to schedule
        schedule.Insert(7, "Breakfast");
        schedule.Insert(13, "Leave for Work");

        // Allow user to add events to schedule
        AddEvent(schedule);

        // Print final schedule
        Console.WriteLine("Schedule:");
        foreach (var (time, item) in schedule) {
            Console.WriteLine($"{ConvertTime(time)} -- {item}");
        }
    }

    // Allow user to add events
    static void AddEvent(BinarySearchTree tree) {
        while (true) {
            Console.WriteLine("Please input a specific hour in 24-hour time (0 = Midnight, 6 = 6 AM, 12 = Noon, 18 = 6 PM, etc.): \n (If finished, enter 'done')");
            // Check if input is empty
            string time_input = Console.ReadLine() ?? string.Empty;
            if (string.IsNullOrWhiteSpace(time_input)) {
                continue;
            }
            // Check if "done" entered
            if (time_input.ToLower() == "done") {
                break;
            }
            
            // Convert string to int
            if (Int32.TryParse(time_input, out int time_value)) {
                // Check if time value is in tree
                if (tree.Contains(time_value)) {
                    Console.WriteLine("Invalid input (time already scheduled).");
                }
                else if (time_value > 23) {
                    Console.WriteLine("Invalid input (time greater than 23/11 PM).");
                }
                else {
                    Console.WriteLine("Please enter the event happening at this time:");
                    // Check if input is empty
                    string name_value = Console.ReadLine() ?? string.Empty;
                    if (string.IsNullOrWhiteSpace(name_value)) {
                        continue;
                    }
                    else {
                        // Insert time and event pair to tree
                        tree.Insert(time_value, name_value);
                    }
                }
            }
            // If time string cannot convert
            else {
                Console.WriteLine("Invalid input (not an integer).");
            }
        }

    }

    // Check the value for time and convert it to AM/PM as a string (for example, 0 --> 12:00 AM, 4 --> 4:00 AM, 13 --> 1:00 PM, etc.)
    static string ConvertTime(int value) {
        if (value == 0) {
            return "12:00 AM";
        }
        else if (value == 12) {
            return "12:00 PM";
        }
        else if (value > 12) {
            int time = value - 12;
            return $"{time}:00 PM";
        }
        else {
            return $"{value}:00 AM";
        }
    }
}
