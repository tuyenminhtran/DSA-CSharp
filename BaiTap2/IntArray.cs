using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using System.Text;
using System.Threading.Tasks;

namespace BaiTap2
{
    internal class IntArray
    {
        // atributes
        private int[] arr;

        // properties
        public int[] Arr
        {
            get { return arr; } set { arr = value; }
        }
        // constructor 
        public IntArray() { }
        //parameter 1
        //truyền vào kích thước k để phát sinh ngẫu nhiên k giá trị
        public IntArray( int k )
        {
            Random rand = new Random();
            this.arr = new int[k];
            for (int i = 0; i < k; i++)
                this.arr[i] = rand.Next(1, 201);
        }
        // parameter 2
        public IntArray(int[] a)
        {
            // truyền vào 1 mảng 1 chiều a cần sao chép
            this.arr = new int[a.Length];
            for (int i = 0; i < a.Length; i++)
                this.arr[i] = a[i];
        }
        // copy 
        public IntArray( IntArray obj )
        {
            // copy truyền vào đối tượng mảng obj cần sao chép
            this.arr = new int[obj.arr.Length];
            for (int i = 0; i < obj.arr.Length; i++)
                this.arr[i] = obj.arr[i];
        }
        // method
        // kiểm tra kích thước 
        public bool KiemTraKT ( int n )
        {
            if (n >= 1 && n <= 1000000)
                return true;
            return false;
        }
        public void Input()
        {
            int n;
            do
            {
                Console.Write("Nhập n : ");
                n = int.Parse(Console.ReadLine());

            } while (KiemTraKT(n) == false);
            arr = new int[n];
                for ( int i = 0; i < n; i++)
            {
                Console.Write($"Nhập phần tử thứ {i}");
                arr[i] = int.Parse(Console.ReadLine());
            }
        }
        public void Output()
        {
            for ( int i = 0; i < arr.Length; i++)
                Console.Write(arr[i] + " ");
            Console.WriteLine();
        }

        public int LinearSearch (int x)
        {
            for ( int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == x)
                    return i;
            }
            return -1;
        }
        public int BinarySearch( int x)
        {
            int left = 0;
            int right = arr.Length - 1;
            int mid;
            while (left <= right)
            {
                mid = (left + right) / 2;
                if (arr[mid] == x)
                    return mid;
                else if (arr[mid] > x)
                    return right = mid - 1;
                else
                    return left = mid + 1;
            }
            return -1;
        }
        
        // tìm trả về phần tử lớn nhất trong mảng 
        // nếu trùng thì lấy phần tử sau cùng
        public int TimViTriMaxCuoiCung()
        {
            int ViTriMax = 0;
            for (int i = 0; i < arr.Length; i++)
                if (arr[i] >= arr[ViTriMax])
                    ViTriMax = i;
            return ViTriMax;
        }

