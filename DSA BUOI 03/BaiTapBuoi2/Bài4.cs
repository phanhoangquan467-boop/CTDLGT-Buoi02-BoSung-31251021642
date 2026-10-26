using System;
using System.Collections.Generic;
using System.Text;

namespace DSA_BUOI_03.BaiTapBuoi2
{
    internal class Bài4
    {
        class DynamicArray<T>
        {
            private T[] items;
            private int count;

            // Hàm khởi tạo mảng động với dung lượng mặc định là 4
            public DynamicArray()
            {
                items = new T[4];
                count = 0;
            }

            // Thuộc tính lấy số lượng phần tử hiện tại
            public int Count
            {
                get { return count; }
            }

            // Thuộc tính lấy sức chứa của mảng
            public int Capacity
            {
                get { return items.Length; }
            }

            // Phương thức thêm phần tử vào mảng
            public void Add(T item)
            {
                EnsureCapacity(); // Kiểm tra xem mảng có đầy chưa để nhân đôi
                items[count] = item;
                count++;
            }

            // Hàm kiểm tra và mở rộng mảng khi đầy
            private void EnsureCapacity()
            {
                if (count >= items.Length)
                {
                    int newCapacity = items.Length * 2;
                    T[] newItems = new T[newCapacity];

                    // Dùng vòng lặp for sao chép từng phần tử sang mảng mới
                    for (int i = 0; i < count; i++)
                    {
                        newItems[i] = items[i];
                    }

                    items = newItems; // Gán mảng mới thay cho mảng cũ
                }
            }

            // Indexer để truy cập phần tử qua chỉ số [index]
            public T this[int index]
            {
                get
                {
                    if (index < 0 || index >= count)
                    {
                        throw new ArgumentOutOfRangeException("index", "Chỉ số vượt quá giới hạn của mảng.");
                    }
                    return items[index];
                }
                set
                {
                    if (index < 0 || index >= count)
                    {
                        throw new ArgumentOutOfRangeException("index", "Chỉ số vượt quá giới hạn của mảng.");
                    }
                    items[index] = value;
                }

            }
        }
        }
}
