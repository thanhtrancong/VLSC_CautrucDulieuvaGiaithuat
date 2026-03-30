
// Author: Nguyễn Văn A - MSSV: 20200123
// Mục tiêu: Học cách sử dụng các thuật toán sắp xếp cơ bản: Bubble Sort, Selection Sort, Insertion Sort.
class Program {
    static void Main() {
        // Thiết lập mã hóa đầu ra để hỗ trợ tiếng Việt
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        // Bài 1: Sắp xếp nổi bọt (Bubble Sort)
        // Yêu cầu: Nhập vào một mảng số nguyên, sử dụng thuật toán Bubble Sort để sắp xếp mảng theo thứ tự tăng dần.
        // Hướng dẫn: Thuật toán Bubble Sort hoạt động bằng cách so sánh từng cặp phần tử liền kề và hoán đổi chúng nếu chúng ở sai thứ tự. 
        // Quá trình này được lặp lại cho đến khi mảng được sắp xếp hoàn toàn.
        Console.Write("Nhap so luong phan tu: ");
        int n = int.Parse(Console.ReadLine());
        // Khởi tạo mảng và nhập giá trị
        int[] arr = new int[n];
        Console.WriteLine("Nhap cac phan tu:");
        // Sử dụng vòng lặp để nhập giá trị cho mảng
        for (int i = 0; i < n; i++) {
            Console.Write($"arr[{i}]: ");
            // Sử dụng Console.ReadLine() để gán giá trị cho mảng
            arr[i] = int.Parse(Console.ReadLine());
        }
        // Gọi hàm Bubble Sort để sắp xếp mảng
        //BubbleSort(arr);
        Console.WriteLine("Mang sau khi sap xep:");
        // In mảng đã sắp xếp
        PrintArray(arr);
        // Insertion Sort (Sắp xếp chèn)
        InsertionSort(arr);
        Console.WriteLine("Mang sau khi sap xep bang Insertion Sort:");
        PrintArray(arr);
    }
// Hàm Bubble Sort
    static void BubbleSort(int[] arr) {
        // Số phần tử trong mảng
        int n = arr.Length;
        // Vòng lặp để duyệt qua tất cả phần tử của mảng
        for (int i = 0; i < n - 1; i++) {
            // Vòng lặp để so sánh các phần tử liền kề
            for (int j = 0; j < n - i - 1; j++) {
                // Nếu phần tử hiện tại lớn hơn phần tử tiếp theo, hoán đổi chúng
                if (arr[j] > arr[j + 1]) {
                    // Hoán đổi arr[j] và arr[j + 1]
                    int temp = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = temp;
                }
            }
        }
    }
// Hàm để in mảng
    static void PrintArray(int[] arr) {
        // Sử dụng vòng lặp foreach để in từng phần tử của mảng
        foreach (int num in arr) {
            // In phần tử hiện tại và một khoảng trắng sau nó
            Console.Write(num + " ");
        }
        Console.WriteLine();
    }
    //Insertion Sort (Sắp xếp chèn)
    // Yêu cầu: Nhập vào một mảng số nguyên, sử dụng thuật toán Insertion Sort để sắp xếp mảng theo thứ tự tăng dần.
    // Hướng dẫn: Thuật toán Insertion Sort hoạt động bằng cách chia mảng
    // thành hai phần: phần đã sắp xếp và phần chưa sắp xếp. Thuật toán sẽ lấy từng phần tử từ phần chưa sắp xếp và chèn nó 
    // vào vị trí thích hợp trong phần đã sắp xếp.
    static void InsertionSort(int[] arr)
    {
        int n = arr.Length;
        // Vòng lặp bắt đầu từ phần tử thứ hai (index 1) đến cuối mảng
        for (int i = 1; i < n; i++)
        {
            // Lưu giá trị của phần tử hiện tại để chèn vào vị trí thích hợp
            int key = arr[i];
            // Biến j để duyệt ngược lại phần đã sắp xếp
            int j = i - 1;
            // Di chuyển các phần tử lớn hơn key sang phải
            while (j >= 0 && arr[j] > key)
            {
                arr[j + 1] = arr[j];
                j--;
            }
            // Chèn key vào vị trí thích hợp
            arr[j + 1] = key;
        }
    }
}
