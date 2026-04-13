using System;

// Lớp đại diện cho 1 phần tử (Node)
public class DoubleNode {
    public int Data;
    public DoubleNode Prev;
    public DoubleNode Next;

    public DoubleNode(int data) {
        Data = data;
        Prev = null;
        Next = null;
    }
}

// Lớp quản lý Danh sách
public class DoubleLinkedList {
    public DoubleNode? Head;
    public DoubleNode? Tail;

    public DoubleLinkedList() {
        Head = null;
        Tail = null;
    }

    // Thêm phần tử vào cuối (Add Last)
    public void AddLast(int data) {
        DoubleNode newNode = new DoubleNode(data);
        
        if (Head == null) {
            Head = Tail = newNode;
            return;
        }

        Tail.Next = newNode; // Móc tail hiện tại với node mới
        newNode.Prev = Tail; // Móc node mới quay ngược lại tail cũ
        Tail = newNode;      // Cập nhật Tail là node mới
    }

    // Duyệt danh sách từ đầu đến cuối
    public void PrintForward() {
        DoubleNode current = Head;
        Console.Write("Tiến: null <-> ");
        while (current != null) {
            Console.Write($"{current.Data} <-> ");
            current = current.Next;
        }
        Console.WriteLine("null");
    }

    // Duyệt danh sách từ cuối về đầu (Ưu thế tuyệt đối của DLL)
    public void PrintBackward() {
        DoubleNode current = Tail;
        Console.Write("Lùi: null <-> ");
        while (current != null) {
            Console.Write($"{current.Data} <-> ");
            current = current.Prev;
        }
        Console.WriteLine("null");
    }
}

class Program {
    static void Main() {
        DoubleLinkedList list = new DoubleLinkedList();
        list.AddLast(10);
        list.AddLast(20);
        list.AddLast(30);

        list.PrintForward();
        list.PrintBackward();
    }
}