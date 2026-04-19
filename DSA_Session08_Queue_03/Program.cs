using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DSA_Session08_Queue_03
{
    // 1. Xây dựng Class đối tượng PrintJob
    public class PrintJob
    {
        public string TenTaiLieu { get; set; }
        public int SoTrang { get; set; }

        public PrintJob(string ten, int trang)
        {
            TenTaiLieu = ten;
            SoTrang = trang;
        }
    }

    class Program
    {
        // Khởi tạo hàng đợi và một "Ổ khóa" để bảo vệ luồng an toàn (Thread-safe)
        static Queue<PrintJob> printQueue = new Queue<PrintJob>();
        static readonly object _lock = new object();

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("=== HỆ THỐNG ĐIỀU PHỐI MÁY IN MẠNG LAN ===");
            Console.WriteLine("Gõ tên tài liệu để in. Nhập 'exit' để tắt máy.");

            // Kích hoạt luồng chạy ngầm của Máy in (Background Worker)
            Task.Run(() => PrinterEngine());

            // Luồng chính: Lắng nghe người dùng nhập liệu liên tục
            while (true)
            {
                string input = Console.ReadLine();
                if (input.ToLower() == "exit") break;

                // Giả lập số trang ngẫu nhiên từ 1 đến 20 trang
                int pages = new Random().Next(1, 20);
                PrintJob newJob = new PrintJob(input, pages);

                // KHÓA Queue lại để đẩy dữ liệu vào an toàn
                lock (_lock)
                {
                    printQueue.Enqueue(newJob);
                }
                Console.WriteLine(
                    $"[HỆ THỐNG] Đã nhận lệnh in: '{newJob.TenTaiLieu}'. Đang chờ tới lượt...\n");
            }
        }

        // 2. Cỗ máy in chạy ngầm độc lập
        static void PrinterEngine()
        {
            while (true)
            {
                PrintJob jobToPrint = null;

                // KHÓA Queue lại để lấy dữ liệu ra an toàn
                lock (_lock)
                {
                    if (printQueue.Count > 0)
                    {
                        jobToPrint = printQueue.Dequeue();
                    }
                }

                // Nếu có tài liệu cần in
                if (jobToPrint != null)
                {
                    Console.WriteLine(
                        $"\n[MÁY IN ĐANG CHẠY] Đang in tài liệu '{jobToPrint.TenTaiLieu}'...");
                    Console.WriteLine($"[MÁY IN] Thời gian in dự kiến: {jobToPrint.SoTrang} giây.");
                    
                    // Giả lập thời gian máy in hoạt động (Mỗi trang tốn 1s, để Demo nhanh thầy fixed 3s)
                    Thread.Sleep(3000); 
                    
                    Console.WriteLine($"[MÁY IN] Hoàn tất in tài liệu '{jobToPrint.TenTaiLieu}'.\n");
                }
                else
                {
                    // Tránh việc máy in kiểm tra quá nhanh làm nóng CPU khi rảnh rỗi
                    Thread.Sleep(1000); 
                }
            }
        }
    }
}