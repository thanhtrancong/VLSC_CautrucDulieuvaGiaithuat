using System;

namespace Buoi1_ThucHanh
{
    // ĐỊNH NGHĨA CTDL: Một lớp SinhVien đơn giản
    // Lưu ý: Class là "Kiểu tham chiếu" (Reference Type), dữ liệu sẽ nằm trên vùng nhớ Heap.
    class SinhVien
    {
        public string HoTen { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // --- BÀI TẬP 1: HIỂU VỀ THAM CHIẾU (REFERENCE) ---
            Console.WriteLine("=== Bai tap 1: Tham chieu ===");
            SinhVien sv1 = new SinhVien { HoTen = "Nguyen Van An" };

            // sv2 không tạo vùng nhớ mới, nó chỉ "trỏ" cùng vào địa chỉ của sv1
            SinhVien sv2 = sv1;

            sv2.HoTen = "Tran Thi Binh"; // Thay đổi qua sv2

            // Kết quả in ra sv1 sẽ là "Tran Thi Binh" vì cả hai dùng chung địa chỉ Heap
            Console.WriteLine($"Ten cua sv1 sau khi thay doi qua sv2: {sv1.HoTen}");


            // --- BÀI TẬP 2: HOÁN ĐỔI GIÁ TRỊ VỚI TỪ KHÓA 'ref' ---
            // 'ref' cho phép hàm truy cập trực tiếp vào địa chỉ vùng nhớ của biến gốc 
            // trên Stack, giúp hoán đổi giá trị mà không cần trả về kết quả.
            Console.WriteLine("\n=== Bai tap 2: Hoan doi (Swap) ===");
            int a = 10, b = 20;
            Console.WriteLine($"Truoc khi Swap: a = {a}, b = {b}");

            Swap(ref a, ref b); // Phải có từ khóa 'ref' khi gọi hàm

            Console.WriteLine($"Sau khi Swap: a = {a}, b = {b}");


            // --- BÀI TẬP 3: THAO TÁC MẢNG VÀ HIỆU NĂNG ---
            // Mảng là kiểu tham chiếu. Truy xuất mảng qua index có độ phức tạp O(1).
            Console.WriteLine("\n=== Bai tap 3: Thao tac mang ===");
            int[] numbers = { 1, 2, 3, 4, 5 };

            PrintArray(numbers);
        }

        // Giải thích Bài 2: Dùng 'ref' để tác động vào vùng nhớ Stack của biến truyền vào
        static void Swap(ref int x, ref int y)
        {
            int temp = x;
            x = y;
            y = temp;
        }

        // Giải thích Bài 3: Duyệt mảng thông qua chỉ số (Index)
        static void PrintArray(int[] arr)
        {
            Console.Write("Cac phan tu trong mang: ");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();
        }
    }
}