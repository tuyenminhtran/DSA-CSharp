using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IntAVLTree
{
    internal class MyAVLTree
    {
        private IntNode root;
        public IntNode Root { get => root; set { root = value; } }
        public MyAVLTree()
        {
            root = null;
        }
        public void Insert(int x )
        {
            if (root == null) root = new IntNode(x);
            else Root = Root.Insert(Root, x);
        }

        public void RemoveX ( int x)
        {
            Root = Root.Delete(Root, x);
        }

        public bool Contains ( int x )
        {
            return Root.Search(Root, x) != null;
        }
        public void Input()
        {
            while ( true )
            {
                Console.Write("Nhập số : ");
                int x = int.Parse(Console.ReadLine());
                if ( root != null )
                {
                    if ( Contains(x))
                    {
                        Console.WriteLine($"Giá trị {x} đã tồn tại - Dừng Nhập - ");
                        break;
                    }
                }
                Insert(x);
            }
        }

        public void DuyetNLR()
        {
            if (root == null) return;
            root.NLR(root);
        }

        public void DuyetLNR()
        {
            if (root == null) return;
            root.LNR(root);
        }

        public void DuyetLRN()
        {
            if (root == null) return;
            root.LRN(root);
        }

        public void PrintLevel()
        {
            if ( root == null)
            {
                Console.WriteLine("Cây rỗng ");
                return;
            }

            Queue<IntNode> q = new Queue<IntNode>();
            q.Enqueue(root);
            int level = 0;
            while ( q.Count > 0 )
            {
                int count = q.Count;
                Console.Write($"Level : {level}");

                while ( count > 0 )
                {
                    IntNode p = q.Dequeue();
                    Console.Write(p.Data + " ");

                    if (p.Left != null) q.Enqueue(p.Left);
                    if (p.Right != null) q.Enqueue(p.Right);
                    count--;
                }
                Console.Write('\n');
                level++;
            }
        }
    }
}
