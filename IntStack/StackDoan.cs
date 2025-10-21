using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
