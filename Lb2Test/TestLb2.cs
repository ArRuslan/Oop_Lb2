using NUnit.Framework;
using Lb2;

namespace Lb2Test;

public class Tests {
    NodeList list;
    
    [SetUp]
    public void Setup() {
        list = new NodeList();
        list.AddFirst(5);
        list.AddFirst(15);
        list.AddLast(58);
        list.AddLast(1);
        list.AddLast(2);
        list.AddLast(3);
        list.AddLast(1);
        list.AddLast(4);
        list.AddLast(5);
        list.AddLast(1);
        list.AddLast(1);
        list.AddLast(6);
        list.AddLast(1);
        list.AddFirst(1);
        list.AddFirst(1);
        list.AddFirst(1);
        list.AddFirst(1);
    }

    [Test]
    public void Test_toString() {
        Assert.AreEqual("1 1 1 1 15 5 58 1 2 3 1 4 5 1 1 6 1", list.toString());
        
        NodeList list2 = new NodeList();
        Assert.AreEqual("", list2.toString());
    }

    [Test]
    public void Test_removeOnes() {
        list.RemoveAllWithValue(1);
        Assert.AreEqual("15 5 58 2 3 4 5 6", list.toString());
        
        NodeList list2 = new NodeList();
        list2.RemoveAllWithValue(1);
        Assert.AreEqual("", list2.toString());
    }

    [Test]
    public void Test_removePairs() {
        list.RemoveAllWithPairValue();
        Assert.AreEqual("1 1 1 1 15 5 1 3 1 5 1 1 1", list.toString());
        list.AddFirst(2);
        list.AddFirst(2);
        list.AddFirst(2);
        list.AddFirst(2);
        list.RemoveAllWithPairValue();
        Assert.AreEqual("1 1 1 1 15 5 1 3 1 5 1 1 1", list.toString());
        
        NodeList list2 = new NodeList();
        list2.RemoveAllWithPairValue();
        Assert.AreEqual("", list2.toString());
    }
    
    [Test]
    public void Test_sortDesc() {
        list.Sort();
        Assert.AreEqual("58 15 6 5 5 4 3 2 1 1 1 1 1 1 1 1 1", list.toString());
        
        NodeList list2 = new NodeList();
        list2.Sort();
        Assert.AreEqual("", list2.toString());
    }

    [Test]
    public void Test_sortNodesDesc() {
        list.SortNodes();
        Assert.AreEqual("58 15 6 5 5 4 3 2 1 1 1 1 1 1 1 1 1", list.toString());
        
        NodeList list2 = new NodeList();
        list2.SortNodes();
        Assert.AreEqual("", list2.toString());
    }

    [Test]
    public void Test_length() {
        Assert.AreEqual(17, list.Length);
        list.Length = 10;
        Assert.AreEqual(10, list.Length);
        Assert.AreEqual("1 1 1 1 15 5 58 1 2 3", list.toString());
        list.Length = 20;
        Assert.AreEqual(20, list.Length);
        Assert.AreEqual("1 1 1 1 15 5 58 1 2 3 0 0 0 0 0 0 0 0 0 0", list.toString());
        list.Length = 5;
        Assert.AreEqual(5, list.Length);
        Assert.AreEqual("1 1 1 1 15", list.toString());
        
        NodeList list2 = new NodeList();
        Assert.AreEqual(0, list2.Length);
    }

    [Test]
    public void Test_listPlusList() {
        NodeList list2 = new NodeList();
        list2.AddLast(10);
        list2.AddLast(45);
        list2.AddLast(24);
        list2.AddLast(1);
        list2.AddLast(3);
        list2.AddLast(55);
        list2.AddLast(64);
        list += list2;
        Assert.AreEqual(24, list.Length);
        Assert.AreEqual("1 1 1 1 15 5 58 1 2 3 1 4 5 1 1 6 1 10 45 24 1 3 55 64", list.toString());
        
        NodeList list3 = new NodeList();
        list3 += list2;
        Assert.AreEqual("10 45 24 1 3 55 64", list3.toString());
    }

    [Test]
    public void Test_listPlusInt() {
        list += 10;
        Assert.AreEqual(17, list.Length);
        Assert.AreEqual("11 11 11 11 25 15 68 11 12 13 11 14 15 11 11 16 11", list.toString());
        
        NodeList list2 = new NodeList();
        list2 += 10;
        Assert.AreEqual("", list2.toString());
    }

    [Test]
    public void Test_listIncrement() {
        list++;
        Assert.AreEqual("2 2 2 2 16 6 59 2 3 4 2 5 6 2 2 7 2", list.toString());
        
        NodeList list2 = new NodeList();
        list2++;
        Assert.AreEqual("", list2.toString());
    }
}