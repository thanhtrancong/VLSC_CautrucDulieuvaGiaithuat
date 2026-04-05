using System;
namespace DSA_Session05_Sortings;
class Program
{
    static void Main(string[] args)
    {// Nhập mảng từ người dùng
        int[] arr = InputArray();
        //// Tạo bản sao của mảng để sử dụng cho thuật toán khác
        int[] arrCopy = (int[])arr.Clone();
        Console.WriteLine("Mảng ban đầu:");
        PrintArray(arr);
        BubbleSort(arr);
        Console.WriteLine("Mảng sau khi sắp xếp (Bubble Sort):");
        PrintArray(arr);
        InsertionSort(arrCopy);
        Console.WriteLine("Mảng sau khi sắp xếp (Insertion Sort):");
        PrintArray(arrCopy);
    }
// Hàm để nhập mảng từ người dùng
    private static int[] InputArray()
    {
        Console.WriteLine("Nhập số lượng phần tử:");
        int n;
        while (!int.TryParse(Console.ReadLine(), out n))
        {
            Console.WriteLine("nhập một số nguyên hợp lệ:");
        }
        int[] arr = new int[n];
        Console.WriteLine("Nhập các phần tử:");
        for (int i = 0; i < n; i++)
        {
            while (!int.TryParse(Console.ReadLine(), out arr[i]))
            {
                Console.WriteLine("nhập một số nguyên hợp lệ:");
            }
        }
        return arr;
    }
    // Hàm để in mảng
    private static void PrintArray(int[] arr)
    {
        foreach (int item in arr)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
    }

    //     3.1. Bubble Sort (Sắp xếp nổi bọt)
    // Nguyên lý: So sánh từng cặp phần tử liền kề và hoán đổi nếu chúng 
    // không theo thứ tự đúng. 
    // Quá trình này lặp lại cho đến khi không còn hoán đổi nào cần thiết.
    // Cách hoạt động: Bắt đầu từ phần tử đầu tiên, 
    // so sánh nó với phần tử tiếp theo và hoán đổi nếu cần.
    // Độ phức tạp: O(n^2) trong trường hợp xấu nhất, 
    // O(n) trong trường hợp tốt nhất (khi mảng đã sắp xếp).
    static void BubbleSort(int[] arr)
    {
        int n = arr.Length;
        int swapCount = 0;
        for (int i = 0; i < n - 1; i++)
        // Duyệt qua tất cả phần tử, trừ phần tử cuối cùng
        {
            for (int j = 0; j < n - i - 1; j++)
            // So sánh phần tử hiện tại với phần tử tiếp theo
            {
                if (arr[j] > arr[j + 1])
                // Nếu phần tử hiện tại lớn hơn phần tử tiếp theo, hoán đổi chúng
                {
                    int temp = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = temp;
                    swapCount++;
                }
            }
        }
        Console.WriteLine($"Bubble Sort tốn {swapCount} lần hoán đổi.");
    }
    // 3.2. Insertion Sort (Sắp xếp chèn)
    // Nguyên lý: Lấy từng phần tử và chèn vào đúng vị trí trong đoạn đã sắp xếp 
    // (giống xếp bài tây).
    // Cách hoạt động: Bắt đầu từ phần tử thứ hai, 
    // so sánh nó với phần tử trước đó và chèn nó vào đúng vị trí trong phần đã sắp xếp.
    // Độ phức tạp: O(n^2) trong trường hợp xấu nhất, 
    // O(n) trong trường hợp tốt nhất (khi mảng đã sắp xếp).

    //  swapCount = 0; // Biến toàn cục để đếm số lần hoán đổi
    static void InsertionSort(int[] arr)
    {
        int swapCount = 0;
        int n = arr.Length;
        for (int i = 1; i < n; i++)// Bắt đầu từ phần tử thứ hai
        {
            int key = arr[i];// Phần tử cần chèn
            int j = i - 1;// Chỉ số của phần tử trước đó
            // Di chuyển các phần tử lớn hơn key sang phải
            while (j >= 0 && arr[j] > key)// So sánh key với phần tử trước đó
            // Nếu phần tử trước đó lớn hơn key, di chuyển nó sang phải
            {
                arr[j + 1] = arr[j];// Di chuyển phần tử sang phải
                j--;// Di chuyển chỉ số sang trái
                swapCount++;
            }
            arr[j + 1] = key;
        }
        Console.WriteLine($"Insertion Sort tốn {swapCount} lần hoán đổi.");
    }
}