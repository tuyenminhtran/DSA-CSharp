using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntBST
{
    internal class IntNode
    {

        // attribute
        private int data;
        private IntNode left;
        private IntNode right;

        // properties

        public int Data { get => data; set => data = value; }
        public IntNode Left { get => left; set => left = value; }
        public IntNode Right { get => right; set => right = value; }

        // constructor
        public IntNode() { }
        public IntNode( int x )
        {
            data = x;
            left = null;
            right = null;
        }

        // method
        // thêm node vào cây nhị phân -- INSERT --
        public bool InsertNode( int x )
        {
            // trùng giá trị đã có trong cây nhị phân
            if (this.data == x) return false;
            else
            {
                // Giá trị thêm nhỏ hơn thì chèn về trái
                if ( this.data > x )
                {
                    if ( left == null )
                    {
                        IntNode newNode = new IntNode(x);
                        left = newNode;
                    } else return left.InsertNode(x);
                }
                else
                {
                    // Giá trị cần thêm lớn hơn thì chèn về bên phải 
                    if (right == null) right = new IntNode(x);
                    else return right.InsertNode(x);
                }
                return true;               
            }     
        }

        // Duyệt cây
        // -- NLR -- duyệt cây theo thứ tự trước
        public void NLR()
        {
            Console.Write(data + " : ");
            if ( left != null ) left.NLR();
            if ( right != null ) right.NLR();
        }

        // -- LNR -- duyệt cây theo thứ tự giữa 
        public void LNR()
        {
            if ( left != null ) left.LNR();
            Console.Write(data + " : ");
            if ( right != null ) right.LNR();
        }

        // -- LRN -- duyệt cây theo thứ tự sau 
        public void LRN()
        {
            if ( left != null ) left.LRN();
            if ( right != null ) right.LRN();
            Console.Write(data + " : ");
        }

        // tìm Node có giá trị x 
        public IntNode SearchX( int x )
        {
            // nếu node hiện tại có giá trị bằng x
            // thì trả về chính node đó
            if (data == x) return this;

            // nếu x nhỏ hơn giá trị hiện tại
            if ( x < data )
            {
                // nếu không có cây con bên trái thì return null
                if (left == null) return null;

                // ngược lại nếu có thì tìm tiếp trong cây con trái
                return left.SearchX(x);
            } 
            else
            {
                // nếu không tìm thấy cây con phải return null
                if (right == null) return null;

                // ngược lại tìm tiếp trong cây con phải
                return right.SearchX(x);
            }    
        }

        public IntNode RightMost()
        {
            // kiểm tra nếu node hiện tại không có con phải
            // thì nó là node ngoài cùng bên phải 

            // trả về node hiện tại vì nó là node phải nhất
            if (right == null) return this;

            // ngược lại nếu không phải thì gọi lại hàm
            return right.RightMost();
        }
        
        public IntNode LeftMost()
        {
            if (left == null) return this;
            return left.LeftMost();
        }

        public bool RemoveX( int x, ref IntNode root )
        {
            IntNode parent = null;      // node cha để nối lại sau khi xóa
            IntNode current = root;     // bắt đầu từ gốc

            // tìm node có giá trị x 
            while ( current != null && current.data != x )
            {
                parent = current;
                if (x < current.data) current = current.left;
                else current = current.right;
            }

            // nếu không tìm thấy node có giá trị x thì xóa thất bại
            if (current == null) return false;

            // trường hợp 1 : Node là lá ( hong có con )
            if (current.left == null && current.right == null)
            {
                // node bị xóa là gốc
                if (parent == null) root = null;

                else if (parent.left == current) parent.left = null;

                else parent.right = null;
            }

            // trường hợp 2 : Node có 1 con ( left or right )
            else if (current.left == null || current.right == null)
            {
                IntNode child = (current.left != null) ? current.left : current.right;

                // Node gốc bị xóa, thay bằng con 
                if (parent == null) root = child;

                else if (parent.left == current) parent.left = child;

                else parent.right = child;
            }

            // trường hợp 3 : Node có 2 con
            else
            {
                // tìm node nhỏ nhất bên phải ( successor )
                IntNode successorParent = current;
                IntNode succcessor = current.right;

                while ( successorParent.Left != null )
                {
                    successorParent = succcessor;
                    succcessor = successorParent.Left;
                }

                // copy value successor vào node hiện tại 
                current.data = succcessor.data;

                // xóa node successor 
                if (successorParent.left == succcessor)
                    successorParent.left = succcessor.right;
                else
                    successorParent.right = succcessor.right; 

                // mô phật tới thi đừng ra dạng này
            }
            // xóa thành công 
            return true;
        }
    }
}
