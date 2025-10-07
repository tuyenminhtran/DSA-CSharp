using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSLKDon
{
    internal class MyList
    {
        // 1. attributes
        private IntNode head;   // note đầu danh sách
        private int count;      // số lượng phần tử

        // 2. properties
        public IntNode Head { get { return head; } set { head = value; } }
        public int Count { get { return count; } set { count = value; } }

        // 3. constructors
        public MyList() { }
        public MyList()
        {
            head = null;
            count = 0;
        }

        // 4. method

        // thêm node có giá trị x vào đầu danh sách
        public void AddFirst( int x )
        {
            IntNode newNode = new IntNode(x);
            newNode.Next = head;                // trỏ code mới tới node đầu hiện tại
            head = newNode;                     // cập nhật node mới
            count++;
        }

        // thêm node có giá trị x vào cuối danh sách 
        public void AddLast( int x )
        {
            IntNode newNode = new IntNode(x);
            if ( head == null )
            {
                head = newNode;
            }
            else
            {
                IntNode temp = head;
                while ( temp.Next != null )
                {
                    temp = temp.Next;
                }
                temp.Next = newNode;
            }
            count++;
        }
        // nhập danh sách ( người dùng chọn thêm đầu hoặc cuối )
        public void Input()
        {
            Console.Write("Nhập số lượng phần tử : ");
            int n = int.Parse(Console.ReadLine());

            for ( int i = 0; i < n; i ++ )
            {
                Console.Write($"Nhập giá trị phần tử thứ {i + 1}: ");
                int x = int.Parse(Console.ReadLine());

                Console.Write("Thêm vào đầu (D) hay cuối (C)? ");
                char choice = char.ToUpper(Console.ReadKey().KeyChar);
                Console.WriteLine();

                if (choice == 'D')
                    AddFirst(x);
                else
                    AddLast(x);
                
            }
        }

        // hiển thị danh sách 
        public void ShowList()
        {

        }

    }
}
