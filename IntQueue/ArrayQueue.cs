using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntQueue
{
    internal class ArrayQueue
    {
        //attribute 
        // yêu cầu 3
        private int front;
        private int rear;
        private int[] array;
        private int max;
        private int count;

        // properties
        public int Front { get => front; set => front = value; }
        public int Rear { get => rear; set => rear = value; }
        public int Max { get => max; set => max = value; }
        public int[] Array { get => array; set => array = value; }
        public int Count { get => count; set => count = value; }

        // constructor 
        public ArrayQueue() { }
        public ArrayQueue(int m)
        {
            max = m;
            array = new int[m];
            front = -1;
            rear = -1;
            count = 0;
        }

        // method 
        public bool IsFull()
        {
            return (front == 0 && rear == max - 1) || ((rear + 1) % max == front);
        }

        public bool IsEmpty()
        {
            return front == -1;
        }

        // thêm phần tử vào Queue
        public bool EnQueue(int newItem)
        {
            if (IsFull()) return false;

            // sài toán tử 3 ngôi cho gọn 
            // dễ sai ngay đoạn này 
            if (IsEmpty()) front = 0;
            rear = (rear + 1) % max;
            array[rear] = newItem;
            count++;
            return true;
        }

        // lấy phần tử khỏi Queue
        public bool DeQueue(out int outItem)
        {
            outItem = 0;
            if (IsEmpty()) return false;

            outItem = array[front];

            if (front == rear)  // chỉ còn 1 phần tử
            {
                front = rear = -1;
            }
            else
            {
                front = (front + 1) % max;
            }

            count--;
            return true;
        }

        // lấy phần tử đầu Queue
        public bool GetFront(out int outItem)
        {
            outItem = 0;
            if (IsEmpty())
            {
                Console.WriteLine("Queue rỗng !");
                return false;
            }
            outItem = array[front];
            return true;
        }

        public bool GetRear(out int outItem)
        {
            outItem = 0;
            if (IsEmpty())
            {
                Console.WriteLine("Queue rỗng !");
                return false;
            }
            outItem = array[rear];
            return true;
        }

        // hiển thị toàn bộ Queue
        public void DisplayQueue()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Queue rỗng !");
                return;
            }

            Console.Write("Queue: ");
            int i = front;                        // bắt đầu từ phần tử đầu queue
            for (int c = 0; c < count; c++)       // lặp đúng số phần tử hiện có
            {
                Console.Write(array[i]);          // in ra phần tử hiện tại
                if (c != count - 1) Console.Write(" : ");
                i = (i + 1) % max;                // tăng chỉ số, nếu vượt quá max thì quay lại đầu
            }
            Console.WriteLine();
        }

        public void RotateLeft(int k)
        {
            if (IsEmpty())
            {
                Console.WriteLine("Queue rỗng, không thể xoay !");
                return;
            }

            // tối ưu: xoay nhiều hơn số phần tử thì chỉ cần xoay k % count lần
            k = k % count;

            for (int i = 0; i < k; i++)
            {
                DeQueue(out int frontItem);
                EnQueue(frontItem);
            }

            Console.WriteLine($"Đã xoay queue sang trái {k} lần !");
        }
    }
}
