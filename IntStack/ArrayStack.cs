using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntStack
{
    internal class ArrayStack
    {
        // attributes
        private int max;
        private int top;
        private int[] array;

        // properties
        public int[] Array { get { return array; } set { array = value; } }
        public int Max { get { return max; } set { max = value; } }
        public int Top { get { return top; } set { top = value; } }

        /// constructor 
        public ArrayStack() { }
        public ArrayStack ( int m )
        {
            max = m;
            top = -1;
            array = new int[m];
        }
        // methods
        // kiểm tra stack đầy 
        public bool IsFulll()
        {
            if (top == max - 1)
                return true;
            return false;
        }
        
        // kiểm tra stack rỗng
        public bool IsEmpty()
        {
            return top == -1;
        }

        // đẩy 1 phần tử vào stack
        public bool Push( int inItem)
        {
            if( IsFulll())
            return false;
            else
            {
                top++;
                array[top] = inItem;
                return true;
            }
        }

        // lấy phần tử ra khỏi stack 
        public bool Pop( out int outItem )
        {
            outItem = 0;
            if ( IsEmpty())
                return false;
            else
            {
                outItem = array[top];
                top--;
                return true;
            }
        }

        public bool GetTop( out int outItem )
        {
            outItem = 0;
            if (IsEmpty())
                return false;
            else
            {
                outItem = array[top];
                return true;
            }
        }
    }
}
