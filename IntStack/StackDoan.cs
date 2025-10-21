using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace IntStack
{
    internal class StackDoan
    {
        // attributes
        private NodeDoan top;

        // properties
        public NodeDoan Top {  get => top; set => top = value; }

        // constructor
        public StackDoan() { top = null; }

        // method
        public bool IsEmpty()
        {
            return top == null;
        }
        public bool Push( Doan x )
        {
            // last in first out 
            NodeDoan newNode = new NodeDoan(x.Left, x.Right);
            newNode.Next = top;
            top = newNode;
            return true;
        }

        public bool Pop( out Doan outItem )
        {
            outItem = null;
            if (IsEmpty())
                return false;
            else
            {
                NodeDoan p = top;
                outItem = p.Data;
                top = p.Next;
                p.Next = null;
                return true;
            }
        }
        public bool GetTop ( out Doan outItem )
        {
            outItem = null;
            if (IsEmpty())
                return false;
            else
            {
                outItem = top.Data;
                return true;
            }
        }

        // yêu cầu 4 : sử dụng StackDoan và IntArray | QuickSort để sắp xếp mảng 1 chiều
        // hoán vị 2 số nguyên
        public void HoanVi( ref int x, ref int y )
        {
            int temp = x;
            x = y;
            y = temp;
        }
        public void QuickSort_NonRecursive(int[] mangA)
        {
            // tạo 1 ngăn xếp rỗng để lưu các đoạn right left cần sắp xếp
            StackDoan stkDoan = new StackDoan();

            // bước 1: đưa toàn bộ mảng vào stack
            Doan doan1 = new Doan(0, mangA.Length - 1);
            stkDoan.Push(doan1);

            // bước 2: lặp cho đến khi stack rỗng ( không còn đoạn nào cần sắp )
            while (!stkDoan.IsEmpty())
            {
                // lấy ra đoạn ở đỉnh stack để xử lí
                Doan current;
                stkDoan.Pop(out current);
                int left = current.Left;
                int right = current.Right;

                // nếu đoạn có ít nhất 2 phần tử thì mới cần sắp xếp
                if (left < right)
                {
                    // == chia đoạn bằng thuật toán partition ==
                    // sau khi partition, pivot nằm đúng vị trí
                    // các phần tử bên trái nhỏ hơn pivot ( phần tử mid ), bên phải lớn hơn pivot 
                    int pivotIndex = Partition(mangA, left, right );

                    // == đưa các đoạn con còn lại vào stack ==
                    // đầu tiên là đoạn bên trái ( nếu có ít nhất 2 phần tử
                    if (pivotIndex -1 > left )
                    {
                        Doan leftSegment = new Doan(left, pivotIndex - 1);
                        stkDoan.Push(leftSegment);
                    }

                    // sau đó là bên phải ( nếu có ít nhất 2 phần tử )
                    if ( pivotIndex + 1 < right)
                    {
                        Doan rightSegment = new Doan( pivotIndex + 1, right );
                        stkDoan.Push(rightSegment);
                    }

                    // lưu ý :
                    // việc push cả 2 đoạn vào stack sẽ giúp vòng lặp xử lsy dần dần
                    // giống như với việc gọi đệ quy QuickSort 2 lần trong cách cài đặt thông thường
                }
            }
        }

        public int Partition(int[] mangA, int left, int right)
        {
            int pivot = mangA[right];
            int i = left - 1;
            
            // duyệt các phần tử left --> right - 1
            for ( int j = left; j < right; j++ )
            {
                if (mangA[j] <= pivot )
                {
                    // nếu phẩn tử hiện tại nhỏ hơn hoặc bằng pivot 
                    i++;
                    // đưa phần tử nhỏ lên trước pivot
                    HoanVi(ref mangA[i], ref mangA[j]);
                }            
            }

            // đưa pivot vào đúng vị trí giữa 2 vùng
            HoanVi(ref mangA[i + 1], ref mangA[right]);
            return i + 1;
        }
    }
}
