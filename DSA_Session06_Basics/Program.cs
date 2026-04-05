namespace DSA_Session06_Basics;

class Program
{
    static void Main(string[] args)
    {
       int choice;
        // Sử dụng vòng lặp do-while để hiển thị menu và xử lý lựa chọn của người dùng
        // Vòng lặp sẽ tiếp tục cho đến khi người dùng chọn thoát (choice == 0)
        do
        {
            Console.WriteLine("\n=== MENU QUẢN LÝ ===");
            Console.WriteLine("1. Chức năng A");
            Console.WriteLine("2. Chức năng B");
            Console.WriteLine("0. Thoát chương trình");
            Console.Write("Mời bạn chọn (0-2): ");
            //Toán tử điều kiện (ternary operator) để kiểm tra và gán giá trị cho biến choice
            choice = int.TryParse(Console.ReadLine(), out choice)
                ? choice
                : -1; // Nếu nhập không hợp lệ, gán giá trị -1 để xử lý trong switch
// Sử dụng switch-case để xử lý các lựa chọn của người dùng
//Cấu trúc switch-case giúp mã nguồn rõ ràng và dễ bảo trì hơn so với nhiều câu lệnh if-else
// Mỗi case tương ứng với một lựa chọn của người dùng, 
// và default xử lý các trường hợp không hợp lệ
//break được sử dụng để ngăn chặn việc thực thi tiếp tục vào 
///các case khác sau khi đã thực hiện xong case hiện tại
/// Nếu không có break, chương trình sẽ tiếp tục thực thi các case tiếp theo 
/// cho đến khi gặp break hoặc kết thúc switch
            switch (choice)
            {
                case 1:
                    Console.WriteLine("Đang chạy chức năng A...");
                    break;
                case 2:
                    Console.WriteLine("Đang chạy chức năng B...");
                    break;
                case 0:
                    Console.WriteLine("Tạm biệt!");
                    break;
                default:
                    Console.WriteLine("Lựa chọn không hợp lệ, vui lòng nhập lại!");
                    break;
            }
        } while (choice != 0);// Kết thúc vòng lặp khi người dùng chọn thoát (choice == 0)
    }
}
