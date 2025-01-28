# Linked Lists

There are two main types of arrays in programming: Fixed Arrays, and Dynamic Arrays. A fixed array is a collection of data in which the overall size of the array cannot be altered, only containing a fixed number of items. A dynamic array is similar, but unlike a fixed array, it can be changed in size through adding additional data, allowing for more items to be included than there was initially space for.

Linked Lists are a type of dynamic array in which the different data points in the collection are connected together through pointers that leads to the next element.

## Nodes & Linked List Structure

Items in a linked list are referred to as "Nodes", containing both the data of the item and the pointer linking to the next node. The first node in a list is referred to as a Head Node.

Nodes will also often contain a pointer to the previous item in the list, making it a doubly-linked list. When a list is linked bidirectionally like this, the final node in the list will be referred to as a Tail Node.

## Making Linked Lists in C#

Just like Queues, Linked Lists have their own C# data type, the ```LinkedList<>``` class, that can be imported to a program using the following code:

```csharp
using System;
using System.Collections.Generic;
```

Also like Queues, the ```LinkedList<>``` class has built-in properties and functions to assist with adding to, removing from, and checking the properties of the list. The Linked List created by this class is automatically doubly linked, containing both a Head Node and a Tail Node.

The Nodes formed in the list when using the ```LinkedList``` class are types as ```LinkedListNode<>```. Creating a new Node to add to the list can be done using the constructor ```LinkedListNode<>(value)```, making sure to specify the value's type.

```csharp
LinkedListNode<string> node = new LinkedListNode<string>("New Node");
```

Objects can be added to the front of the list, to the end of the list, or before or after a specific node in the list. Adding to the front or back of the list adds the new Node before the Head or after the Tail, making the new Node the new Head or the new Tail respectively. Adding somewhere in the middle of the list requires the program to loop through the list to the correct node. These functions are called using ```AddFirst(value)```, ```AddLast(value)```, ```AddBefore(node, value)```, and ```AddAfter(node, value)```.

Objects can likewise be removed from the front of the list, from the end of the list, or a specific node can be removed in the list. Removing from the front or back of the lis removed the Head or Tail Node. Removing a specific Node from the middle of the list, just like when adding a new Node to the middle, requires the program to loop through the list to the correct node. These functions are called using ```RemoveFirst()```, ```RemoveLast()```, and ```Remove(node)```.

There are also properties that return values for the size of the Linked list, the first Node, and the last Node. These properties are called using ```Count```, ```First```, and ```Last```.

Nodes have the additional properties ```Next``` and ```Last```, which call up the pointers to the next node and the previous node respecitvely.

```csharp
LinkedList<int> numbers = new LinkedList<int>();

for(int i = 1; i <= 10; i++) {
    numbers.AddLast(i);
}

foreach (LinkedListNode<int> number in numbers) {
    value = number.Value;
    Console.WriteLine($"Value: {value}");
}

Console.WriteLine($"Total List Size: {numbers.Count}");
```

### Altering the Contents of a Linked List

There isn't any built-in function allowing you to replace a specific Node in a Linked List with a different one, but it's not too difficult to create one from scratch using the other functions.

```csharp
public LinkedList Replace(LinkedList<type> list, LinkedListNode<type> oldNode, LinkedListNode<type> newNode) {
	list.AddBefore(oldNode, newNode); // Alternatively, you can use list.AddAfter(oldNode, newNode)
    list.Remove(oldNode);
    return list;
}
```

By adding the new Node and removing the old Node, it has the same result you would get if it was possible to simply edit the value of the Node directly.

### Efficiency of common operations

The efficiency of adding to or removing from a ```LinkedList<>``` varies depending on which function is being used. Simply adding or removiing a Head Node or Tail Node is more efficient than adding or removing a Node in the middle of the list.

|      Operation      |           Description           |                          C# Example                          | Performance |
|---------------------|---------------------------------|--------------------------------------------------------------|-------------|
| InsertHead(value)   | Adds value before head          | myList.AddFirst(value)                                       | O(1)        |
| InsertTail(value)   | Adds value after tail           | myList.AddLast(value)                                        | O(1)        |
| Insert(node, value) | Adds value before or after node | myList.AddBefore(node, value) / myList.AddAfter(node, value) | O(n)        |
| RemoveHead()        | Removes head value              | myList.RemoveFirst()                                         | O(1)        |
| RemoveTail()        | Removes tail value              | myList.RemoveLast()                                          | O(1)        |
| Remove(node)        | Removes specified node          | myList.Remove(node)                                          | O(n)        |
| Size()              | Returns length of list          | myList.Count                                                 | O(1)        |
| Empty()             | Returns true if length is zero  | myList.Count == 0                                            | O(1)        |

The reason that adding or removing a value somewhere in the middle of the list is less efficient than adding or removing the head or tail is because, to find where the new Node needs to be added or the old Node needs to be removed, it requires looping through the list.

## Example Problem: Train Schedule List

In the following example, a train's schedule and what stops it has is simulated using Linked Lists, with each Node representing one of the stops on the schedule. The program demonstrates adding stops and removing stops, as well as showing how the schedule updates after doing so.

The requirements of our example problem are as follows:
* Stops can be successfully added to the queue
* Stops can be successfully removed from the queue by name
* The schedule prints correctly and reflects changes to the list

The example problem can be found here: [Example](ds2-example)

## Problem to Solve: Music Playlist List

Complete the following program, simulating a Smusic playlist line using Linked Lists. There are functions for adding and removing songs to and from the playlist, as well as functions for going forwards and backwards through the playlist to each song.

The program is incomplete, and requires the completion of several functions. There are "TODO" comments explaining what needs to be completed where throughout the program. You should not have to create any new functions for this problem.

The program file to be completed can be found here: [Problem](ds2-problem)

Once you've finished, you may double-check against the solution here: [Solution](ds2-solution)

[Back to Welcome Page](0-welcome.md)
