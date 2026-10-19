using System;
using System.Collections.Generic;
using System.Text;

namespace CTDLGT_Buoi02_BoSung_31251020109
{
    internal class Bai3
    {
        public class Student
        {
            // Lưu mã duy nhất dùng để nhận diện sinh viên.
            public string Id { get; set; } = "";

            // Lưu họ tên dùng cho hiển thị và tìm kiếm.
            public string FullName { get; set; } = "";

            // Lưu điểm tổng kết trong đoạn từ 0 đến 10.
            public double Score { get; set; }
        }
        static void add()
        {
            Console.Write("Nhap ma sinh vien (ID): ");
            string id = Console.ReadLine();
            // Kiểm tra mã trùng bằng vòng lặp duyệt List
            for (int i = 0; i < liststudent.Count; i++)
            {
                if (liststudent[i].Id == id)
                {
                    Console.WriteLine("Ma sinh vien da ton tai!");
                    return;
                }
            }
            Console.Write("Nhap ho va ten (FullName): ");
            string fullname = Console.ReadLine();
            Console.Write("Nhap diem (tu 0 den 10): ");
            if (!double.TryParse(Console.ReadLine(), out double score) || score < 0 || score > 10)
            {
                Console.WriteLine("Diem khong hop le!");
                return;
            }
            // Thêm sinh viên vào List
            Student sv = new Student();
            sv.Id = id;
            sv.FullName = fullname;
            sv.Score = score;
            liststudent.Add(sv);
            Console.WriteLine("Them sinh vien thanh cong!");
        }
        // Cập nhật mã sinh viên
        static void update()
        {
            Console.Write("Nhap ma sinh vien can cap nhat (ID): ");
            string id = Console.ReadLine();
            // Dùng làm biến tạm để chứa sinh viên tìm được. Cần khởi tạo trước nên cho là null (rỗng)
            Student? svfind = null;
            for (int i = 0; i < liststudent.Count; i++)
            {
                if (liststudent[i].Id == id)
                {
                    svfind = liststudent[i];
                    break;
                }
            }
            if (svfind == null)
            {
                Console.WriteLine("Khong tim thay sinh vien!");
                return;
            }
            Console.Write($"Nhap ho va ten can cap nhat (Co the de trong): ");
            // Nếu không nhập gì thì biến là rỗng
            string newname = Console.ReadLine() ?? "";
            if (!string.IsNullOrWhiteSpace(newname))
            {
                svfind.FullName = newname;
            }
            Console.Write($"Nhap diem can cap nhat (Co the de trong): ");
            // Nếu không nhập gì thì biến là rỗng
            string updatescore = Console.ReadLine() ?? "";
            if (!string.IsNullOrWhiteSpace(updatescore))
            {
                if (double.TryParse(updatescore, out double newscore) && newscore >= 0 && newscore <= 10)
                {
                    svfind.Score = newscore;
                }
                else
                {
                    Console.WriteLine("Diem moi khong hop le, giu nguyen diem cu!");
                }
            }
            Console.WriteLine("Cap nhat thong tin sinh vien thanh cong!");
        }
        static void remove()
        {
            Console.Write("Nhap ma sinh vien can xoa (ID): : ");
            string id = Console.ReadLine();
            // Khởi tạo index với giá trị ban đầu nằm ngoài chỉ số vị trí trong List
            int index = -1;
            for (int i = 0; i < liststudent.Count; i++)
            {
                if (liststudent[i].Id == id)
                {
                    index = i;
                    break;
                }
            }
            // Giá trị không thay đổi, mã sinh viên cần xóa không nằm trong List
            if (index == -1)
            {
                Console.WriteLine("Khong tim thay ma sinh vien!");
            }
            else
            {
                liststudent.RemoveAt(index);
                Console.WriteLine("Xoa thong tin sinh vien thanh cong!");
            }
        }
        static void find()
        {
            Console.Write("Nhap mot phan ho ten can tim: ");
            string keyword = Console.ReadLine();
            bool found = false;
            // Duyệt thủ công bằng vòng lặp, dùng ToLower() để không phân biệt hoa/thường
            for (int i = 0; i < liststudent.Count; i++)
            {
                if (liststudent[i].FullName.ToLower().Contains(keyword.ToLower()))
                {
                    Console.WriteLine($"Ma SV: {liststudent[i].Id} | Ho va ten: {liststudent[i].FullName} | Diem: {liststudent[i].Score}");
                    found = true;
                }
            }
            if (!found)
            {
                Console.WriteLine("Khong tim thay thong tin sinh vien!");
            }
        }
        static void hienthilist()
        {
            // Kiểm tra xem List có rỗng không
            if (liststudent.Count == 0)
            {
                Console.WriteLine("Danh sach sinh vien hien dang rong!");
                return;
            }
            Console.WriteLine("DANH SÁCH SINH VIÊN");
            double sum = 0;
            int count = 0;
            for (int i = 0; i < liststudent.Count; i++)
            {
                Console.WriteLine($"Ma SV: {liststudent[i].Id} | Ho va ten: {liststudent[i].FullName} | Diem: {liststudent[i].Score}");
                sum += liststudent[i].Score;
                if (liststudent[i].Score >= 5.0)
                {
                    count++;
                }
            }
            double average = sum / liststudent.Count;
            Console.WriteLine($"Tong so sinh vien: {liststudent.Count}");
            Console.WriteLine($"Diem trung binh: {average:F2}");
            Console.WriteLine($"So sinh vien dat (>= 5): {count}");
        }
        static List<Student> liststudent = new List<Student>();
        public static void Main(string[] args)
        {
            List<Student> liststudent = new List<Student>()
            {
                new Student { Id = "SV01", FullName = "A", Score = 8.0 },
                new Student { Id = "SV02", FullName = "B", Score = 9.5 }
            };
            while (true)
            {
                Console.WriteLine("1. Them sinh vien");
                Console.WriteLine("2. Cap nhat thong tin sinh vien");
                Console.WriteLine("3. Xoa sinh vien theo ma");
                Console.WriteLine("4. Tim kiem sinh vien theo ho ten");
                Console.WriteLine("5. Hien thi danh sach thong ke, diem trung binh va so sinh vien dat (>=5)");
                int chon = int.Parse(Console.ReadLine());
                switch (chon)
                {
                    case 1:
                        add();
                        break;
                    case 2:
                        update();
                        break;
                    case 3:
                        remove();
                        break;
                    case 4:
                        find();
                        break;
                    case 5:
                        hienthilist();
                        break;
                }
            }
        }
    }
}
