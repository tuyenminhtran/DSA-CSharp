using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSLKDon
{
    internal class IntNode
    {
        // 1. attributes 
        private int data;
        private IntNode next = null;

        // 2. properties
        public int Data { get { return data; } set { data = value; } }
        public IntNode Next { get { return next; } set { next = value; } }

        // 3. constructor 
        public IntNode() { }
        public IntNode( int x = 0)
        {
            data = x;
            next = null;
        }
        public IntNode( int d, IntNode n )
        {
            data = d;
            next = n;
        }
        // 4. method
    }
}
