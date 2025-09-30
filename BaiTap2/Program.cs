using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace BaiTap2
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            int choice = -1;
            do
            {
                Console.WriteLine();
                Console.WriteLine("===========================================");
                Console.WriteLine("1. Sinh ra mảng ngẫu nhiên có 20 phần tử : ");
                Console.WriteLine("2. Tạo mảng từ 1 mảng có sẵn : ");
                Console.WriteLine("3. Sao chép mảng từ 1 đối tượng obj : ");
                Console.WriteLine("4. Linear Search : ");
                Console.WriteLine("5. Binary Search : ");
                Console.WriteLine("6. Tìm và trả về phần tử lớn nhất cuối cùng : ");
                Console.WriteLine("7. Xóa phần tử có giá trị x : ");
                Console.WriteLine("8. Chèn thêm phần tử có giá trị x sau phần tử có giá trị lớn nhất : ");
                Console.WriteLine("9. Interchange Sort");
                Console.WriteLine("10. Bubble Sort");
                Console.WriteLine("11. Selection Sort");
                Console.WriteLine("12. Insertion Sort");
                Console.WriteLine("13. quick Sort");
                Console.WriteLine("0. Thoát");
                Console.Write("Nhập lựa chọn : ");
                Console.WriteLine();   
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Vui lòng nhập số nguyên hợp lệ!");
                    choice = -1;
                    continue; // bỏ qua switch nếu nhập sai
                }
                switch ( choice )
                {
                    case 1: TestConstructor1(); break;
                    case 2: TestConstructor2(); break;
                    case 3: TestConstructor3(); break;
                    case 4: TestLinearSearch(); break;
                    case 5: TestBinariSearch(); break;
                    case 6: TestTimGiaTriLonNhat(); break;
                    case 7: TestXoaPhanTu(); break;
                    case 8: TestChenPhanTuX(); break;
                    case 9: TestInterchangeSort(); break;
                    case 10:TestBubbleSort(); break;
                    case 11: TestSelectionSort(); break;
                    case 12: TestInsertionSort(); break;
                    case 13: TestQuickSort(); break;
                    case 0: Console.WriteLine("==> Thoát chương trình..."); break;
                    default: Console.WriteLine("Lựa chọn không hợp lệ!"); break;
                }
            } while (choice != 0);           
        }
     
        static void TestConstructor1()
        {
            IntArray obj = new IntArray(20);
            Console.Write("Giá trị mảng phát sinh : ");
            obj.Output();
        }
        static void TestConstructor2()
        {
            int[] a = { 4, 8, 12, 9, 5, 19, 22, 3 };
            IntArray obj = new IntArray(a);
            Console.Write("Giá trị mảng : ");
            obj.Output();
        }
        static void TestConstructor3()
        {
            IntArray obj1 = new IntArray();
            obj1.Input();
            Console.Write("Giá trị mảng : ");
            obj1.Output();

            IntArray obj2 = new IntArray();
            obj2.Input();
            Console.Write("\n Giá trị mảng copy : ");
            obj2.Output();
        }
        static void TestLinearSearch()
        {
            int k, x, kq;
            Console.Write("== Nhập số lượng mảng : ");
                int.TryParse(Console.ReadLine(), out k);
            
            IntArray obj = new IntArray(k);
            Console.WriteLine("== Các phần tử : ");
            obj.Output();

            Console.Write("\n Giá trị cần tìm x = ");
            int.TryParse(Console.ReadLine(), out x);

            kq = obj.LinearSearch(x);
            if (kq == -1)
                Console.WriteLine("==> Không tồn tại {0}", x);
            else Console.WriteLine("==> có {0} tại vị trí : {1}", x, kq);
        }

        static void TestBinariSearch()
        {
            //Lưu ý mảng cần có thứ tự
            int x, kq;
            IntArray obj = new IntArray();
            obj.Input();
            Console.WriteLine("==> các phần tử : ");
            obj.Output();

            Console.Write("\n Giá trị cần tìm x = ");
            int.TryParse(Console.ReadLine(), out x);

            kq = obj.BinarySearch(x);
            if (kq == -1)
                Console.WriteLine("==> không tồn tại {0}!", x);
            else
                Console.WriteLine("==> có {0} tại vị trí {1}: ", x, kq);
        }
        static void TestTimGiaTriLonNhat()
        {
            int x, kq;
            IntArray obj = new IntArray();
            obj.Input();
            Console.WriteLine("==> các phần tử : ");
            obj.Output();

            int viTriMaxCuoiCung = obj.TimViTriMaxCuoiCung();
            if (viTriMaxCuoiCung == -1)
                Console.WriteLine("==> không tồn tại!");
            Console.WriteLine($"==> có vị trí max = {viTriMaxCuoiCung} với giá trị {obj.Arr[viTriMaxCuoiCung]}");
        }
        static void TestXoaPhanTu()
        {
            int k, x, kq;
            Console.Write("==> Nhập số lượng mảng : ");
            int.TryParse(Console.ReadLine(), out k);
            IntArray obj = new IntArray(k);
            Console.WriteLine("==> các phần tử : ");
            obj.Output();

            Console.Write("\n Nhập giá trị cần xóa x = ");
            int.TryParse(Console.ReadLine(), out x);

            obj.XoaPhanTu_X(x);
            Console.WriteLine("Mảng sau khi xóa : ");
            obj.Output();
        }
        static void TestChenPhanTuX()
        {
            int x, kq;
            IntArray obj = new IntArray();
            obj.Input();
            Console.WriteLine("==> Các phần tử : ");
            obj.Output();

            Console.Write("\n Giá trị cần chèn : ");
            int.TryParse(Console.ReadLine(), out x);

            obj.ChenThemPhanTu_X(x);
            Console.WriteLine("Mảng sau khi chèn : ");
            obj.Output();


        }
        static void TestInterchangeSort()
        {
            // sinh mảng ngẫu nhiên k phần tử 
            Console.Write("Nhập số lượng phần tử k : ");
            int k = int.Parse(Console.ReadLine());

            IntArray objTemp = new IntArray(k);
            Console.WriteLine("\n ==> Mảng ban đầu : ");
            objTemp.Output();
            objTemp.InterChangeSort();
            Console.WriteLine("\n ==> Interchange Sort : ");
            objTemp.Output();
        }
        static void TestBubbleSort()
        {
            // sinh mảng ngẫu nhiên k phần tử
            Console.Write("Nhập số lượng phần tử k : ");
            int k = int.Parse(Console.ReadLine());

            IntArray objTemp = new IntArray(k);
            Console.WriteLine("\n ==> Mảng ban đầu : ");

            objTemp.Output();
            objTemp.BubbleSort();
            Console.WriteLine("\n ==> Bubble Sort : ");
            objTemp.Output();
        }
        static void TestSelectionSort()
        {
            Console.Write("Nhập số lượng phần tử k : ");
            int k = int.Parse(Console.ReadLine());

            IntArray objTemp = new IntArray();
            Console.WriteLine("\n ==> Mảng ban đầu : ");
            objTemp.Output();
            Console.WriteLine("\n ==> Selection Sort : ");
            objTemp.SelectionSort();
            objTemp.Output();
        }
        static void TestInsertionSort()
        {
            Console.Write("Nhập số lượng phần tử k : ");
            int k = int.Parse(Console.ReadLine());

            IntArray objTemp = new IntArray();
            Console.WriteLine("\n ==> Mảng ban đầu : ");
            objTemp.Output();
            Console.WriteLine("\n ==> Insertion Sort : ");
            objTemp.InsertionSort();
            objTemp.Output();
        }
        static void TestQuickSort()
        {
            Console.WriteLine("Nhập số lượng phần tử k : ");
            int k = int.Parse(Console.ReadLine());

            IntArray objTemp = new IntArray();
            Console.WriteLine("\n ==> Mảng ban đầu : ");
            objTemp.Output();
            Console.WriteLine("\n Quick Sort : ");
            objTemp.InsertionSort();
            objTemp.Output();
        }
    }
    
}
