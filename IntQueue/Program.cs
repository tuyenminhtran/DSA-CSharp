using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntQueue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            ArrayQueue arrQueue = new ArrayQueue(4);
            ListQueue lstQueue = new ListQueue();
            Console.OutputEncoding = Encoding.UTF8;
            do
            {
                Console.WriteLine("\n\n========================================");
                Console.WriteLine("1.   Nhập Queue               (Array)");
                Console.WriteLine("2.   Xuất Queue               (Array)");
                Console.WriteLine("3.   Tìm phần tử đầu Queue    (Array)");
                Console.WriteLine("4.   Tìm phần tử cuối Queue   (Array)");
                Console.WriteLine("5.   Hiển thị Queue           (Array)");
                Console.WriteLine("6.   Nhập Queue               (List)");
                Console.WriteLine("7.   Xuất Queue               (List)");
                Console.WriteLine("8.   Hiển thị Queue           (List)");
                Console.WriteLine("9.   Tìm phần tử đầu Queue    (List)");
                Console.WriteLine("10.  Tìm phần tử cuối Queue   (List)");
                Console.WriteLine("11.  Xoay vòng Queue          (Array)");
                Console.WriteLine("12.  Xoay vòng Queue          (List)");
                Console.WriteLine("0.   Thoát !");
                Console.Write("Nhập lựa chọn : ");
                int choice = int.Parse(Console.ReadLine());
                Console.WriteLine();
                switch ( choice )
                {
                    case 1:
                        do
                        {
                            Console.Write("Nhập x ( < 0 thì dừng ) : ");
                            int x = int.Parse(Console.ReadLine());
                            if (x < 0) break;
                            else
                            {
                                if (arrQueue.IsFull()) Console.WriteLine("Queue Đầy !");
                                else arrQueue.EnQueue(x);
                            }
                        } while (true);
                        break;
                    case 2:
                        {
                            int outItem;
                            arrQueue.DeQueue(out outItem);
                            Console.Write(outItem + " : ");
                        }
                        break;
                    case 3:
                        {
                            int topItem;
                            arrQueue.GetFront( out topItem);
                            Console.WriteLine("Phần tử đầu Queue : " + topItem);
                        }
                        break;
                    case 4:
                        {
                            int lastItem;
                            arrQueue.GetRear(out lastItem);
                            Console.WriteLine("Phần tử cuối Queue : " + lastItem);
                        }
                        break;
                    case 5:
                        {
                            arrQueue.DisplayQueue();
                        }
                        break;
                    case 6:
                        {
                            do
                            {
                                Console.Write("Nhập x ( < 0 thì dừng ) : ");
                                int x = int.Parse(Console.ReadLine());
                                if (x < 0) break;
                                else lstQueue.EnQueue(x);
                            }while ( true  );
                        }
                        break;
                    case 7:
                        {
                            if (lstQueue.DeQueue(out int outItem))
                                Console.Write(outItem + " : ");
                            else
                                Console.WriteLine("Queue rỗng !");
                        }
                        break;
                    case 8:
                        {
                            lstQueue.DisplayQueue();
                        }
                        break;
                    case 9:
                        {
                            int topItem;
                            lstQueue.GetFront(out topItem);
                            Console.WriteLine("Phần tử đầu Queue : " + topItem);
                        }
                        break;
                    case 10:
                        {
                            int lastItem;
                            lstQueue.GetRear(out lastItem);
                            Console.WriteLine("Phần tử cuối Queue : " + lastItem);
                        }
                        break;
                    case 11:
                        {
                            Console.Write("Nhập số lần xoay k: ");
                            int k = int.Parse(Console.ReadLine());
                            arrQueue.RotateLeft(k);
                            arrQueue.DisplayQueue();
                        }
                        break;
                    case 12:
                        {
                            Console.Write("Nhập số lần xoay k: ");
                            int k = int.Parse(Console.ReadLine());
                            lstQueue.RotateLeft(k);
                            lstQueue.DisplayQueue();
                        }
                        break;
                }
            } while (true);
        }
    }
}
