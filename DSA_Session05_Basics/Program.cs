namespace DSA_Session05_Basics;
class Program
{
    static void Main(string[] args)
    {
        //         Bài 1: Hoán đổi 2 số không dùng biến tạm (Toán học)
        // Gợi ý: Dùng phép cộng và trừ
        // người dùng có thể nhập 2 số từ bàn phím và sau đó thực hiện hoán đổi
        Console.WriteLine("Bài 1: Hoán đổi 2 số không dùng biến tạm");
        Console.Write("Nhập số a: ");
        // Đọc chuỗi nhập vào từ bàn phím và lưu vào biến inputA
        string inputA = Console.ReadLine();
        // Sử dụng int.TryParse để chuyển đổi chuỗi nhập vào thành số nguyên, 
        // nếu không hợp lệ thì yêu cầu người dùng nhập lại.
        int a;
        while (!int.TryParse(inputA, out a))
        {
            Console.Write("Số a không hợp lệ. Vui lòng nhập lại: ");
            inputA = Console.ReadLine();
        }
        Console.Write("Nhập số b: ");
        // Đọc chuỗi nhập vào từ bàn phím và lưu vào biến inputB
        string inputB = Console.ReadLine();
        // Sử dụng int.TryParse để chuyển đổi chuỗi nhập vào thành số nguyên, 
        // nếu không hợp lệ thì yêu cầu người dùng nhập lại.
        int b;
        while (!int.TryParse(inputB, out b))
        {
            Console.Write("Số b không hợp lệ. Vui lòng nhập lại: ");
            inputB = Console.ReadLine();
        }
        a = a + b; // Cộng a và b, kết quả lưu vào a
        b = a - b; // Lấy giá trị mới của a trừ đi b, 
        // kết quả lưu vào b (b giờ là giá trị ban đầu của a)
        a = a - b; // Lấy giá trị mới của a trừ đi b, 
        // kết quả lưu vào a (a giờ là giá trị ban đầu của b)
        Console.WriteLine($"a={a}, b={b}");

        Console.WriteLine("================================");
        Console.WriteLine("Bài 2: Vẽ hình vuông dấu sao (n x n)");
        // ngươi dùng có thể nhập kích thước n từ bàn phím 
        // và sau đó in ra hình vuông tương ứng
        Console.Write("Nhập kích thước n của hình vuông: ");
        string inputN = Console.ReadLine();
        int n;// Sử dụng int.TryParse để chuyển đổi chuỗi nhập vào thành số nguyên, 
        // nếu không hợp lệ thì yêu cầu người dùng nhập lại.
        // n > 0
        while (!int.TryParse(inputN, out n) || n <= 0)
        {
            Console.Write("Kích thước n không hợp lệ. Vui lòng nhập lại: ");
            inputN = Console.ReadLine();
        }
        // Dùng 2 vòng lặp for để in ra hình vuông dấu sao
        for (int i = 0; i < n; i++)
        { // Duyệt hàng
            for (int j = 0; j < n; j++)
            { // Duyệt cột
                Console.Write("* ");
            }
            Console.WriteLine(); // Xuống dòng sau mỗi hàng
        }

        Console.WriteLine("================================");
        Console.WriteLine("Bài 3: In bảng cửu chương (2 đến 9)");
        for (int i = 2; i <= 9; i++)
        {
            Console.WriteLine($"--- Bang cuu chuong {i} ---");
            for (int j = 1; j <= 10; j++)
            {
                Console.WriteLine($"{i} x {j} = {i * j}");
            }
        }

    }
}