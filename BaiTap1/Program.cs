using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTap1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int choice = -1;
            do
            {
                Console.WriteLine();
                Console.WriteLine("=============================");
                Console.WriteLine("1. Sap xep MSSV ( selection Sort )");
                Console.WriteLine("2. Sap xep diem trung binh ( Insertion Sort )");
                Console.WriteLine("0. Thoat");
                Console.Write("Nhap lua chon: ");
                choice = int.Parse(Console.ReadLine());
                switch ( choice )
                {
                    case 1: Test_SapXepTangDan_MSSV(); break;
                    case 2: Test_SapXepGiamDan_DiemTB(); break;
                }
            } while (choice != 0); 
        }
        static void TestSinhVien()
        {
            SinhVien svA = new SinhVien();
            svA.Input();
            Console.WriteLine("Thông tin sinh viên A: ");
            svA.Output();
            Console.WriteLine("-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.");
            SinhVien svB = new SinhVien("18DH001", "Lam Thanh Ngoc", "CNPM", 2000, 7.6F);
            svB.Output();
            Console.WriteLine("-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.-.");
            // tạo đối tượng svC được sao chép thông tin từ sinh viên B

            SinhVien svC = new SinhVien(svB);

            // nhập họ tên điểm trung bình tích lũy cho sinh viên c
            Console.WriteLine();
            Console.WriteLine("Nhap lai thong tin sinh vien c: ");
            Console.Write("Nhap Ho Ten : ");
            svC.HoTen = Console.ReadLine();
            Console.Write("Nhap diem trung binh : ");
            svC.DiemTB = float.Parse(Console.ReadLine());
            svC.XepLoai();

            Console.WriteLine();
            Console.WriteLine("Thong tin sinh vien C : ");
            svC.Output();
            Console.WriteLine();
            Console.WriteLine("Thong tin sinh vien B : ");
            svB.Output();
        }
        static void TestMangSinhVien()
        {
            MangSinhVien dssv = new MangSinhVien();
            dssv.Nhap();
            Console.WriteLine("Danh sach thong tin sinh vien : ");
            dssv.Xuat();
        }
        static void Test_SapXepTangDan_MSSV()
        {
            MangSinhVien dssv = new MangSinhVien();
            dssv.Nhap();
            Console.WriteLine("Danh sach sinh vien truoc khi sap xep: ");
            dssv.Xuat();

            dssv.SapXep_MSSV_SelectionSort();
            Console.WriteLine("\n ===========================");
            Console.WriteLine("Danh sach sinh vien sau khi sap xep : ");
            dssv.Xuat();
        }
        static void Test_SapXepGiamDan_DiemTB()
        {
            MangSinhVien dssv = new MangSinhVien();
            dssv.Nhap();
            Console.WriteLine("Danh sach sinh vien truoc khi sap xep : ");
            dssv.Xuat();

            dssv.SapXep_DiemTB_InsertionSort();
            Console.WriteLine("\n ==========================");
            Console.WriteLine("Danh sach sinh vien sau khi sap xep ( giam theo diem tb ) : ");
            dssv.Xuat();
        }
        
    }
}
