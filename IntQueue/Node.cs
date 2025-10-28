using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntQueue
{
    internal class Node
    {
        // attiributes
        private int data;
        private Node next;

        // properties
        public int Data { get => data; set => data = value; }
        public Node Next { get => next; set => next = value; }

        // constructor
        public Node() { }
        public Node( int x)
        {
            data = x;
            next = null;
        }
    }
}
