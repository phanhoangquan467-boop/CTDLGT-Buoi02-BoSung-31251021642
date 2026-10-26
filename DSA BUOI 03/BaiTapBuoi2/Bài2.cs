using System;
using System.Collections.Generic;
using System.Text;

namespace DSA_BUOI_03.BaiTapBuoi2
{
    internal class Bài2
    {
        public static void Insert(int[] data, ref int count, int index, int value)
        {
            // Kiểm tra chỉ số index không hợp lệ (từ 0 đến count)
            if (index < 0 || index > count)
            {
                throw new ArgumentOutOfRangeException(nameof(index), "Chỉ số index nằm ngoài phạm vi hợp lệ.");
            }

            // Kiểm tra nếu mảng đã đầy (count >= data.Length) thì phát sinh ngoại lệ
            if (count >= data.Length)
            {
                throw new InvalidOperationException("Mảng đã đầy, không thể chèn thêm phần tử.");
            }

            // Dịch các phần tử từ phải sang trái (từ cuối về index) để tạo khoảng trống
            // (Lý do dịch từ phải sang trái để tránh ghi đè dữ liệu phía trước
            for (int i = count; i > index; i--)
            {
                data[i] = data[i - 1]; // Đẩy phần tử sang phải
            }

            // Gán giá trị mới vào vị trí index
            data[index] = value;

            // Tăng biến count sau khi đã dịch chuyển xong dữ liệu
            count++;
        }

        // Phương thức xóa phần tử tại chỉ số index
        public static void RemoveAt(int[] data, ref int count, int index)
        {
            // Kiểm tra chỉ số index không hợp lệ (từ 0 đến count - 1)
            if (index < 0 || index >= count)
            {
                throw new ArgumentOutOfRangeException(nameof(index), "Chỉ số index nằm ngoài phạm vi hợp lệ.");
            }

            // Dịch các phần tử từ trái sang phải (từ index + 1 đến hết) để lấp chỗ trống
            // (Lý do dịch từ trái sang phải để đè lên phần tử bị xóa)
            for (int i = index; i < count - 1; i++)
            {
                data[i] = data[i + 1]; // Kéo phần tử sang trái
            }

            // Xóa sạch ô dữ liệu thừa cuối cùng
            data[count - 1] = 0;

            // Giảm biến count sau khi đã dịch chuyển xong dữ liệu
            count--;
        }
    }
}
