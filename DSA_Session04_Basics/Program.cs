using System;
using System.Diagnostics;
// Author: Nguyễn Văn A - 20200123
// Mục tiêu: 

class Program {
    static void Main() {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        // Bài 1: Lời chào thông minh 
        // Yêu cầu: Nhập tên và MSSV, in ra lời chào.
        // Code: 
        // Sử dụng Console.ReadLine() để gán biến.
        Console.Write("Nhap ho ten: ");
        String name = Console.ReadLine();
        Console.Write("Nhap MSSV: ");
        String mssv = Console.ReadLine();
        Console.WriteLine($"Chao mung sinh vien {name} (MS: {mssv}) den voi lop CTDL&GT!");
//         Bài 2: Máy tính cơ bản
// •	Yêu cầu: Nhập 2 số nguyên a và b. Tính và in ra Tổng, Hiệu, Tích, Thương.
// •	Hướng dẫn: Dữ liệu từ bàn phím luôn là string, 
// các em phải dùng int.Parse() để chuyển về số nguyên trước khi tính toán.
        Console.Write("Nhap so a: ");
        int a = int.Parse(Console.ReadLine());
        Console.Write("Nhap so b: ");
        int b = int.Parse(Console.ReadLine());
        Console.WriteLine($"Tong: {a + b}");
        Console.WriteLine($"Hieu: {a - b}");
        Console.WriteLine($"Tich: {a * b}");
        if (b != 0) {
            Console.WriteLine($"Thuong: {(double)a / b}");
        } else {
            Console.WriteLine("Khong the chia cho 0!");
        }
//         Bài 3: Kỹ thuật Hoán đổi (Swap)
// •	Yêu cầu: Cho 2 biến x=5, y=10. Hãy đổi giá trị của chúng để x=10, y=5.
// •	Hướng dẫn: Hãy tưởng tượng em có 2 ly nước xanh và đỏ, 
// để đổi nước cho nhau em cần thêm 1 ly rỗng (biến temp).
        int x = 5, y = 10;
        Console.WriteLine($"Truoc khi swap: x={x}, y={y}");
        int temp = x; // temp = 5
        x = y; // x = 10
        y = temp; // y = 5
        Console.WriteLine($"Sau khi swap: x={x}, y={y}");

    }
}