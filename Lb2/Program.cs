public class Node {
    public int Value { get; set; }
    public Node Next { get; set; }
            
    public Node(int value) : this(value, null) { }
    
    public Node(int value, Node next) {
        Value = value;
        Next = next;
    }
}

public class NodeList {
    public Node Head { get; set; }
    
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
        Node node = Head.Next;
        while(node.Next != null) {
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
        Node node = Head.Next;
        while(node.Next != null) {
            if(node.Next.Value % 2 == 0)
                node.Next = node.Next.Next;
            else
                node = node.Next;
        }
    }
    
    public void Sort() { // Bubble sort, descending order
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
}

/*
+. (1) Конструктор з одним параметром (число);
+. (2) Конструктор з двома параметрами (число, посилання на наступний елемент);
+. (4) Метод додавання нового елементу першим у список;
+. (5) Не рекурсивний метод додавання нового елемента останнім у список;
+. (19) Не рекурсивний метод видалення всіх елементів із заданим значенням;
+. (24) Метод видалення всіх парних за значенням елементів;
+. (26) Не рекурсивний метод друку елементів списку у прямому порядку у рядок;
+. (38) Метод сортування елементів списку за зменшенням числових значень;
+. (48) Властивість Length - довжина списку (при зчитуванні - повернути довжину списку, при записі - встановити довжину списку, додавши елементи зі значенням 0 або відсікаючи зайві елементи);
+. (63) Перевизначити для списку операцію +
-. (79) Перевизначити для списку будь-яку операцію
 */

public class Program {
    public static void Main(string[] args) {
        NodeList list = new NodeList();
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
        
        Console.WriteLine(list.toString()); // 1 1 1 1 15 5 58 1 2 3 1 4 5 1 1 6 1
        list.RemoveAllWithValue(1);
        Console.WriteLine(list.toString()); // 15 5 58 2 3 4 5 6
        list.RemoveAllWithPairValue();
        Console.WriteLine(list.toString()); // 15 5 3 5
        list.AddFirst(2);
        list.AddFirst(2);
        list.AddFirst(2);
        list.AddFirst(2);
        list.RemoveAllWithPairValue();
        Console.WriteLine(list.toString()); // 15 5 3 5
        list.Sort();
        Console.WriteLine(list.toString()); // 15 5 5 3
        list.AddFirst(1);
        list.Sort();
        Console.WriteLine(list.toString()); // 15 5 5 3 1
        Console.WriteLine(list.Length);
        list.Length = 10;
        Console.WriteLine(list.toString()); // 15 5 5 3 1 0 0 0 0 0
        list.Length = 4;
        Console.WriteLine(list.toString()); // 15 5 5 3
        
        NodeList list2 = new NodeList();
        list2.AddLast(10);
        list2.AddLast(45);
        list2.AddLast(24);
        list2.AddLast(1);
        list2.AddLast(3);
        list2.AddLast(55);
        list2.AddLast(64);
        
        list += list2;
        
        Console.WriteLine(list.toString()); // 15 5 5 3 10 45 24 1 3 55 64
        
        list++;
        Console.WriteLine(list.toString()); // 16 6 6 4 11 46 25 2 4 56 65
        
        list += 10;
        Console.WriteLine(list.toString()); // 26 16 16 14 21 56 35 12 14 66 75
    }
}
