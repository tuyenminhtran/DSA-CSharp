using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntStack
{
    internal class Doan
    {
        // attributes
        private int left;
        private int right;

        // properties
        public int Left {  get => left; set => left = value; }
        public int Right { get => right; set => right = value; }

        // constructor
        public Doan() {}
        public Doan( int left, int right)
        {
            this.left = left;
            this.right = right;
        }

        // method
    }
}
