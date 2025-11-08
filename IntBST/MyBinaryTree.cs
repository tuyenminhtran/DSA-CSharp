using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntBST
{
    internal class MyBinaryTree
    {
        // attributes
        private IntNode root;

        // properties
        public IntNode Root { get => root; set => root = value; }

        // method
        public MyBinaryTree()
        {
            root = null;
        }

        // tìm độ cao của cây
        public int HeightTree ( IntNode node )
        {
            if (node == null) return 0;
            int LeftHeight = HeightTree(node.Left);
            int RightHeight = HeightTree(node.Right);
            return Math.Max(RightHeight, LeftHeight) + 1;
        }

        // tìm node trong cây
        public int NodeCuaCay( IntNode node )
        {
            if (node == null) return 0;
            return 1 + NodeCuaCay(node.Left) + NodeCuaCay(node.Right); 
        }

        // Hàm input Nhập các giá trị vào cây từ bàn phím 
        // hàm insert nhập 1 node vào cây
        public bool Insert( int x )
        {
            if (root == null)
            {
                root = new IntNode(x);
                return true;
            }
            else 
                return root.InsertNode(x);
        }

        // nhập node cho cây
        public void Input()
        {
            do
            {
                int x;
                Console.Write("Nhập x : ");
                x = int.Parse(Console.ReadLine());
                if (Insert(x) == true)
                    Console.WriteLine($"Thêm thành công {x} vào cây ! ");
                else
                {
                    Console.WriteLine("Giá trị bị trùng !\n - Kết thúc - ");
                    break; 
                }    
            } while (true);
        }

        // duyệt cây
        public void PreOrder()
        {
            if ( root == null) return;
            root.NLR();
        }
        public void InOrder()
        {
            if (root == null) return;
            root.LNR();
        }
        public void PostOrder()
        {
            if (root == null) return;
            root.LRN();
        }

        // CountLeaf : trả về số lượng node lá trong cây 
        public int CountLeaf( IntNode node )
        {
            if ( node == null) return 0;
            if (node.Left == null && node.Right == null) return 1;
            return CountLeaf(node.Left) + CountLeaf(node.Right);
        }

        // ListByLevel : In ra giá trị các node theo từng mức 
        public void ListByLevel()
        {
            if ( Root == null ) return; // cây rỗng thì thoát 

            // Tạo 1 hàng đợi ( Queue ) để lưu các node sẽ duyệt 
            Queue<IntNode> q = new Queue<IntNode>();
            q.Enqueue(Root);        // đưa node gốc vào hàng đợi
            int level = 0;          // biến đếm cấp độ ( bắt đầu từ 0 )

            // vòng lặp chạy cho đến khi hàng đợi rỗng
            while ( q.Count > 0 )
            {
                int n = q.Count;    // số node trong mức hiện tại 
                Console.Write($"Level {level} " + " : ");

                // duyệt qua tất cả các node trong mức hiện tại 
                for ( int i = 0; i < n; i++ )
                {
                    IntNode node = q.Dequeue();   // lấy node đầu tiên ra 
                    Console.Write(node.Data + " ");

                    // nếu node có con trái thì thêm vào hàng đợi 
                    if (node.Left != null)
                        q.Enqueue(node.Left);

                    // nếu node có con phải thì thêm vào hàng đợi 
                    if ( node.Right != null )
                        q.Enqueue(node.Right);
                }
                Console.Write('\n');
                level++;
            }
        }

        // listlastlevel : In ra các giá trị ở mức cuối của cây
        public void ListLastLevel()
        {
            if (Root == null) return;

            // tại hàng đợi để duyệt BFS
            // sau đó đưa node gốc vào hàng đợi
            Queue<IntNode> q = new Queue<IntNode>();
            q.Enqueue(Root);

            // list dùng để lưu các node ở mức cuối cùng
            List<int> lastLevel = new List<int>();
            while ( q.Count > 0 )
            {
                int n = q.Count;                    // số node trong mức hiện tại
                lastLevel.Clear();                  // xóa danh sách cũ ( chỉ giữ mức hiện tại )
                for ( int i = 0; i < n; i++ )
                {
                    IntNode node = q.Dequeue();     // lấy node đầu tiên trong hàng đợi
                    lastLevel.Add(node.Data);       // ghi lại giá trị node

                    if (node.Left != null) q.Enqueue(node.Left);
                    if ( node.Right != null ) q.Enqueue(node.Right);
                }
            }

            // khi while kết thúc, biến lastLevel chứa các node ở mức cuối cùng
            Console.Write("Các Node ở mức cuối cùng : ");
            foreach (int val in lastLevel)
                Console.Write(val + " ");
            Console.Write('\n');
        }

        // Find x : tìm trả về node có giá trị x trong cây
        public IntNode FindX(int x)
        {
            if (root == null) return null;
            return root.SearchX(x);
        }

        // find min 
        public IntNode FindMin()
        {
            if (root == null) return null;
            return root.LeftMost();
        }

        // findmax
        public IntNode FindMax()
        {
            if ( root == null) return null;
            return root.RightMost();
        }

        // remove X
        public void Remove( int x )
        {
            bool kq = root.RemoveX(x, ref root);
            if (kq)
                Console.WriteLine("Xóa thành công !");
            else
                Console.WriteLine("Xóa không thành công !");
        }
    }
}
