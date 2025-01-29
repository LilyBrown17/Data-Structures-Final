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
        BinarySearchTree students = new BinarySearchTree();

        // Add students to tree
        students.Insert(1547, "Carly Jones");
        students.Insert(1327, "Ryley Parks");
        students.Insert(2346, "Bailey Smith");
        students.Insert(1498, "Cory Liamson");

        // Ask user for additional students
        AddStudent(students);

        // Loops through and prints all students with ID
        foreach (var (number, name) in students) {
            Console.WriteLine($"#{number}: {name}");
        }
    }

    
    static void AddStudent(BinarySearchTree tree) {
        while (true) {
            Console.WriteLine("Please input a 4-digit Student ID number (or write 'done' to finish):");
            // Check if input is empty
            string ID_input = Console.ReadLine() ?? string.Empty;
            if (string.IsNullOrWhiteSpace(ID_input)) {
                continue;
            }
            // Check if "done" entered
            if (ID_input.ToLower() == "done") {
                break;
            }
            
            // Convert ID string to int
            if (Int32.TryParse(ID_input, out int ID_value)) {
                // Check if ID value is in tree
                if (tree.Contains(ID_value)) {
                    Console.WriteLine("Invalid input (ID number already in use).");
                }
                else {
                    Console.WriteLine("Please enter the student's name:");
                    // Check if input is empty
                    string name_value = Console.ReadLine() ?? string.Empty;
                    if (string.IsNullOrWhiteSpace(name_value)) {
                        continue;
                    }
                    else {
                        // Insert ID and name pair to tree
                        tree.Insert(ID_value, name_value);
                    }
                }
            }
            // If ID string cannot convert
            else {
                Console.WriteLine("Invalid input (not an integer).");
            }
        }
    }
}
