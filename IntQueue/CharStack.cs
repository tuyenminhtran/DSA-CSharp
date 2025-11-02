using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntQueue
{
    internal class CharStack
    {
        private char[] array;
        private int top;
        private int max;

        public CharStack(int m = 100)
        {
            max = m;
            array = new char[m];
            top = -1;
        }

        public bool IsEmpty() => top == -1;
        public bool IsFull() => top == max - 1;

        public bool Push(char x)
        {
            if (IsFull()) return false;
            array[++top] = x;
            return true;
        }

        public bool Pop(out char outItem)
        {
            outItem = '\0';
            if (IsEmpty()) return false;
            outItem = array[top--];
            return true;
        }
    }
}
