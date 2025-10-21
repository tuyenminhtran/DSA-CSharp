using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace IntStack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;
            int choice = -1;
            ArrayStack arrayStack = new ArrayStack(10);
            ListStack listStack = new ListStack();
            do
            {
                Console.WriteLine("\n\n =============================");
                Console.WriteLine("1. Thêm 1 phần tử vào Stack ( Array Stack )");
                Console.WriteLine("2. Lấy 1 phần tử ra khỏi Stack (Array Stack )");
                Console.WriteLine("3. Lấy 1 phần tử đầu tiên trong Stack ( Array Stack )");
                Console.WriteLine("4. Thêm 1 phần tử vào Stack ( List Stack )");
                Console.WriteLine("5. Lấy 1 phần tử ra khỏi Stack ( List Stack )");
                Console.WriteLine("6. Lấy 1 phần tử đầu tiên trong Stack ( List Stack )");
                Console.WriteLine("7. Quick Sort ( Stack )");
                Console.Write("Nhập lựa chọn : ");
                choice = int.Parse(Console.ReadLine());

                switch ( choice )
                {
                    case 1:
                        {
                            int x = 0;
                            while ( true )
                            {
                                Console.Write("Nhập giá trị cần thêm vào Stack ( Nhập < 0 ==> kết thúc) :");
                                x = int.Parse(Console.ReadLine());
                                if (x < 0)
                                    break;
                                else
                                    arrayStack.Push(x);
                            }
                        }
                        break;
                    case 2:
                        {
                            int outItem;
                            while ( arrayStack.IsEmpty() == false )
                            {
                                arrayStack.Pop(out outItem);
                                Console.Write(outItem + " ; ");
                            }
                            Console.WriteLine();
                            break;
                        }
                    case 3:
                        {
                            int outItem;
                            if (arrayStack.GetTop(out outItem) == true)
                                Console.WriteLine($"Phần tử đầu Stack : {outItem}");
                            else
                                Console.WriteLine("Danh sách rỗng");
                        }
                        break;
                    case 4:
                        {
                            int x = 0;
                            while ( true )
                            {
                                Console.Write("Nhập giá trị cần thêm vào Stack ( Nhập < 0 ==> kết thúc ) :  ");
                                x = int.Parse(Console.ReadLine());
                                if (x < 0)
                                    break;
                                else
                                    listStack.Push(x);
                            }
                        }
                        break;
                    case 5:
                        {
                            int outItem;
                            while ( listStack.IsEmpty() == false )
                            {
                                listStack.Pop(out outItem);
                                Console.Write(outItem + " ; ");
                            }
                            Console.WriteLine();
                        }
                        break;
                    case 6:
                        {
                            int outItem;
                            if (listStack.GetTop(out outItem) == true)
                                Console.WriteLine($"Phần tử đầu Stack : {outItem} ");
                            Console.WriteLine("Danh sách rỗng ");
                        }
                        break;
                    case 7:
                        {
                            // tạo mảng a
                            int[] a = new int[] { 2, 3, 9, 5, 19, 22, 6, 95 };
                            Console.WriteLine("\n Mảng trước khi sắp xếp : ");
                            foreach ( int x in a )
                                Console.Write(x + " ; ");

                            // sắp xếp bằng quick sort
                            StackDoan stkDoan = new StackDoan();
                            stkDoan.QuickSort_NonRecursive(a);

                            Console.WriteLine("\n Mảng sau khi sắp xếp : ");
                            foreach ( int x in a )
                                Console.Write(x + " ; ");
                        }
                        break;
                }
            } while (choice != 0);

        }
    }
}
