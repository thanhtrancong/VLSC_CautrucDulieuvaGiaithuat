using System;
namespace DSA_Session08_Queue
{
    // Tạo một class quản lý hàng đợi riêng biệt
    public class MyQueue
    {
        private int[] elements; // Mảng chứa dữ liệu
        private int front;      // Con trỏ đầu hàng
        private int rear;       // Con trỏ cuối hàng
        private int max;        // Kích thước tối đa

        // Constructor khởi tạo
        public MyQueue(int size)
        {
            elements = new int[size];
            front = -1;
            rear = -1;
            max = size;
        }

        // Hàm thêm phần tử vào hàng đợi
        public void Enqueue(int item)
        {
            if (rear == max - 1)
            {
                Console.WriteLine("LỖI: Hàng đợi đã đầy (Overflow)!");
                return;
            }

            // Nếu là phần tử đầu tiên được thêm vào
            if (front == -1)
            {
                front = 0;
            }

            rear++; // Tăng con trỏ cuối lên
            elements[rear] = item; // Nạp dữ liệu
            Console.WriteLine($"Đã thêm [{item}] vào hàng đợi.");
        }

        // Hàm lấy phần tử ra khỏi hàng đợi
        public int Dequeue()
        {
            if (front == -1 || front > rear)
            {
                Console.WriteLine("LỖI: Hàng đợi trống (Underflow)!");
                return -1;
            }

            int item = elements[front]; // Lấy giá trị ở đầu hàng
            front++; // Đẩy con trỏ đầu hàng lùi ra sau

            // Tối ưu: Nếu lấy hết phần tử, reset lại hàng đợi
            if (front > rear)
            {
                front = -1;
                rear = -1;
            }

            return item;
        }

        // Xem người đầu tiên mà không xóa
        public void Peek()
        {
            if (front == -1 || front > rear)
            {
                Console.WriteLine("Hàng đợi trống rỗng.");
            }
            else
            {
                Console.WriteLine($"Phần tử đầu hàng hiện tại là: {elements[front]}");
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("=== CHƯƠNG TRÌNH MÔ PHỎNG HÀNG ĐỢI ===");

            MyQueue queue = new MyQueue(3); // Tạo queue chứa tối đa 3 người

            queue.Enqueue(10);
            queue.Enqueue(20);
            queue.Enqueue(30);

            queue.Enqueue(40); // Sẽ báo lỗi Overflow vì max = 3

            queue.Peek(); // Xem đầu hàng: Kết quả là 10

            Console.WriteLine($"Đã lấy ra: {queue.Dequeue()}"); // Lấy 10 ra
            Console.WriteLine($"Đã lấy ra: {queue.Dequeue()}"); // Lấy 20 ra

            queue.Peek(); // Xem đầu hàng: Giờ là 30
        }
    }
}
