using System;
namespace DSA_Session07_SingleLinkedList
{

    // 1. ĐỊNH NGHĨA CLASS NODE: MỘT MẮT XÍCH TRONG DANH SÁCH
    public class Node
    {
        public int Data;    // Dữ liệu của mắt xích
        public Node Next;   // "Sợi dây" trỏ đến mắt xích tiếp theo

        // Constructor: Khởi tạo giá trị khi tạo Node mới
        public Node(int data)
        {
            Data = data;
            Next = null;    // Mặc định sinh ra chưa nối với ai cả
        }
    }
    // 2. ĐỊNH NGHĨA CLASS SINGLE LINKED LIST: DANH SÁCH LIÊN KẾT ĐƠN
    public class SingleLinkedList
    {
        private Node head;  // "Cái đầu" của danh sách, nơi bắt đầu
                            // Constructor: Khởi tạo danh sách rỗng
        public SingleLinkedList()
        {
            head = null;    // Ban đầu chưa có mắt xích nào
        }
        // 3. PHƯƠNG THỨC THÊM MẮT XÍCH VÀO CUỐI DANH SÁCH
        public void AddLast(int data)
        {
            Node newNode = new Node(data);  // Tạo mắt xích mới với dữ liệu
            if (head == null) //O(1)
            {
                head = newNode;  // Nếu danh sách rỗng, newNode trở thành head
                return;
            }
            Node current = head;  // Bắt đầu từ head
            while (current.Next != null) //O(n)
            {
                current = current.Next;  // Đi tiếp đến mắt xích cuối cùng
            }
            current.Next = newNode;  // Nối mắt xích cuối cùng với newNode
        }
        // 4. PHƯƠNG THỨC IN RA DANH SÁCH
        public void PrintList()
        {
            Node current = head;  // Bắt đầu từ head
            while (current != null) //O(n)
            {
                Console.Write(current.Data + " -> ");  // In dữ liệu của mắt xích
                current = current.Next;  // Đi tiếp đến mắt xích tiếp theo
            }
            Console.WriteLine("null");  // Kết thúc danh sách
        }
        // 8.1. Viết hàm đếm và trả về tổng số lượng Node đang có trong danh sách.
        public int CountNodes()
        {
            int count = 0; // Biến đếm số lượng Node
            Node current = head; // Bắt đầu từ head
            while (current != null) // Duyệt qua danh sách
            {
                count++; // Tăng biến đếm khi gặp một Node
                current = current.Next; // Đi tiếp đến Node tiếp theo
            }
            return count; // Trả về tổng số lượng Node
        }
        //8.2. Tìm xem một số target có tồn tại trong danh sách hay không. 
        // (Gợi ý: Trả về true hoặc false)
        public bool SearchNode(int target)
        {
            Node current = head; // Bắt đầu từ head
            while (current != null) // Duyệt qua danh sách
            {
                if (current.Data == target) // Nếu tìm thấy target
                {
                    return true; // Trả về true
                }
                current = current.Next; // Đi tiếp đến Node tiếp theo
            }
            return false; // Nếu không tìm thấy, trả về false
        }
        //8.3. Xóa phần tử ở đầu danh sách. (Gợi ý: Cực kỳ đơn giản, 
        // chỉ cần cho Head = Head.Next;). Kiểm tra kỹ trường hợp danh sách rỗng.
        public void DeleteFirst()
        {
            if (head != null)
            {
                head = head.Next;
            }
        }
        //8.4.Xóa Node ĐẦU TIÊN có Data bằng với giá trị value.
        public void DeleteByValue(int value)
        {
            if (head == null) // Nếu danh sách rỗng, không có gì để xóa
            {
                return;
            }
            if (head.Data == value) // Nếu Node đầu tiên có Data bằng value
            {
                head = head.Next; // Xóa Node đầu tiên bằng cách cập nhật head
                return;
            }
            Node current = head; // Bắt đầu từ head
            while (current.Next != null) // Duyệt qua danh sách
            {
                if (current.Next.Data == value) // Nếu tìm thấy Node tiếp theo có 
                // Data bằng value
                {
                    current.Next = current.Next.Next; // Bỏ qua Node đó để xóa nó
                    return;
                }
                current = current.Next; // Đi tiếp đến Node tiếp theo
            }
        }
        //8.5.Đảo ngược toàn bộ Danh sách liên kết mà KHÔNG được sử dụng thêm mảng phụ để lưu trữ.
        public void ReverseList()
        {
            Node prev = null; // Node trước đó, ban đầu là null
            Node current = head; // Node hiện tại, bắt đầu từ head
            while (current != null) // Duyệt qua danh sách
            {
                Node next = current.Next; // Lưu trữ Node tiếp theo
                current!.Next = prev; // Đảo ngược liên kết của Node hiện tại
                prev = current; // Cập nhật prev thành Node hiện tại
                current = next; // Di chuyển đến Node tiếp theo
            }
            head = prev; // Cập nhật head thành Node cuối cùng sau khi đảo ngược
        }
    }
    // 5. CHƯƠNG TRÌNH CHÍNH: TEST DANH SÁCH LIÊN KẾT ĐƠN
    class Program
    {
        static void Main(string[] args)
        {
            // Tạo một instance của SingleLinkedList để quản lý danh sách
            SingleLinkedList list = new SingleLinkedList();
            Console.WriteLine("Chào mừng đến với danh sách liên kết đơn!");
            //tạo menu để người dùng chọn thao tác
            while (true)
            {
                Console.WriteLine("Vui lòng chọn thao tác:");
                Console.WriteLine("1. Thêm mắt xích vào cuối danh sách");
                Console.WriteLine("2. In ra danh sách");
                Console.WriteLine("3. Xoá danh sách");
                Console.WriteLine("4. Đảo ngược danh sách");
                Console.WriteLine("5. Đếm số lượng Node trong danh sách");
                Console.WriteLine("6. Tìm kiếm một giá trị trong danh sách");
                Console.WriteLine("7. Xoá Node đầu tiên");
                Console.WriteLine("8. Xoá Node có giá trị cụ thể");
                Console.WriteLine("9. Thoát");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":// Thêm mắt xích vào cuối danh sách
                        Console.Write("Nhập dữ liệu cho mắt xích mới: ");
                        int data = int.Parse(Console.ReadLine());
                        list.AddLast(data);
                        break;
                    case "2":// In ra danh sách hiện tại
                        list.PrintList();
                        break;
                    case "3":// Xoá danh sách bằng cách tạo một instance mới, 
                             // "đánh rơi" instance cũ
                        list = new SingleLinkedList();
                        Console.WriteLine("Danh sách đã được xoá.");
                        break;
                    case "4":// Đảo ngược danh sách
                        list.ReverseList();
                        Console.WriteLine("Danh sách đã được đảo ngược.");
                        list.PrintList(); // In ra danh sách sau khi đảo ngược
                        break;
                    case "5":// Đếm số lượng Node trong danh sách
                        int count = list.CountNodes();
                        Console.WriteLine($"Số lượng Node trong danh sách: {count}");
                        break;
                    case "6":// Tìm kiếm một giá trị trong danh sách
                        Console.Write("Nhập giá trị cần tìm: ");
                        int searchData = int.Parse(Console.ReadLine());
                        bool foundNode = list.SearchNode(searchData);
                        if (foundNode)
                            Console.WriteLine($"Giá trị {searchData} được tìm thấy trong danh sách.");
                        else
                            Console.WriteLine($"Giá trị {searchData} không tồn tại trong danh sách.");
                        break;
                    case "7":// Xoá Node đầu tiên
                        list.DeleteFirst();
                        Console.WriteLine("Node đầu tiên đã được xoá.");
                        break;
                    case "8":// Xoá Node có giá trị cụ thể
                        Console.Write("Nhập giá trị cần xoá: ");
                        int deleteData = int.Parse(Console.ReadLine());
                        list.DeleteByValue(deleteData);
                        Console.WriteLine($"Node có giá trị {deleteData} đã được xoá.");
                        break;
                    case "9":// Thoát khỏi chương trình
                        return;// Kết thúc hàm Main, thoát chương trình
                    default: // Nếu người dùng nhập lựa chọn không hợp lệ
                        Console.WriteLine("Lựa chọn không hợp lệ!");
                        break;
                }
            }
        }
    }
}