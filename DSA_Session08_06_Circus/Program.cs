using System;
namespace DSA_Session08_06_Circus
{
    // Trình duyệt rạp xiếc: theo cấu trúc double linked list.
    // Mỗi node lưu trữ URL của một trang web.
    // Người dùng có thể thực hiện các lệnh: Visit(url), Back(), Forward().
    // Mô phỏng lịch sử web. Tạo 3 lệnh: Visit(url), Back(), Forward(). 
    // In ra URL hiện tại mỗi khi thực hiện lệnh.

    class Node
    //Lưu trữ URL và liên kết đến node trước và sau
    {
        public string Url { get; set; }
        public Node Prev { get; set; }
        public Node Next { get; set; }
        public Node(string url)
        {
            Url = url;
            Prev = null;
            Next = null;
        }
    }
    class BrowserHistory
    {
        private Node current;

        public BrowserHistory(string homepage)
        {
            current = new Node(homepage);
        }

        public void Visit(string url)
        {
            Node newNode = new Node(url);
            current.Next = newNode;
            newNode.Prev = current;
            current = newNode;
        }

        public string Back()
        {
            if (current.Prev != null)
            {
                current = current.Prev;
            }
            return current.Url;
        }

        public string Forward()
        {
            if (current.Next != null)
            {
                current = current.Next;
            }
            return current.Url;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            BrowserHistory browserHistory = new BrowserHistory("homepage.com");
            browserHistory.Visit("page1.com");
            browserHistory.Visit("page2.com");
            Console.WriteLine(browserHistory.Back()); // Output: page1.com
            Console.WriteLine(browserHistory.Back()); // Output: homepage.com
            Console.WriteLine(browserHistory.Forward()); // Output: page1.com
            browserHistory.Visit("page3.com");
            Console.WriteLine(browserHistory.Forward()); // Output: page3.com
        }
    }
}