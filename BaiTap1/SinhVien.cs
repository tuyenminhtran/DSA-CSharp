using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTap1
{
    internal class SinhVien
    {
        private string maSo;
        private string hoTen;
        private string chuyenNganh;
        private int namSinh;
        private float diemTB;
        private string loai;

        // các phương thức 
        public string MaSo
        {
            get { return maSo; }
            set { maSo = value; }
        }
        public string HoTen
        {
            get { return hoTen; }
            set { hoTen = value; }
        }
        public string ChuyenNganh
        {
            get { return chuyenNganh; }
            set { chuyenNganh = value; }
        }
        public int NamSinh
        {
            get { return namSinh; }
            set
            {
                while (KiemTraNamSinh(value) == false)
                {
                    Console.WriteLine("Nhap lai nam sinh");
                    value = int.Parse(Console.ReadLine());
                }
                namSinh = value;
                /* int tuoi = DateTime.Now.Year - value;
                 if (tuoi < 17 || tuoi > 70)
                     Console.WriteLine("Năm Sinh không Thể Nhập Học. Vui lòng nhập lại: ");
                 namSinh = value;*/

            }
        }
        public float DiemTB
        {
            get { return diemTB; }
            set
            {
                if (diemTB < 0 || diemTB > 10)
                    Console.WriteLine("Điểm không hợp lệ!");
                diemTB = value;
            }
        }
        public string Loai
        {
            get { return loai; }
            set { loai = value; }
        }


        // constructor
        // constructor mặc định => tạo object rỗng
        public SinhVien() { }

        // constructor có tham số (parameter constructor )
        public SinhVien(string ms, string ht, string cn, int ns, float dtb)
        {
            this.MaSo = ms;
            this.HoTen = ht;
            this.ChuyenNganh = cn;
            this.NamSinh = ns;
            this.DiemTB = dtb;
            XepLoai();

        }
        public SinhVien(SinhVien sv)
        {
            this.MaSo = sv.MaSo;
            this.HoTen = sv.HoTen;
            this.ChuyenNganh = sv.chuyenNganh;
            this.NamSinh = sv.NamSinh;
            this.DiemTB = sv.DiemTB;
            XepLoai();
        }

        public void Input()
        {
            Console.Write($"Nhập mã số sinh viên : ");
            this.MaSo = Console.ReadLine();
            Console.Write("Nhap ho ten sinh vien :");
            this.HoTen = Console.ReadLine();
            Console.Write("Nhap chuyen nghanh : ");
            this.ChuyenNganh = Console.ReadLine();
            Console.Write("Nhap nam sinh : ");
            this.NamSinh = int.Parse(Console.ReadLine());
            Console.Write("Nhap diem trung binh : ");
            this.DiemTB = float.Parse(Console.ReadLine());
            XepLoai();

        }
        public void Output()
        {
            Console.WriteLine($"Ma so sinh vien : {maSo}");
            Console.WriteLine($"Ho ten sinh vien : {hoTen}");
            Console.WriteLine($"Chuyen nganh : {chuyenNganh}");
            Console.WriteLine($"Nam sinh : {namSinh}");
            Console.WriteLine($"Diem trung binh : {diemTB}");
            Console.WriteLine($"Xep loai : {Loai}");
        }
        // hàm xếp loại
        public void XepLoai()
        {
            Loai = (diemTB < 5) ? "Kém"
                : (diemTB < 7) ? "Trung Bình"
                  : (diemTB < 8) ? "Khá" : "Giỏi";
        }
        public bool KiemTraNamSinh(int ns)
        {
            int tuoi = DateTime.Now.Year - ns;
            if (tuoi < 17 || tuoi > 70)
                return false;
            return true;
        }
        public bool KiemTraDiemTB(float dtb)
        {
            if (dtb < 0 && dtb > 10)
                return false;
            return true;
        }
    }
}

