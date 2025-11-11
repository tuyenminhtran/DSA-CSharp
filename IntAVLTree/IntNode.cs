using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntAVLTree
{
    internal class IntNode
    {
        private int data;
        private IntNode left;
        private IntNode right;
        private int height;

        public int Data { get => data; set => data = value; }
        public IntNode Left { get => left; set => left = value; }
        public IntNode Right { get => right; set => right = value; }
        public int Height { get => height; set => height = value; }

        public IntNode ( int x )
        {
            data = x;
            Height = -1;
        }

        private int GetHeight( IntNode p )
        {
            if ( p == null ) return 0;
            else return p.Height;
        }

        private int GetBalance ( IntNode p )
        {
            if ( p == null ) return 0;
            else return GetHeight(p.Left) - GetHeight(p.Right);
        }

        private IntNode RightRotate ( IntNode y )
        {
            IntNode x = y.Left;
            IntNode T2 = y.Right;
            x.Right = y;
            y.Left = T2;
            y.Height = Math.Max(GetHeight(y.Left), GetHeight(y.Right)) + 1;
            x.Height = Math.Max(GetHeight(x.Left), GetHeight(x.Right)) + 1;
            return x;
        }

        private IntNode LeftRotate ( IntNode x )
        {
            IntNode y = x.Right;
            IntNode T2 = y.Left;
            y.Left = x;
            x.Right = T2;
            x.Height = Math.Max(GetHeight(x.Left), GetHeight(x.right)) + 1;
            y.Height = Math.Max(GetHeight(y.Left), GetHeight(y.Right)) + 1;
            return y;
        }

        public IntNode Insert( IntNode root, int x)
        {
            if (root == null) return new IntNode(x);
            if (x < root.data) root.Left = Insert(root.Left, x);
            else if (x > root.data) root.Right = Insert(root.Right, x);
            else return root;
            root.Height = 1 + Math.Max(GetHeight(root.Left), GetHeight(root.Right));
            int balance = GetBalance(root);
            if( balance > 1 && x < root.Left.data )
                return RightRotate(root);
            if ( balance < -1 && x >  root.Right.data )
                return LeftRotate(root);
            if ( balance > 1 && x > root.Left.data )
            {
                root.Left = LeftRotate(root.Left);
                return RightRotate(root);
            }
            if ( balance < -1 && x < root.Right.data )
            {
                root.Right = RightRotate(root.Right);
                return LeftRotate(root);
            }
            return root;
        }

        private IntNode MinValueNode( IntNode node )
        {
            IntNode cur = node;
            while ( cur != null ) 
                cur = cur.Left;
            return cur;
        }

        public IntNode Delete( IntNode root, int x )
        {
            if (root == null) return root;
            if ( x < root.data ) root.Left = Delete(root.Left, x);
            else if ( x > root.data ) root.Right = Delete(root.Right, x);
            else
            {
                if ( root.Left == null || root.Right == null )
                {
                    IntNode temp;
                    if ( root.Left != null )
                        temp = root.Left;
                    else temp = root.Right;
                    root = temp;
                }
                else
                {
                    IntNode temp = MinValueNode(root.Right);
                    root.data = temp.data;
                    root.Right = Delete(root.Right, temp.data);
                }
            }
            if ( root == null ) return root;
            root.Height = Math.Max(GetHeight(root.Left), GetHeight(root.Right)) + 1;
            int balance = GetBalance(root);

            if (balance > 1 && GetBalance(root.Left) >= 0) return RightRotate(root);
            if ( balance > 1 && GetBalance(root.Left) < 0 )
            {
                root.Left = LeftRotate(root.Left);
                return RightRotate(root);
            }
            if ( balance < -1 && GetBalance(root.Right) <= 0) return LeftRotate(root);
            if ( balance < -1 && GetBalance(root.Right) > 0 )
            {
                root.Right = RightRotate(root.Right);
                return LeftRotate(root);
            }
            return root;
        }

        public IntNode Search ( IntNode p, int x )
        {
            if ( p == null ) return null;
            if ( x == p.data ) return p;
            if (x < p.data) return Search(p.Left, x);
            else return Search(p.Right, x);
        }

        public void NLR(IntNode p)
        {
            if (p == null) return;
            Console.Write(p.Data + " ");
            NLR(p.Left);
            NLR(p.Right);
        }

        public void LNR ( IntNode p )
        {
            if ( p == null ) return;
            LNR(p.Left);
            Console.Write(p.Data + " ");
            LNR(p.Right);
        }

        public void LRN ( IntNode p )
        {
            if (p == null) return;
            LRN(p.Left);
            LRN(p.Right);
            Console.Write(p.Data + " ");
        }
    }
}
