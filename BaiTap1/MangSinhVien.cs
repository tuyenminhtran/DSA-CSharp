using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTap1
{
    internal class MangSinhVien
    {
        private SinhVien[] a;
        public SinhVien[] A { get { return a; } set { a = value; } }
        public MangSinhVien(SinhVien[] mangSV)
        {
            this.a = mangSV;
        }
        public MangSinhVien() { }

        // method
        public void Nhap()
        {
            int n = 0;
            do
            {
                Console.Write("Nhập số lượng sinh viên : ");
                n = int.Parse(Console.ReadLine());
            } while (n <= 0 || n >= 1000000);
            // creat array 
            a = new SinhVien[n];
            for (int i = 0; i < a.Length; i++)
            {
                Console.WriteLine();
                Console.WriteLine($"Nhap thong tin cho sinh vien thu {i + 1}");
                a[i] = new SinhVien();
                a[i].Input();
            }
        }
        public void Xuat()
        {
            Console.WriteLine();
            for (int i = 0; i < a.Length; i++)
            {
                Console.WriteLine();
                Console.WriteLine($"Xuat thong tin sinh vien thu {i + 1}");
                a[i].Output();
            }
        }
        public bool TonTai(string msx, int vt)
        {
            for (int i = 0; i < vt; i++)
            {
                if (a[i].MaSo.CompareTo(msx) == 0)
                    return true;
            }
            return false;
        }

        public void Nhap_CoKT()
        {
            Console.Write("Nhap so luong SV, n: ");
            int n = int.Parse(Console.ReadLine());
            a = new SinhVien[n];
            //Nhap thong tin cua tung SV
            for (int i = 0; i < a.Length; i++)
            {
                Console.Write("Nhap ma so SV: ");
                string msv = Console.ReadLine();
                while (TonTai(msv, i))
                {
                    Console.Write("Ma so bi trung, nhap lai: ");
                    msv = Console.ReadLine();
                }
                a[i] = new SinhVien();
                a[i].MaSo = msv;
                Console.Write("Nhap ho ten: ");
                a[i].HoTen = Console.ReadLine();
                Console.Write("Nhap nam sinh: ");
                a[i].NamSinh = int.Parse(Console.ReadLine());
                Console.Write("Nhap diem TB: ");
                a[i].DiemTB = float.Parse(Console.ReadLine());
                a[i].XepLoai();
            }
        }
        //  sắp xếp danh sách sinh viên theo thứ tự tăng dần của mã số theo phương pháp chọn trực tiếp
        public void SapXep_MSSV_SelectionSort()
        {
            int vtmin; // lưu vị trí phần tử nhỏ nhất
            for ( int i = 0; i < a.Length - 1; i++)                         // duyệt phần tử nè
            {
                vtmin = i;                                                  // gán giá phần tử nhỏ nhất là a[i]
                for ( int j = i + 1; j < a.Length; j++)                     // duyệt phần tử phía sau
                {
                    //nếu giá trị phần tử tại vtmin a[vtmin] > a[j] thì vtmin cập nhật lại thành j
                    if (string.Compare(a[vtmin].MaSo, a[j].MaSo) > 0)       //  Compare so sánh 
                        vtmin = j;                                          // cập nhật vị trí nhỏ nhất
                }
                // tiến hành hoán đổi vị trí giá trị tại a[vtmin] với a[i]
                SinhVien temp = new SinhVien(a[i]);
                a[i] = new SinhVien(a[vtmin]);
                a[vtmin] = new SinhVien(temp);
            }
        }

        // sắp xếp danh sách sinh viên theo thứ tự giảm dần của điểm trung bình 
        // theo phương pháp chèn trực tiếp ( Insertion Sort )
        public void SapXep_DiemTB_InsertionSort()
        {
            SinhVien x;
            int pos;
            for ( int i = 0; i < a.Length; i++)
            {
                x = new SinhVien(a[i]);         // lấy sinh viên hiện tại để chèn
                pos = i - 1;                    // lấy sinh viên đứng trước i
                while ( pos >= 0 && a[pos].DiemTB < x.DiemTB )
                {
                    a[pos + 1] = new SinhVien(a[pos]);              // tăng sinh viên phía trước lên 1 bậc
                    pos--;
                }
                // chèn x vào dãy mới
                a[pos + 1] = new SinhVien(x); 
            }
        }
    }
}
