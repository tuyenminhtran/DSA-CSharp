using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntStack
{
    internal class NodeDoan
    {
        // attributes
        private Doan data;
        private NodeDoan next;

        // properties
        public Doan Data { get => data; set => data = value; }
        public NodeDoan Next { get => next; set => next = value; }

        // constructor
        public NodeDoan() { }
        public NodeDoan ( Doan d )
        {
            data = new Doan(d.Left, d.Right);
            next = null;
        }
        public NodeDoan( int l, int r)
        {
            data = new Doan(l, r);
            next = null;
        }
    }
}
