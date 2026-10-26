using System;
using System.Collections.Generic;
using System.Text;

namespace DSA_BUOI_03.BaiTapBuoi2
{
    internal class Bàii3
    {
        class Student
        {
            public string Id;
            public string FullName;
            public double Score;
        }

        class ProgramBai3
        {
            // Khai báo danh sách sinh viên toàn cục trong class
            static List<Student> dsSinhVien = new List<Student>();

            static void Main(string[] args)
            {
                int chon = 0;
                do
                {
                    Console.WriteLine("1. Thêm sinh viên");
                    Console.WriteLine("2. Cập nhật thông tin sinh viên");
                    Console.WriteLine("3. Xóa sinh viên theo mã");
                    Console.WriteLine("4. Tìm kiếm theo họ tên");
                    Console.WriteLine("5. Hiển thị danh sách và thống kê");
                    Console.WriteLine("0. Thoát");
                    Console.Write("Mời bạn chọn chức năng: ");

                    string input = Console.ReadLine();
                    chon = int.Parse(input);

                    // Dùng cấu trúc if-else thay vì switch-case phức tạp
                    if (chon == 1)
                    {
                        ThemSinhVien();
                    }
                    else if (chon == 2)
                    {
                        CapNhatSinhVien();
                    }
                    else if (chon == 3)
                    {
                        XoaSinhVien();
                    }
                    else if (chon == 4)
                    {
                        TimKiemSinhVien();
                    }
                    else if (chon == 5)
                    {
                        HienThiVaThongKe();
                    }
                } while (chon != 0);
            }

            // 1. Thêm sinh viên (có kiểm tra mã trùng và điểm hợp lệ)
            static void ThemSinhVien()
            {
                Console.Write("Nhập mã sinh viên: ");
                string id = Console.ReadLine();

                // Kiểm tra mã trùng bằng vòng lặp for cơ bản
                for (int i = 0; i < dsSinhVien.Count; i++)
                {
                    if (dsSinhVien[i].Id == id)
                    {
                        Console.WriteLine("Lỗi: Mã sinh viên bị trùng! Không thể thêm.");
                        return;
                    }
                }

                Console.Write("Nhập họ tên: ");
                string name = Console.ReadLine();

                Console.Write("Nhập điểm tổng kết (0 đến 10): ");
                double score = double.Parse(Console.ReadLine());

                if (score < 0 || score > 10)
                {
                    Console.WriteLine("Lỗi: Điểm không hợp lệ!");
                    return;
                }

                Student s = new Student();
                s.Id = id;
                s.FullName = name;
                s.Score = score;

                dsSinhVien.Add(s);
                Console.WriteLine("Thêm sinh viên thành công!");
            }

            // 2. Cập nhật thông tin sinh viên
            static void CapNhatSinhVien()
            {
                Console.Write("Nhập mã sinh viên cần cập nhật: ");
                string id = Console.ReadLine();

                int index = -1;
                for (int i = 0; i < dsSinhVien.Count; i++)
                {
                    if (dsSinhVien[i].Id == id)
                    {
                        index = i;
                        break;
                    }
                }

                if (index == -1)
                {
                    Console.WriteLine("Không tìm thấy sinh viên có mã này!");
                    return;
                }

                Console.Write("Nhập họ tên mới: ");
                dsSinhVien[index].FullName = Console.ReadLine();

                Console.Write("Nhập điểm mới: ");
                double score = double.Parse(Console.ReadLine());

                if (score >= 0 && score <= 10)
                {
                    dsSinhVien[index].Score = score;
                }
                else
                {
                    Console.WriteLine("Điểm không hợp lệ, giữ nguyên điểm cũ.");
                }

                Console.WriteLine("Cập nhật thành công!");
            }

            // 3. Xóa sinh viên theo mã
            static void XoaSinhVien()
            {
                Console.Write("Nhập mã sinh viên cần xóa: ");
                string id = Console.ReadLine();

                int index = -1;
                for (int i = 0; i < dsSinhVien.Count; i++)
                {
                    if (dsSinhVien[i].Id == id)
                    {
                        index = i;
                        break;
                    }
                }

                if (index == -1)
                {
                    Console.WriteLine("Không tìm thấy sinh viên để xóa!");
                    return;
                }

                dsSinhVien.RemoveAt(index);
                Console.WriteLine("Xóa thành công!");
            }

            // 4. Tìm kiếm theo họ tên (không phân biệt hoa thường)
            static void TimKiemSinhVien()
            {
                Console.Write("Nhập từ khóa họ tên cần tìm: ");
                string keyword = Console.ReadLine().ToLower();

                bool coTimThay = false;
                for (int i = 0; i < dsSinhVien.Count; i++)
                {
                    string tenSV = dsSinhVien[i].FullName.ToLower();
                    if (tenSV.Contains(keyword))
                    {
                        Console.WriteLine("Mã: " + dsSinhVien[i].Id + " | Tên: " + dsSinhVien[i].FullName + " | Điểm: " + dsSinhVien[i].Score);
                        coTimThay = true;
                    }
                }

                if (!coTimThay)
                {
                    Console.WriteLine("Không tìm thấy sinh viên nào phù hợp.");
                }
            }

            // 5. Hiển thị danh sách và tính thống kê
            static void HienThiVaThongKe()
            {
                if (dsSinhVien.Count == 0)
                {
                    Console.WriteLine("Danh sách sinh viên đang rỗng.");
                    return;
                }

                double tongDiem = 0;
                int soSVDat = 0;

                for (int i = 0; i < dsSinhVien.Count; i++)
                {
                    Console.WriteLine("Mã: " + dsSinhVien[i].Id + " | Tên: " + dsSinhVien[i].FullName + " | Điểm: " + dsSinhVien[i].Score);
                    tongDiem += dsSinhVien[i].Score;

                    if (dsSinhVien[i].Score >= 5.0)
                    {
                        soSVDat++;
                    }
                }

                double diemTrungBinh = tongDiem / dsSinhVien.Count;
                Console.WriteLine("Điểm trung bình của lớp: " + diemTrungBinh);
                Console.WriteLine("Số sinh viên đạt từ 5.0 trở lên: " + soSVDat);
            }
        }
}
