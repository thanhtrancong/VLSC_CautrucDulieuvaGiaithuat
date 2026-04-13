using System;
// Lớp đại diện cho 1 sinh viên
public class Student
{
    //mã sinh viên, tên sinh viên
    public string Id { get; set; }
    public string Name { get; set; }

    public Student(string id, string name)
    {
        Id = id;
        Name = name;
    }
    public override string ToString()
    {
        return $"Student(Id: {Id}, Name: {Name})";
    }
}
// Lớp đại diện cho 1 phần tử (Node)
public class DoubleNode
{
    public Student student;
    public DoubleNode Prev;
    public DoubleNode Next;

    public DoubleNode(Student student)
    {
        this.student = student;
        Prev = null;
        Next = null;
    }
}

// Lớp quản lý Danh sách
public class DoubleLinkedList
{
    public DoubleNode? Head;
    public DoubleNode? Tail;

    public DoubleLinkedList()
    {
        Head = null;
        Tail = null;
    }

    // Thêm phần tử vào cuối (Add Last)
    public void AddLast(Student student)
    {
        DoubleNode newNode = new DoubleNode(student);

        if (Head == null)
        {
            Head = Tail = newNode;
            return;
        }

        Tail.Next = newNode; // Móc tail hiện tại với node mới
        newNode.Prev = Tail; // Móc node mới quay ngược lại tail cũ
        Tail = newNode;      // Cập nhật Tail là node mới
    }

    // Duyệt danh sách từ đầu đến cuối
    public void PrintForward()
    {
        DoubleNode current = Head;
        Console.Write("Tiến: null <-> ");
        while (current != null)
        {
            Console.Write($"{current.student} <-> ");
            current = current.Next;
        }
        Console.WriteLine("null");
    }

    // Duyệt danh sách từ cuối về đầu (Ưu thế tuyệt đối của DLL)
    public void PrintBackward()
    {
        DoubleNode current = Tail;
        Console.Write("Lùi: null <-> ");
        while (current != null)
        {
            Console.Write($"{current.student} <-> ");
            current = current.Prev;
        }
        Console.WriteLine("null");
    }
    //8.1.	Viết hàm AddFirst(Student student) để thêm phần tử vào đầu danh sách
    public void AddFirst(Student student)
    {
        DoubleNode newNode = new DoubleNode(student);

        if (Head == null)
        {
            Head = Tail = newNode;
            return;
        }

        newNode.Next = Head; // Móc node mới với head hiện tại
        Head.Prev = newNode; // Móc head hiện tại quay ngược lại node mới
        Head = newNode;      // Cập nhật Head là node mới
    }
    //8.2.	Viết hàm GetSize() để đếm xem danh sách hiện có bao nhiêu Node
    public int GetSize()
    {
        int count = 0;
        DoubleNode current = Head;
        while (current != null)
        {
            count++;
            current = current.Next;
        }
        return count;
    }
    //8.3.	Viết hàm RemoveNode(string studentId) tìm và xóa Node đầu tiên chứa mã sinh viên studentId. 
    // Nhớ cập nhật lại con trỏ Next của Node trước và Prev của Node sau.
    public void RemoveNode(string studentId)
    {
        DoubleNode current = Head;
        while (current != null)
        {
            if (current.student.Id == studentId)
            {
                // Nếu node cần xóa là head
                if (current == Head)
                {
                    Head = current.Next;
                    if (Head != null)
                        Head.Prev = null;
                }
                // Nếu node cần xóa là tail
                else if (current == Tail)
                {
                    Tail = current.Prev;
                    if (Tail != null)
                        Tail.Next = null;
                }
                // Nếu node cần xóa nằm giữa
                else
                {
                    current.Prev.Next = current.Next;
                    current.Next.Prev = current.Prev;
                }
                return; // Kết thúc sau khi xóa
            }
            current = current.Next;
        }
    }
    //8.4.	Viết hàm InsertAfterIndex(int index, Student student) để chèn sinh viên vào sau vị trí index thứ i.
    public void InsertAfterIndex(int index, Student student)
    {
        if (index < 0 || index >= GetSize())
        {
            Console.WriteLine("Vị trí chèn không hợp lệ.");
            return;
        }

        DoubleNode newNode = new DoubleNode(student);

        DoubleNode current = Head;
        if (current == null)
        {
            // Nếu danh sách rỗng, thêm node mới làm head và tail
            Head = Tail = newNode;
            return;
        }
        else
        {
            // Di chuyển đến vị trí index
            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }

            // Chèn node mới sau node tại vị trí index
            newNode.Next = current.Next;
            newNode.Prev = current;
            current.Next.Prev = newNode;
            current.Next = newNode;
        }
    }
    //8.5. Đảo ngược DLL (Reverse in place): 
    // Viết hàm chỉ sử dụng vòng lặp và đổi chỗ các con trỏ Next / Prev của từng Node để đảo ngược toàn bộ danh sách 
    // mà không tạo mảng hay danh sách mới.
    public void Reverse()
    {
        DoubleNode current = Head;
        DoubleNode temp = null;

        while (current != null)
        {
            // Đổi chỗ Next và Prev
            temp = current.Prev;
            current.Prev = current.Next;
            current.Next = temp;

            // Di chuyển đến node tiếp theo (trước khi đổi chỗ)
            current = current.Prev; // Vì đã đổi chỗ, Prev bây giờ là Next
        }

        // Sau khi hoàn thành, temp sẽ trỏ đến node cuối cùng đã được đảo ngược
        if (temp != null)
        {
            Head = temp.Prev; // Cập nhật Head mới
        }
    }
}

class Program
{
    static void Main()
    {
        // Tạo danh sách liên kết đôi và thêm một số sinh viên
        DoubleLinkedList list = new DoubleLinkedList();
        list.AddLast(new Student("250011459", "Hải"));
        list.AddLast(new Student("250011460", "Hoàng"));
        list.AddLast(new Student("250011461", "Duy"));
        // In danh sách từ đầu đến cuối
        list.PrintForward();
        // In danh sách từ cuối về đầu
        list.PrintBackward();
        // Thêm sinh viên vào đầu danh sách
        list.AddFirst(new Student("250011458", "An"));
        Console.WriteLine("\nSau khi thêm An vào đầu danh sách:");
        list.PrintForward();
        // Đếm số lượng sinh viên trong danh sách
        Console.WriteLine($"Số lượng sinh viên trong danh sách: {list.GetSize()}");
        // Đảo ngược danh sách
        list.Reverse();
        Console.WriteLine("\nSau khi đảo ngược danh sách:");
        list.PrintForward();
        // Xóa sinh viên có mã "250011460"
        list.RemoveNode("250011460");
        Console.WriteLine("\nSau khi xóa sinh viên có mã 250011460:");
        list.PrintForward();
        // Chèn sinh viên mới sau vị trí index 1
        list.InsertAfterIndex(1, new Student("250011462", "Lan"));
        Console.WriteLine("\nSau khi chèn Lan sau vị trí index 1:");
        list.PrintForward();    
    }

}