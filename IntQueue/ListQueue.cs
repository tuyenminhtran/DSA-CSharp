using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntQueue
{
    internal class ListQueue
    {
        // attributes
        private Node front;
        private Node rear;

        // properties
        public Node Front { get => front; set => front = value; }
        public Node Rear { get => rear; set => rear = value; }

        // constructor 
        public ListQueue()
        {
            front = null;
            rear = null;
        }

        // method
        public bool IsEmpty()
        {
            return front == null;
        }
        public bool EnQueue(int newItem)
        {
            Node newNode = new Node(newItem);
            // thêm cuối danh sách
            if (IsEmpty()) front = rear = newNode;
            else
            {
                rear.Next = newNode;
                rear = newNode;
            }
            return true;
        }
        public bool DeQueue( out int outItem)
        {
            outItem = 0;
            if(IsEmpty()) return false;
            else
            {
                // lấy đầu danh sách 
                Node p = front;
                front = p.Next;
                p.Next = null;
                outItem = p.Data;
                return true;
            }
        }

        public bool GetFront(out int outItem)
        {
            // rút gọn
            if (IsEmpty()) { outItem = 0; return false; }   
            else
            {
                outItem = front.Data;
                return true;
            }
        }

        public bool GetRear(out int outItem)
        {
            if(IsEmpty()) { outItem = 0; return false; }
            else
            {
                outItem = rear.Data;
                return true;
            }
        }

        public void DisplayQueue()
        {
            Node p = front;
            while( p != null)
            {
                Console.Write(p.Data);
                if (p.Next != null) Console.Write(" : ");
                p = p.Next;
            }
        }
        public int Count()
        {
            int count = 0;
            Node p = front;
            while (p != null)
            {
                count++;
                p = p.Next;
            }
            return count;
        }
        public void RotateLeft(int k)
        {
            if (IsEmpty())
            {
                Console.WriteLine("Queue rỗng, không thể xoay.");
                return;
            }

            k = k % Count();
            for (int i = 0; i < k; i++)
            {
                if (DeQueue(out int frontItem))
                    EnQueue(frontItem);
            }
            Console.WriteLine($"Queue (List) đã xoay sang trái {k} lần.");
        }
    }
}
