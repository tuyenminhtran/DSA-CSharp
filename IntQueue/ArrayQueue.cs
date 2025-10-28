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
        int front;
        int rear;
        int[] array;
        int max;

        // properties
        public int Front { get => front; set => front = value; }
        public int Rear { get => rear; set => rear = value; }
        public int Max { get => max; set => max = value; }
        public int[] Array { get => array; set => array = value; }

        // constructor 
        public ArrayQueue() { }
        public ArrayQueue(int m)
        {
            max = m;
            array = new int[m];
            front = -1;
            rear = -1;
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

        public bool EnQueue(int newItem)
        {
            if (IsFull()) return false;

            // sài toán tử 3 ngôi cho gọn 
            // dễ sai ngay đoạn này 
            rear = IsEmpty() ? (front = 0) : (rear + 1) % max;
            array[rear] = newItem;
            return true;
        }

        public bool DeQueue(out int outItem)
        {
            outItem = 0;
            if(IsEmpty()) return false;

            if (front == 0 && rear == 0)   // queue chỉ 1 pần tử 
                front = rear = -1;
            else if (front == max - 1)
                front = 0;
            else front = ( front + 1 ) % max;

            return true;
        }

        public bool GetFront( out int outItem )
        {
            outItem = 0;
            if (IsEmpty())
            {
                Console.WriteLine("Queue rỗng !");
                return false;
            } else
            {
                outItem = array[front];
                return true;
            }
        }

        public bool GetRear( out int outItem)
        {
            outItem = 0;
            if(IsEmpty())
            {
                Console.WriteLine("Queue rỗng !");
                return false;
            }
            else
            {
                outItem = array[rear];
                return true;
            }
        }

        public void DisplayQueue()
        {
            if (IsEmpty()) Console.WriteLine("Queue rỗng !");
            else
            {
                // nếu rear chưa vượt qua kích thước tối đa
                // hoặc rear của hàng đợi vẫn lớn hơn front 
                if ( rear >= front )
                {
                    for( int i = front; i <= rear; i++ )
                        Console.Write( array[i] + " : ");
                }
                else
                {
                    // nếu rear vượt qua kích thước tối đa 
                    // việc đánh số bắt đầu lại từ đầu

                    // for để in các phần tử ở vị trí front
                    // đến kích thước tối đa hoặc chỉ số cuối cùng trong mảng 
                    for (int i = front; i <= max; i++)
                        Console.Write(array[i] + " : ");

                    // for để in các ptu chỉ số 0 cho đến vị trí rear
                    for (int i = 0; i <= rear; i++)
                        Console.Write(array[i] + " : ");
                }
            }
            Console.WriteLine();
        }
    }
}
