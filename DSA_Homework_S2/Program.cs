using System;
class Program
{
    // Hàm đệ quy tính tổng S(n)
    static int TinhTong(int n)
    {
        // 1. Trường hợp cơ sở: Khi n = 1, tổng chính là 1
        if (n == 1) return 1;

        // 2. Bước đệ quy: S(n) = n + S(n-1)
        return n + TinhTong(n - 1);
    }
static long GiaiThuaVongLap(int n)
{
    long ketQua = 1;
    for (int i = 1; i <= n; i++)
    {
        ketQua *= i; // Cập nhật trực tiếp trên 1 vùng nhớ duy nhất
    }
    return ketQua;
}

    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.Write("Nhập n để tính tổng: ");
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine($"Tổng S({n}) = {TinhTong(n)}");
        Console.WriteLine($"Giai thừa của {n} là {GiaiThuaVongLap(n)}");
    }
}
