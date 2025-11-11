using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntAVLTree
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;

            MyAVLTree t = new MyAVLTree();
            int choice = -1;
            do
            {
                Console.WriteLine("\n =========================");
                Console.WriteLine("1. Nhập cây nhị phân AVL");
                Console.WriteLine("2. Duyệt cây - NLR -");
                Console.WriteLine("3. Duyệt cây - LNR -");
                Console.WriteLine("4. Duyệt cây - LRN -");
                Console.WriteLine("5. In theo từng bậc");
                Console.WriteLine("6. Tìm X ");
                Console.WriteLine("7. Xóa X ");

                Console.Write("\n Nhập lựa chọn : ");
                choice = int.Parse(Console.ReadLine());
                switch( choice )
                {
                    case 1: t.Input(); break;
                    case 2: t.DuyetNLR(); break;
                    case 3: t.DuyetLNR(); break;
                    case 4: t.DuyetLRN(); break;
                    case 5: t.PrintLevel(); break;
                    case 6:
                        Console.Write("Nhập giá trị cần tìm : ");
                        int x = int.Parse(Console.ReadLine());
                        bool kq = t.Contains(x);
                        if (kq != true)
                            Console.WriteLine("Không tìm thấy !");
                        else Console.WriteLine("Tìm thấy !");
                        break;
                    case 7:
                        Console.Write("Nhập giá trị cần xóa : ");
                        x = int.Parse(Console.ReadLine());
                        t.RemoveX(x);
                        t.PrintLevel();
                        break;
                }
            } while (choice != 0);
        }
    }
}
