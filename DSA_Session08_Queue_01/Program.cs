using System;
using System.Collections.Generic; // Bắt buộc khai báo để dùng Queue có sẵn
namespace DSA_Session08_Queue_01
{

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            // Khởi tạo hàng đợi chứa tên khách hàng
            Queue<string> callQueue = new Queue<string>();

            Console.WriteLine("=== HỆ THỐNG TỔNG ĐÀI CSKH ===");
            Console.WriteLine("- Nhập tên khách hàng để đưa vào hàng đợi.");
            Console.WriteLine("- Để trống và nhấn [ENTER] để nhân viên nhận cuộc gọi.");
            Console.WriteLine("- Nhập 'exit' để đóng hệ thống.\n");

            while (true)
            {
                Console.Write("Lệnh (Tên KH / [Enter] / exit): ");
                string input = Console.ReadLine();

                // 1. Thoát chương trình
                if (input.ToLower() == "exit")
                {
                    Console.WriteLine("Hệ thống đã tắt.");
                    break;
                }

                // 2. Nhấn Enter để Dequeue (Phục vụ khách)
                if (string.IsNullOrEmpty(input))
                {
                    if (callQueue.Count > 0)
                    {
                        string nextCustomer = callQueue.Dequeue();
                        Console.WriteLine(
                            $">>> Đang kết nối máy... Xin chào anh/chị: {nextCustomer}!");
                    }
                    else
                    {
                        Console.WriteLine(">>> Tổng đài đang rảnh, "+
                        "không có khách hàng nào chờ.");
                    }
                }
                // 3. Nhập tên để Enqueue (Khách vào hàng đợi)
                else
                {
                    callQueue.Enqueue(input);
                    Console.WriteLine("[+] Đã thêm khách hàng '{0}' vào hàng đợi."+ 
                    "(Đang chờ: {1})",input, callQueue.Count);
                }
            }
        }
    }
}