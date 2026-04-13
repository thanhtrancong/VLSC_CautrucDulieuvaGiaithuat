using System;
// Lớp đại diện cho 1 sinh viên
public class Student
{
    //mã sinh viên, tên sinh viên
    public string Id { get; set; }
    public string Name { get; set; }

    public Student(string id, string name) {
        Id = id;
        Name = name;
    }

    public override string ToString() {
        return $"Student(Id: {Id}, Name: {Name})";
    }
}
// Lớp đại diện cho 1 phần tử (Node)
public class DoubleNode {
    public Student student;
    public DoubleNode Prev;
    public DoubleNode Next;

    public DoubleNode(Student student) {
        this.student = student;
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
    public void AddLast(Student student) {
        DoubleNode newNode = new DoubleNode(student);
        
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
            Console.Write($"{current.student} <-> ");
            current = current.Next;
        }
        Console.WriteLine("null");
    }

    // Duyệt danh sách từ cuối về đầu (Ưu thế tuyệt đối của DLL)
    public void PrintBackward() {
        DoubleNode current = Tail;
        Console.Write("Lùi: null <-> ");
        while (current != null) {
            Console.Write($"{current.student} <-> ");
            current = current.Prev;
        }
        Console.WriteLine("null");
    }
}

class Program {
    static void Main() {
        DoubleLinkedList list = new DoubleLinkedList();
        list.AddLast(new Student("250011459", "Hải"));
        list.AddLast(new Student("250011460", "Hoàng"));
        list.AddLast(new Student("250011461", "Duy"));

        list.PrintForward();
        list.PrintBackward();
    }
}