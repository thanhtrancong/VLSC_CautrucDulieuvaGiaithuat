using System;
using System.Diagnostics;
// Author: Nguyễn Văn A - 20200123
// Mục tiêu: So sánh hiệu năng giữa Linear Search và Binary Search trên mảng đã sắp xếp
class Program {
    static void Main() {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        
        // 1. Khởi tạo mảng 1 triệu phần tử đã sắp xếp
        int n = 1000000;
        int[] arr = new int[n];
        for (int i = 0; i < n; i++) arr[i] = i * 2; // Mảng chứa các số chẵn

        int x = arr[n - 1]; // Tìm phần tử cuối cùng (Trường hợp xấu nhất)
        Stopwatch sw = new Stopwatch();

        // 2. Chạy Linear Search
        sw.Start();
        int idx1 = LinearSearch(arr, x);
        sw.Stop();
        Console.WriteLine($"[Linear] Index: {idx1}, Time: {sw.Elapsed.TotalMilliseconds} ms");

        // 3. Chạy Binary Search
        sw.Restart();
        int idx2 = BinarySearch(arr, x);
        sw.Stop();
        Console.WriteLine($"[Binary] Index: {idx2}, Time: {sw.Elapsed.TotalMilliseconds} ms");
    }

    static int LinearSearch(int[] arr, int target) {
        for (int i = 0; i < arr.Length; i++) {
            if (arr[i] == target) return i;
        }
        return -1;
    }

    static int BinarySearch(int[] arr, int target) {
        int left = 0, right = arr.Length - 1;
        while (left <= right) {
            int mid = left + (right - left) / 2;
            if (arr[mid] == target) return mid;
            if (arr[mid] < target) left = mid + 1;
            else right = mid - 1;
        }
        return -1;
    }
}