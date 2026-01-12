using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Adding a value of 100 with a priority of 5, 42 with a priority of 1, 3 with a priority of 10, and a value of 50 with a priority of 1.
    // Expected Result: 3, 100, 42, 50
    // Defect(s) Found: 
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("100", 5);
        priorityQueue.Enqueue("42", 1);
        priorityQueue.Enqueue("3", 10);
        priorityQueue.Enqueue("50", 1);
        Assert.AreEqual("3", priorityQueue.Dequeue());
        Assert.AreEqual("100", priorityQueue.Dequeue());
        Assert.AreEqual("42", priorityQueue.Dequeue());
        Assert.AreEqual("50", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Adding a Value of Mr. Jenkins with a priority of 10, Ms. Smith with a priotiy of 4, Johnny Law with a priority of 2, Curtis Max with a Priority of 2 
    // Dr. Brown with a Priority of 8, Sir Homstead with a priority of 9, and Lady Grey with a priority of 7, and Spencer Smith with a priority of 2.
    // Expected Result: Mr. Jenkins, Sir Homstead, Dr. Brown, Lady Grey, Ms. Smith, Johnny Law, Curtis Max, Spencer Smith
    // Defect(s) Found: 
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Mr. Jenkins", 10);
        priorityQueue.Enqueue("Ms. Smith", 4);
        priorityQueue.Enqueue("Johnny Law", 2);
        priorityQueue.Enqueue("Curtis Max", 2);
        priorityQueue.Enqueue("Dr. Brown", 8);
        priorityQueue.Enqueue("Sir Homstead", 9);
        priorityQueue.Enqueue("Lady Grey", 7);
        priorityQueue.Enqueue("Spencer Smith", 2);
        
        Assert.AreEqual("Mr. Jenkins", priorityQueue.Dequeue());
        Assert.AreEqual("Sir Homstead", priorityQueue.Dequeue());
        Assert.AreEqual("Dr. Brown", priorityQueue.Dequeue());
        Assert.AreEqual("Lady Grey", priorityQueue.Dequeue());
        Assert.AreEqual("Ms. Smith", priorityQueue.Dequeue());
        Assert.AreEqual("Johnny Law", priorityQueue.Dequeue());
        Assert.AreEqual("Curtis Max", priorityQueue.Dequeue());
        Assert.AreEqual("Spencer Smith", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Empty Queue
    // Expected Result: InvalidOperationException
    // Defect(s) Found: 
    public void TestPriorityQueue_3()
    {
        var priorityQueue = new PriorityQueue();
        Assert.ThrowsException<InvalidOperationException>(() => priorityQueue.Dequeue());
    }
}