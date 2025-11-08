using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntBST
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;

            MyBinaryTree tree = new MyBinaryTree();
            int choice = -1;
            do
            {
                Console.WriteLine("\n \n =============================== ");
                Console.WriteLine("1. Nhập cây : ");
                Console.WriteLine("2. Duyệt cây ( NLR ) : ");
                Console.WriteLine("3. Duyệt cây ( LNR ) : ");
                Console.WriteLine("4. Duyệt cây ( LRN ) : ");
                Console.WriteLine("5. Đếm các node lá : ");
                Console.WriteLine("6. In ra các giá trị của node theo từng mức : ");
                Console.WriteLine("7. In ra các giá trị của node ở mức cuối cùng của cây : ");
                Console.WriteLine("8. Find X : ");
                Console.WriteLine("9. Find Min : ");
                Console.WriteLine("10. Find Max : ");
                Console.WriteLine("11. Remove X : ");
                Console.Write("\n Nhập lựa chọn : ");

                choice = int.Parse(Console.ReadLine());
                switch ( choice )
                {
                    case 1: tree.Input(); break;
                    case 2: Console.WriteLine("Duyệt cây ( NLR ) !!! ");
                            tree.PreOrder(); break;
                    case 3: Console.WriteLine("Duyệt cây ( LNR ) !!! ");
                            tree.InOrder(); break;
                    case 4: Console.WriteLine("Duyệt cây ( LRN ) !!! ");
                            tree.PostOrder(); break;
                    case 5:
                        int count = tree.CountLeaf(tree.Root);
                        Console.WriteLine($"Số nút lá : {count}");
                        break;
                    case 6: tree.ListByLevel(); break;
                    case 7:tree.ListLastLevel(); break;
                    case 8:
                        Console.WriteLine("Nhập X bạn muốn tìm : ");
                        int x = int.Parse(Console.ReadLine());
                        IntNode kq = tree.FindX(x);
                        if (kq == null)
                            Console.WriteLine("Không tìm thấy !!!");
                        else
                            Console.WriteLine("Tìm thấy :) ");
                        break;
                    case 9:
                        IntNode nodeMin = tree.FindMin();
                        Console.WriteLine($"Node min = {nodeMin.Data.ToString()}");
                        break;
                    case 10:
                        IntNode nodeMax = tree.FindMax();
                        Console.WriteLine($"Node max = {nodeMax.Data.ToString()}");
                        break;
                    case 11:
                        Console.WriteLine("Nhập x bạn muốn xóa : ");
                        x = int.Parse(Console.ReadLine());
                        tree.Remove(x);
                        break;
                }
            } while (choice != 0);
        }
    }
}
