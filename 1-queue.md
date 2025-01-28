# Queues

Queues are a type of Data Structure allowing for storing and recalling variables in linear order, from front to back, where items are added (enqueued) at the back and returned (dequeued) from the front. Queues can be created using data types such as Lists and Arrays. In a sense, Queues can be described as a special kind of list that adds and returns objects in a specific order.

## Stacks vs Queues

Queues have several similarities to another data structure, Stacks, both of them being data structures that recieve multiple inputs and output them in order. The main difference between the two, however, is what that order is.

Stacks will recieve items, and when it comes time to output, will return the last item in the list first. For example, think of a stack of pancakes. If someone was to remove a pancake from the stack, they would most easily take the pancake on the top of the stack--the one added the most recently. This is known as "Last In, First Out", or LIFO.

Queues, conversely, will return the first item in the list first when outputting. This is most comparable to people waiting in a line--the first person in line is the first person able to go and do whatever they've been waiting in line for. This is known as "First In, First Out", or FIFO.

## Making Queues in C#

Queues have their own C# data type, the ```Queue<>``` class, that can be imported to a program using the following code:

```csharp
using System;
using System.Collections.Generic;
```

The ```Queue<>``` class contains several built-in functions and properties to help add to, return from, or check the length of the queue created, among other things.

Adding an object to a queue is known as Enqueueing the object. The object is added as a variable of the specified type to the back of the queue, moving up in line as earlier objects are returned. With the Queue class, this is done with the function ```Enqueue(value)```.

Removing an object from a queue is known as Dequeueing the object. The object is removed from the front of the queue, and returns as a variable of the specified type. With the Queue class, this is done with the function ```Dequeue()```.

Checking the length of a Queue can be useful for interating through the Queue, checking if the Queue is empty, or simply keeping track of how many objects are in the Queue at any one point in time. With the Queue class, this is done through the property ```Count```.

```csharp
Queue<int> numbers = new Queue<int>();

for(int i = 1; i <= 10; i++) {
    numbers.Enqueue(i);
}

int size = numbers.Count;

for(int n = 0; n < size; n++) {
    value = numbers.Dequeue();
    Console.WriteLine($"Leaving Queue: {value}");
}
```

### Making Queues using Lists in C#

It's also possible to create a Queue class from scratch using the ```List<>``` or ```Array<>``` data types. Using properties and functions, the functionality of the ```Queue<>``` class can be recreated, as the following example using ```List<>``` shows:

```csharp
public class NumberQueue {
    private readonly List<int> _queue = new();

    public int Length => _queue.Count();

    public void Enqueue(int i) {
        _queue.Insert(Length, i);
    }

    public int Dequeue() {
        var i = _queue[0];
        _queue.RemoveAt(0);
        return i;
    }

    public int Peek() {
        var i = _queue[0];
        return i;
    }

    public bool IsEmpty() {
        return Length == 0;
    }

    public int Size() {
        return Length;
    }    
}
```

### Efficiency of common operations

Using the ```Queue<>``` class, the efficiency of Enqueueing and Dequeueing objects is O(1), while when making the class yourself, the efficiency of Enqueueing and Dequeueing objects is O(n), taking longer for the program to run.

|    Operation    |                    Description                    | C# Example (using Queue<> Class) | Performance (using Queue<> Class) | Performance (using List<> Class) |
|-----------------|---------------------------------------------------|----------------------------------|-----------------------------------|----------------------------------|
| enqueue(value)  | Adds value to end of queue                        | myQueue.Enqueue(value)           | O(1)                              | O(n)                             |
| dequeue()       | Removes and returns from start of queue           | var value = myQueue.Dequeue()    | O(1)                              | O(n)                             |
| peek()          | Returns (but doesn't remove) from start of queue  | var value = myQueue.Peek()       | O(1)                              | O(n)                             |
| size()          | Returns length of queue                           | myQueue.Count                    | O(1)                              | O(1)                             |
| empty()         | Returns true if length is zero                    | if (myQueue.Count == 0)          | O(1)                              | O(1)                             |

It's more efficient for a program to import the ```Queue<>``` class instead of creating one from scratch. However, there are cases in which one might need to add other functions to the Queue, or multiple different kinds of Queues building off of each other, such as needing to implement a Priority Queue. In those sorts of cases, it would be more useful to create the class or classes from scratch.

## Example Problem: Customer Service Queue

In the following example, a customer service desk is simulated using Queues, with customers waiting in line to be served. While each customer is processed and leaves the queue, the program also asks if the user would like to add an additional customer to the queue.

The requirements of our example problem are as follows:
* Names can be successfully added to the queue
* Each customer's name is displayed in order as they exit the queue
* New names can be successfully added mid-program as the queue is running

The example problem can be found here: [Example](ds1-example)

## Problem to Solve: Supermarket Checkout Queue

Complete the following program, simulating a Supermarket check-out line using Queues. There are three regular Queues, and customers are assigned one-by-one to whichever of these Queues is the shortest. There is also a VIP Queue, which is a Priority Queue, and VIP customers are served before any regular customers.

The program is incomplete, and requires the completion of most functions. There are "TODO" comments explaining what needs to be completed where throughout the program. You should not have to create any new functions for this problem.

The program file to be completed can be found here: [Problem](ds1-problem)

Once you've finished, you may double-check against the solution here: [Solution](ds1-solution)

[Go Back to the Welcome Page](0-welcome.md)
