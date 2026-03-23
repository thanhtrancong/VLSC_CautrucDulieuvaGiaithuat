using System;
using System.Diagnostics; // Thư viện để đo thời gian thực tế
// Author: Nguyễn Văn A - 20200123
// Mục tiêu: So sánh hiệu năng giữa Linear Search và Binary Search trên mảng đã sắp xếp với 10 triệu phần tử
class Program
{
        static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        // --- BÀI TẬP 2: SO SÁNH THỰC TẾ VỚI 10 TRIỆU PHẦN TỬ ---
        int n = 10000000; // 10 triệu phần tử
        int[] arr = new int[n];
        for (int i = 0; i < n; i++) arr[i] = i; // Khởi tạo mảng đã sắp xếp

        int target = 9999999; // Tìm phần tử cuối cùng (Trường hợp xấu nhất)
        Stopwatch sw = new Stopwatch();

        Console.WriteLine($"--- Thử nghiệm với {n} phần tử ---");

        // 1. Đo thời gian Tìm kiếm tuần tự (Linear Search)
        sw.Start();
        int res1 = LinearSearch(arr, target);
        sw.Stop();
        Console.WriteLine($"[Linear Search] Index: {res1}, Time: {sw.Elapsed.TotalMilliseconds} ms");

        // 2. Đo thời gian Tìm kiếm nhị phân Đệ quy (Recursive Binary Search)
        sw.Restart();
        int res2 = BinarySearchRecursive(arr, 0, n - 1, target);
        sw.Stop();
        Console.WriteLine($"[Binary Search Recursive] Index: {res2}, Time: {sw.Elapsed.TotalMilliseconds} ms");
    }

    // Cài đặt Tìm kiếm tuần tự - Độ phức tạp O(n)
    static int LinearSearch(int[] arr, int x)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] == x) return i;
        }
        return -1;
    }

    // Cài đặt Tìm kiếm nhị phân Đệ quy - Độ phức tạp O(log n)
    static int BinarySearchRecursive(int[] arr, int left, int right, int x)
    {
        // Điều kiện dừng: Khi phạm vi tìm kiếm không còn hợp lệ
        if (left > right) return -1;

        // Tính vị trí ở giữa
        int mid = left + (right - left) / 2;

        // Nếu tìm thấy tại mid
        if (arr[mid] == x) return mid;

        // Nếu x nhỏ hơn giá trị tại mid, tìm ở nửa bên trái
        if (arr[mid] > x) 
            return BinarySearchRecursive(arr, left, mid - 1, x);

        // Ngược lại, tìm ở nửa bên phải
        return BinarySearchRecursive(arr, mid + 1, right, x);
    }
}
