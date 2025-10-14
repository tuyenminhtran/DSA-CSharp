using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSLKDon
{
    internal class MyList
    {
        // 1. attributes
        private IntNode head;   // note đầu danh sách
        private IntNode tail;
        private int count;      // số lượng phần tử

        // 2. properties
        public IntNode Head { get { return head; } set { head = value; } }
        public IntNode Last {  get { return tail; } set { tail = value; } } 
        public int Count { get { return count; } set { count = value; } }

        // 3. constructors
        public MyList()
        {
            head = null;
            tail = null;
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
            if ( head == null )
            {
                Console.WriteLine("Danh sách rỗng!");
                return;
            }
            Console.WriteLine("Danh sách hiện tại: ");
            IntNode temp = head;
            while ( temp != null )
            {
                Console.Write(temp.Data + " ");
                temp = temp.Next;
            }
            Console.WriteLine();
        }

        // tìm node có giá trị x

        public IntNode SearchX ( int x )
        {
            IntNode temp = head;
            while ( temp != null )
            {
                if (temp.Data == x)
                    return temp;
                temp = temp.Next;
            }
            return null;            // không tìm thấy
        }

        // lấy node có giá trị lớn nhất
        public IntNode GetMax()
        {
            if (head == null) return null;
            IntNode maxNode = head; 
            IntNode temp = head.Next;

            while ( temp != null )
            {
                if (temp.Data > maxNode.Data)
                    maxNode = temp;
                temp = temp.Next;
            }
            return maxNode;
        }

        // lấy node có giá trị nhỏ nhất 
        public IntNode GetMin()
        {
            if (head == null) return null;
            IntNode minNode = head;
            IntNode temp = head.Next;

            while ( temp != null )
            {
                if (temp.Data < minNode.Data)
                    minNode = temp;
                temp = temp.Next;
            }
            return minNode;
        }

        // lấy danh sách các phần tử chẳn
        public MyList GetEvenList()
        {
            MyList evenList = new MyList();
            IntNode temp = head;

            while ( temp != null )
            {
                if (temp.Data % 2 == 0)
                    evenList.AddLast(temp.Data);
                temp = temp.Next;
            }
            return evenList;
        }

        // lấy danh sách phần tử lẻ 
        public MyList GetOddList()
        {
            MyList oddList = new MyList();
            IntNode temp = head;

            while (temp != null)
            {
                if (temp.Data % 2 != 0)
                    oddList.AddLast(temp.Data);
                temp = temp.Next;
            }
            return oddList;
        }

        
            // Phương thức nối hai danh sách liên kết lst1 và lst2 thành lst3
            public static MyList JoinList(MyList lst1, MyList lst2)
        {
            MyList lst3 = new MyList(); // Tạo danh sách mới để chứa kết quả

            // Sao chép các phần tử từ lst1 vào lst3
            IntNode node = lst1.Head;
            while (node != null)
            {
                lst3.AddLast(node.Data); // Thêm phần tử vào cuối lst3
                node = node.Next;        // Di chuyển đến phần tử tiếp theo
            }

            // Sao chép các phần tử từ lst2 vào lst3
            node = lst2.Head;
            while (node != null)
            {
                lst3.AddLast(node.Data);
                node = node.Next;
            }

            return lst3; // Trả về danh sách đã nối
            // tr oi kho qua v
        }
        // tính node trung bình cộng các node có giá trị lẻ

        public double TBLe()
        {
            int sum = 0, countLe = 0;
            IntNode temp = head;

            while ( temp != null )
            {
                if (temp.Data % 2 != 0) 
                { 
                    sum += temp.Data; 
                    countLe++; 
                }
                temp = temp.Next;
            }
            if (countLe == 0) return 0;
            return (double)sum / countLe;
        }

        // buổi 5 
        // 1 Input() viết lại hàm nhập các giá trị không trùng 
        public void InputUniqueHead()       // đầu danh sách không trùng, viết téng eng cho ngòu
        {
            int x;
            do
            {
                Console.Write("Giá trị ( 0 kết thúc ): ");
                int.TryParse(Console.ReadLine(), out x);
                if (x == 0) return;

                IntNode resultFind = SearchX(x);

                if (resultFind != null)
                    Console.WriteLine("Đã có node này trong danh sách ");
                else
                    AddFirst(x);
            } while (true);                 
        }

        public void InputUniqueTail()       // cuối danh sách không trùng 
        {
            int x;
            do
            {
                Console.Write("Giá trị ( 0 kết thúc ): ");
                int.TryParse(Console.ReadLine(), out x);
                if (x == 0) return;

                IntNode resultFind = SearchX(x);

                if (resultFind != null)
                    Console.WriteLine("Đã có node này trong danh sách ");
                else
                    AddLast(x);
            } while (true);
        }

        // 2.    remoteAt ( int i ) : xóa node tại vị trí thứ i 
        public int CountNode()
        {
            int count = 0;
            IntNode temp = head;
            while ( temp != null)
            {
                count++;
                temp = temp.Next;
            }    
            return count;
        }
        
        // 2b. tìm node trước 1 của node temp
        public IntNode SearchPreTemp(int tempData)
        {
            IntNode tempPre = null;
            for ( IntNode temp = head; temp != null; temp = temp.Next)
            {
                if ( temp.Data == tempData)
                    return tempPre; ;
                tempPre = temp;
            }
                return null;
        }
        // 2c. Tìm node tại vị trí i
        public IntNode SearchAt( int i )
        {
            int j = 0;
            for ( IntNode temp = head; temp != null; temp = temp.Next )
            {
                if (j == i)
                    return temp;
                j++;
            }
            return null;
        }

        // remove at
        public void RemoveAt( int i )
        {
            IntNode pDel = SearchAt( i );
            if ( pDel != null )
            {
                // nếu i == 0, xóa phần tử đầu tiên trong danh sách ( head )
                if ( pDel == head )
                {
                    head = pDel.Next;
                    pDel.Next = null;
                }
                // nếu i = chiều dài của chuỗi -1 thì xóa phần tử cuối chuỗi
                else if ( pDel == tail)
                {
                    // tìm phần tử trước pDel, đặt tên là pPRe
                    IntNode pPre = SearchAt(pDel.Data);

                    // cập nhật giá trị last = pPre, gán pDel.Next = null;
                    tail = pPre;
                    pPre.Next = pDel.Next;
                    pDel.Next = null;
                }
            }
        }

        // RemoveX() xóa node có giá trị x
        public void RemoveX ( int x )
        {
            IntNode pDel = SearchX(x);
            if ( pDel != null )
            {
               // a. nếu pDel = là nút head, remove phần tử đầu tiên trong danh sách ( head )
               if ( pDel == head )
                {
                    head = pDel.Next;
                    pDel.Next = null;
                }else if ( pDel == tail )   // nếu pDel = tail, remove phần tử cuối chuỗi
                {
                    // tìm phần tử trước pDel, đặt tên biến là pPre
                    IntNode pPre = SearchPreTemp(pDel.Data);

                    // cập nhật giá trị tail = pPre, gán pDel.Next = null;
                    tail = pPre;
                    pPre.Next = null;
                    pDel.Next = null;
                } else      // node xóa nằm ở giữa 
                { 
                    // tìm phẩn tử trước pDel, đặt tên biến là pPre 
                    IntNode pPre = SearchPreTemp( pDel.Data);

                    // cập nhật 
                    pPre.Next = pDel.Next;
                    pDel.Next = null;
                }

            }

        }
    }
}

