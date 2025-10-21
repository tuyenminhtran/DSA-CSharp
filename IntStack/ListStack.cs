using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntStack
{
    internal class ListStack
    {
        // attributes
        private Node top;

        // properties
        public Node Top { get => top; set => top = value; }

        // constructor 
        public ListStack() { top = null; }

        // method 
        public bool IsEmpty()
        {
            return top == null;
        }
        public bool Push( int x )
        {
            // last in first out : chèn vào đầu danh sách => lấy ra cũng từ đầu danh sách
            Node newNode = new Node();
            newNode.Next = top;
            top = newNode;
            return true;
        }
    }
}