        // xóa phần tử
        public void XoaPhanTu_X ( int x )
        {
            int ViTriX = LinearSearch(x);
            if ( ViTriX == -1 )
            {
                Console.WriteLine("Không tìm thấy x ");
            } else
            {
                // tìm thấy, tiến hành xóa
                // tạo mảng mới  newArr  có n - 1 phần tử
                int[] newArr = new int[arr.Length - 1];
                int j = 0;
                // chép từ 0 -> vị trí < ViTriX
                for ( int i = 0; i < ViTriX; i++)
                {
                    newArr[j] = arr[i];
                    j++;
                }
                // chép từ vị trí viTriX + 1 -> hết mảng
                for ( int i = ViTriX + 1; i < arr.Length; i++)
                {
                    newArr[j] = arr[i];
                    j++;
                }
                // gắn lại mảng newArr cho mảng arr
                arr = newArr;
            }    
        }
        // chèn thêm phần tử có giá trị x vào sau phần tử 
        // có giá trị lớn nhất trong mảng
        // nếu trùng giá trị lớn nhất thì chỉ cần chèn vào phần tử lớn nhất cuối cùng
        public void ChenThemPhanTu_X ( int x )
        {
            int ViTriMaxCuoiCung = TimViTriMaxCuoiCung();
            // tạo mảng mới newArr có n+1 phần tử
            int[] newArr = new int [ arr.Length + 1];
            int j = 0;
            //chép từ 0 -> vị trí max cuối cùng trong mảng
            for ( int i = 0; i < ViTriMaxCuoiCung; i++)
            {
                newArr[j] = arr[i];
                j++;
            }
            // chép x
            newArr[j] = x;
            j++;

            // chép từ vị trí max cuối cùng trong mảng + 1 -> đến hết mảng
            for ( int i = ViTriMaxCuoiCung + 1; i < arr.Length; i++)
            {
                newArr[j] = arr[i];
                j++;
            }
            // gắn lại mảng 
            arr = newArr;
        }
        // hoán vị 2 số nguyên
        public void HoanVi( ref int x, ref int y)
        {
            int temp = x;
            x = y;
            y = temp;
        }

        // sắp xếp theo phương pháp đổi chỗ trực tiếp - InterChangeSort 
        public void InterChangeSort()
        {
            for ( int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[i] > arr[j] )
                        HoanVi(ref arr[i], ref arr[j]);
                }
            }
        }

        // sắp xếp theo phương pháp bubble sort
        public void BubbleSort()
        {
            for ( int i = 0; i < arr.Length - 1; i++)
            {
                for ( int j = arr.Length -1; j > i; j--)
                {
                    if (arr[j] < arr[j - 1])
                        HoanVi(ref arr[j], ref arr[j - 1]);
                }
            }
        }

        // sắp xếp theo phương pháp chọn trực tiếp - Selection Sort
        public void SelectionSort()
        {
            int vtmin;
            for ( int i = 0; i < arr.Length - 1; i++)
            {
                vtmin = i;
                for ( int j = i + 1; j < arr.Length; j++)
                {
                    // nếu giá trị phần tử tại vtnin a[vtmin] > a[j]
                    // thì vtmin cập nhật lại thành j
                    if (arr[vtmin] > arr[j])
                        vtmin = j;
                }
                // tiến hành hoán vị giá trị tại vtmin với a[i]
                HoanVi(ref arr[i], ref arr[vtmin]);
            }
        }
        // sắp xếp theo phương pháp chèn trực tiếp - insertion sort
        public void InsertionSort()
        {
            int x, pos;
            for ( int i = 0; i < arr.Length; i++)  // lấy phần tử để chèn
            {
                x = arr[i];                            // lấy phần tử hiện tại cần chèn
                pos = i - 1;                           // vị trí cuối cùng của dãy đã sắp xếp ( bên trái x)
                while ( pos >= 0 && arr[pos] > x)      // nếu phần tử bên trái lớn hơn x
                {
                    //kết hợp dời chỗ các phần tử đứng sau x trong dãy mới
                    arr[pos + 1] = arr[pos];            // dời phần tử sang phải
                    pos--;                              // tiếp tục so sánh với phần tử tiếp theo bên trái
                } 
                arr[pos + 1] = x; //chèn x vào dãy mới
            }      
        }

        // sắp xếp theo phương pháp QuickSort
        // mạnh nhất trong đám " chia để trị " (devide & conquer) | nghe ngầu ta =)))
        public void QuickSort(int left, int right)
        {
            int x = arr[(left + right) / 2];
            int i = left, j = right;
            while (i < j)
            {
                while (arr[i] < x) i++;
                while (arr[j] > x) j--;
                if ( i <= j )
                {
                    HoanVi(ref arr[i], ref arr[j]);
                    i++;
                    j--;
                }
                if (i < right) QuickSort(i, right);
                if (left < j) QuickSort(left, j);
            }
        }
    }
}


// test git add .