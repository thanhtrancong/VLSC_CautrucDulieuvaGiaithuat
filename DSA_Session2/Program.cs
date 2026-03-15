   using System;

class Program
{
 // Hàm đệ quy tính giai thừa 
    static long GiaiThua(int n)
    {
        // 1. Trường hợp cơ sở: 0! = 1 và 1! = 1
        if (n <= 1) return 1;

        // 2. Bước đệ quy: n! = n * (n-1)!
        return n * GiaiThua(n - 1);
    }
static int Fibonacci(int n)
{
    // Trường hợp cơ sở 
    if (n == 0) return 0;
    if (n == 1) return 1;

    // Bước đệ quy: F(n) = F(n-1) + F(n-2)
    return Fibonacci(n - 1) + Fibonacci(n - 2);
}

    static void Main(string[] args)
    {
        Console.Write("Nhap so n: ");
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine("{0}! = {1}", n, GiaiThua(n));
        Console.WriteLine("Fibonacci({0}) = {1}", n, Fibonacci(n));
        
        // Gọi các bài tập tiếp theo tại đây
    }
}
