/*
  MIT License

  Copyright (c) 2023-present RuslanUC
  
  Permission is hereby granted, free of charge, to any person obtaining a copy
  of this software and associated documentation files (the "Software"), to deal
  in the Software without restriction, including without limitation the rights
  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
  copies of the Software, and to permit persons to whom the Software is
  furnished to do so, subject to the following conditions:
  
  The above copyright notice and this permission notice shall be included in all
  copies or substantial portions of the Software.
  
  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
  SOFTWARE.
*/

using System.Diagnostics.CodeAnalysis;

namespace Lb2 {

public class Node {
    public int Value { get; set; }
    public Node Next { get; set; }
            
    public Node(int value) : this(value, null) { }
    
    public Node(int value, Node next) {
        Value = value;
        Next = next;
    }
    
    public string ToString(bool withNext=true) {
        string next = Next != null ? (withNext ? Next.ToString() : "...") : "null";
        return $"Node(Value={Value}, Next={next})";
    }

    public override string ToString() {
        string next = Next != null ? Next.ToString(false) : "null";
        return $"Node(Value={Value}, Next={next})";
    }
}

public class NodeList {
    public Node Head { get; set; } = null;
    
    public void AddFirst(int value) {
        Node newNode = new Node(value);
        if(Head != null) {
            newNode.Next = Head;
        }
        Head = newNode;
    }
    
    public void AddLast(int value) {
        Node new_node = new Node(value);
        if(Head == null) {
            Head = new_node;
        } else {
            Node last = Head;
            while(last.Next != null) {
                last = last.Next;
            }
            last.Next = new_node;
        }
    }

    public string toString() {
        if(Head == null)
            return "";
        string result = "";
        Node node = Head;
        while(node != null) {
            result += $"{node.Value} ";
            node = node.Next;
        }
        return result.Trim();
    }
    
    public void RemoveAllWithValue(int value) {
        if(Head == null)
            return;
        while (Head != null && Head.Value == value)
            Head = Head.Next;
        if(Head == null) return;
        Node node = Head;
        while(node != null && node.Next != null) {
            if(node.Next.Value == value)
                node.Next = node.Next.Next;
            else
                node = node.Next;
        }
    }
    
    public void RemoveAllWithPairValue() {
        if(Head == null)
            return;
        while (Head != null && Head.Value % 2 == 0)
            Head = Head.Next;
        if(Head == null) return;
        Node node = Head;
        while(node != null && node.Next != null) {
            if(node.Next.Value % 2 == 0)
                node.Next = node.Next.Next;
            else
                node = node.Next;
        }
    }

    public void Sort() { // Bubble sort, descending order
        if(Head == null) return;
        bool sorting = true;
        Node head = Head;
        while(sorting) {
            sorting = false;
            Node a = head;
            Node b = head.Next;
            while(a != null && b != null) {
                if(a.Value < b.Value) {
                    (a.Value, b.Value) = (b.Value, a.Value);
                    sorting = true;
                }
                (a, b) = (b, b.Next);
            }
        }
    }
    
    public void SortNodes() {
        int count = 0;
        Node start = Head, node, prev, temp;
        while(start != null) {
            count++;
            start = start.Next;
        }
        
        for(int i = 0; i < count; ++i) {
            node = prev = Head;
            while(node != null && node.Next != null) {
                if(node.Value < node.Next.Value) {
                    temp = node.Next;
                    (node.Next, node.Next.Next) = (node.Next.Next, node);
                    if(node == Head) {
                        Head = temp;
                    } else {
                        prev.Next = temp;
                    }
                }
                prev = node;
                node = node.Next;
            }
        }
    }
    
    public int Length {
        get {
            int l = 0;
            Node node = Head;
            while(node != null) {
                l++;
                node = node.Next;
            }
            return l;
        }
        set {
            Node node = Head;
            value--;
            while(value > 0) {
                if(node.Next == null)
                    node.Next = new Node(0);
                node = node.Next;
                value--;
            }
            node.Next = null;
        }
    }
    
    public static NodeList operator +(NodeList a, NodeList b) {
        Node node = b.Head;
        while(node != null) {
            a.AddLast(node.Value);
            node = node.Next;
        }
        return a;
    }

    public static NodeList operator +(NodeList a, int b) {
        Node node = a.Head;
        while(node != null) {
            node.Value += b;
            node = node.Next;
        }
        return a;
    }
    
    public static NodeList operator ++(NodeList a) {
        Node node = a.Head;
        while(node != null) {
            node.Value++;
            node = node.Next;
        }
        return a;
    }
    
    public int this[int value] {
        get {
            Node? node = Head;
            int result = 0;
            while(node != null) {
                if(node.Value == value)
                    return result;
                result++;
                node = node.Next;
            }
            return -1;
        }
    }
    
    public Node? GetByIndex(int index) {
        if(index < 0) return null;
        
        Node? node = Head;
        for(int i = 0; i < index; i++) {
            if(node == null) return null;
            node = node.Next;
        }
        return node;
    }
}

/*
+ (1) Конструктор з одним параметром (число);
+ (2) Конструктор з двома параметрами (число, посилання на наступний елемент);
+ (4) Метод додавання нового елементу першим у список;
+ (5) Не рекурсивний метод додавання нового елемента останнім у список;
+ (19) Не рекурсивний метод видалення всіх елементів із заданим значенням;
+ (24) Метод видалення всіх парних за значенням елементів;
+ (26) Не рекурсивний метод друку елементів списку у прямому порядку у рядок;
+ (38) Метод сортування елементів списку за зменшенням числових значень;
+ (48) Властивість Length - довжина списку (при зчитуванні - повернути довжину списку, при записі - встановити довжину списку, додавши елементи зі значенням 0 або відсікаючи зайві елементи);
+ (63) Перевизначити для списку операцію +
+ (79) Перевизначити для списку будь-яку операцію

- (д-59) Індексатор з одним параметром, який дозволяє за значенням елемента знайти його порядковий номер у списку;
 */

[ExcludeFromCodeCoverage]
public class Program {
    public static void Main(string[] args) {
        NodeList list = new NodeList();
        list.AddLast(59);
        list.AddLast(56);
        list.AddLast(58);
        list.AddLast(98);
        list.AddLast(12);

        list.AddLast(4);
        list.AddLast(5);
        list.AddLast(-11);
        list.AddLast(1);
        list.AddLast(1);
        list.AddLast(6);
        list.AddLast(1);
        list.AddFirst(1);
        list.AddFirst(1);
        list.AddFirst(1);
        list.AddFirst(1);
        list.AddFirst(-50);
        list.AddLast(999);
        
        Console.WriteLine($"Список: {list.toString()}");
        
        int idx = list[-50];
        Console.WriteLine($"Індекс елемента -50: {idx}, Перевірка: {list.GetByIndex(idx)}");
        
        idx = list[1];
        Console.WriteLine($"Індекс елемента 1: {idx}, Перевірка: {list.GetByIndex(idx)}");
        
        idx = list[59];
        Console.WriteLine($"Індекс елемента 59: {idx}, Перевірка: {list.GetByIndex(idx)}");
        
        idx = list[6];
        Console.WriteLine($"Індекс елемента 6: {idx}, Перевірка: {list.GetByIndex(idx)}");
        
        idx = list[999];
        Console.WriteLine($"Індекс елемента 999: {idx}, Перевірка: {list.GetByIndex(idx)}");
        
        idx = list[1000];
        Console.WriteLine($"Індекс елемента 100 (немає в списку): {idx}, Перевірка: {list.GetByIndex(idx)}");
    }
}
}