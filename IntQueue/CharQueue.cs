using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntQueue
{
    internal class CharQueue
    {
        private char[] array;
        private int front;
        private int rear;
        private int max;
        private int count;

        public CharQueue() { }
        public CharQueue(int m = 100)
        {
            max = m;
            array = new char[m];
            front = -1;
            rear = -1;
            count = 0;
        }

        public bool IsEmpty() => count == 0;
        public bool IsFull() => count == max;

        public bool EnQueue( char x )
        {
            if (IsFull()) return false;
            if (IsEmpty()) front = 0;
            rear = (rear + 1) % max;
            array[rear] = x;
            count++;
            return true;
        }

        public bool DeQueue(out char outItem)
        {
            outItem = '\0';
            if(IsEmpty()) return false;

            outItem = array[front];

            if (front == rear)
                front = rear = -1;
            else
                front = (front + 1) % max;

            count--;
            return true;
        }
    }
}
