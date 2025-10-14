using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSLKDon
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            MyList lst1 = new MyList();
            MyList lst2 = new MyList();
            MyList lst3 = new MyList();

            int choice;
            do
            {
                Console.WriteLine("1. Nhập danh sách 1");
                Console.WriteLine("2. Nhập danh sách 2");
                Console.WriteLine("3. Hiển thị danh sách 1");
                Console.WriteLine("4. Hiển thị danh sách 2");
                Console.WriteLine("5. Nối danh sách 1 và 2 thành danh sách 3");
                Console.WriteLine("6. Hiển thị danh sách 3");
                Console.WriteLine("7. Tìm node có giá trị lớn nhất và nhỏ nhất trong danh sách 3");
                Console.WriteLine("8. Tính trung bình các node lẻ trong danh sách 3");
                Console.WriteLine("9. Xóa node tại  vị trí thứ i ");
                Console.WriteLine("10. Xóa node có giá trị x ");
                Console.WriteLine("11. Chèn x vào danh sách tại vị trí thứ i "); ;
                Console.WriteLine("12. Chèn x vào sau node có giá trị nhỏ nhất ");
                Console.WriteLine("13. Chèn x vào sau node có giá trị y ");
                Console.WriteLine("14. Chèn x vào trước node có giá trị lớn nhất ");
                Console.WriteLine("15. Chèn x vào trước node có giá trị y ");
                Console.WriteLine("16. Trả về danh sách sau khi dịch trái "); // các node dịch về trái và node đầu tiên bị loại
                Console.WriteLine("17. Trả về danh sách sau khi dịch phải xoay vòng "); // các node dịch về phải và node cuối cùng trở thành node đầu tiên của list 
                Console.WriteLine("18. Sắp xếp danh sách theo thứ tự các giá trị tăng dần ( Interchange Sort ) ");
                Console.WriteLine("19. Sắp xếp danh sách theo thứ tự giảm dần các giá trị trong danh sách ( Selection Sort )");
                Console.WriteLine("20. Merge List ");
                Console.WriteLine("0. Thoát chương trình");
                Console.Write("=> Nhập lựa chọn của bạn: ");
                choice = int.Parse(Console.ReadLine());
                Console.WriteLine();
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("=== Nhập danh sách 1 ===");
                        lst1.Input();
                        break;
                    case 2:
                        Console.WriteLine("=== Nhập danh sách 2 ===");
                        lst2.Input();
                        break;
                    case 3:
                        Console.WriteLine("=== Danh sách 1 ===");
                        lst1.ShowList();
                        break;
                    case 4:
                        Console.WriteLine("=== Danh sách 2 ===");
                        lst2.ShowList();
                        break;
                    case 5:
                        Console.WriteLine("=== Nối danh sách 1 và 2 thành danh sách 3 ===");
                        lst3 = MyList.JoinList(lst1, lst2);
                        Console.WriteLine("Đã nối xong!");
                        break;
                    case 6:
                        Console.WriteLine("=== Danh sách 3 ===");
                        lst3.ShowList();
                        break;
                    case 7:
                        {
                        IntNode maxNode = lst3.GetMax();
                        IntNode minNode = lst3.GetMin();
                            if (maxNode != null && minNode != null)
                            {
                                Console.WriteLine($"Giá trị lớn nhất: {maxNode.Data}");
                                Console.WriteLine($"Giá trị nhỏ nhất: {minNode.Data}");
                            }
                            else
                                Console.WriteLine("Danh sách 3 đang rỗng!");
                        break;
                        }
                    case 8:
                        double tbLe = lst3.TBLe();
                        if (tbLe == 0) Console.WriteLine("Không có phần tử lẻ trong danh sách!"); 
                        else Console.WriteLine($"Trung bình cộng các phần tử lẻ: {tbLe}");
                        break;
                    case 0: 
                        Console.WriteLine("Tạm biệt bạn, hẹn gặp lại 💖"); 
                        break;
                    default: Console.WriteLine("Lựa chọn không hợp lệ, vui lòng thử lại!");
                        break;
                }
                Console.WriteLine();
            } while (choice != 0);
        }
    }
}
