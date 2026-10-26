# Bài tập Thực hành 02 - Cấu trúc dữ liệu và Giải thuật

- **Học phần:** Cấu trúc dữ liệu và Giải thuật
- **Giảng viên hướng dẫn:** TS. Nguyễn Thành Huy
- **Đơn vị:** Khoa Công nghệ thông tin kinh doanh - Đại học Kinh tế Thành phố Hồ Chí Minh (UEH)
- **Họ và tên sinh viên:** Phan Hoàng Quân
- **Mã số sinh viên (MSSV):** 31251021642

---


```

---

## 🚀 Hướng dẫn chạy chương trình

1. **Yêu cầu hệ thống:**
   - .NET SDK phiên bản 6.0 trở lên.

2. **Cách thực thi:**
   - Mở Terminal / Command Prompt tại thư mục gốc của repository.
   - Di chuyển vào thư mục bài tập cần chạy (Ví dụ: `Bai1`):
     ```bash
     cd Bai1
     ```
   - Chạy lệnh:
     ```bash
     dotnet run
     ```

---

## 📝 Mô tả Thuật toán và Phân tích Độ phức tạp

### BÀI 1: THỐNG KÊ VÀ ĐẢO MẢNG

#### 1. Mô tả thuật toán & Lựa chọn kỹ thuật
- **Thống kê:** Duyệt qua mảng đúng một lần từ chỉ số `0` đến `n - 1`. 
  - Khởi tạo `min` và `max` bằng giá trị của phần tử đầu tiên `data[0]` (thay vì 0) để đảm bảo tính đúng đắn khi mảng chỉ toàn số âm hoặc toàn số dương.
  - Sử dụng biến `sum` kiểu `long` để tránh hiện tượng tràn số (integer overflow) khi cộng dồn các phần tử `int`. Khi tính trung bình cộng, ép kiểu `sum` sang `double` trước khi chia cho `n` để giữ lại phần thập phân.
- **Đảo mảng:** Sử dụng hai con trỏ `left` (bắt đầu từ 0) và `right` (bắt đầu từ `n - 1`). Dùng vòng lặp `while (left < right)` để hoán đổi giá trị hai vị trí này và tiến `left` lên 1, lùi `right` xuống 1 cho đến khi hai con trỏ gặp hoặc vượt qua nhau.

#### 2. Phân tích độ phức tạp
- **Thống kê:** Duyệt $n$ phần tử $\rightarrow$ Thời gian $\Theta(n)$, Bộ nhớ phụ $\Theta(1)$.
- **Đảo mảng:** Duyệt $n/2$ lần hoán đổi $\rightarrow$ Thời gian $\Theta(n)$, Bộ nhớ phụ $\Theta(1)$.
- **Tổng thể chương trình:** Hai vòng lặp tuyến tính nối tiếp nhau mang tổng thời gian là $\Theta(n) + \Theta(n) = \Theta(n)$ và bộ nhớ phụ $\Theta(1)$.

---

### BÀI 2: CHÈN VÀ XÓA TRÊN MẢNG

#### 1. Mô tả thuật toán & Lựa chọn kỹ thuật
- **Chèn (`Insert`):**
  - Kiểm tra điều kiện mảng đầy (`count >= data.Length`) $\rightarrow$ Ném ngoại lệ `InvalidOperationException`.
  - Kiểm tra chỉ số không hợp lệ (`index < 0 || index > count`) $\rightarrow$ Ném ngoại lệ `ArgumentOutOfRangeException`.
  - Dịch chuyển dữ liệu: Phải dịch **từ phải sang trái** (bắt đầu từ `i = count` về `index + 1`) bằng câu lệnh `data[i] = data[i - 1]`. Mục đích để tạo ô trống tại `index` mà không làm ghi đè mất dữ liệu của các phần tử đứng trước.
  - Gán `data[index] = value` và tăng `count++` sau khi đã hoàn tất việc dịch chuyển.
- **Xóa (`RemoveAt`):**
  - Kiểm tra chỉ số không hợp lệ (`index < 0 || index >= count`) $\rightarrow$ Ném ngoại lệ `ArgumentOutOfRangeException`.
  - Dịch chuyển dữ liệu: Dịch **từ trái sang phải** (bắt đầu từ `i = index` đến `count - 2`) bằng câu lệnh `data[i] = data[i + 1]` để ghi đè lấp khoảng trống của phần tử bị xóa.
  - Reset ô dữ liệu thừa `data[count - 1] = 0` và giảm `count--` sau khi hoàn tất.

#### 2. Phân tích độ phức tạp
- **`Insert`:**
  - Dịch $\text{count} - \text{index}$ phần tử $\rightarrow$ Thời gian $\Theta(\text{count} - \text{index} + 1)$.
  - Trường hợp tốt nhất (chèn cuối, `index = count`): $O(1)$.
  - Trường hợp xấu nhất (chèn đầu, `index = 0`): $O(n)$.
  - Bộ nhớ phụ: $\Theta(1)$.
- **`RemoveAt`:**
  - Dịch $\text{count} - \text{index} - 1$ phần tử $\rightarrow$ Thời gian $\Theta(\text{count} - \text{index})$.
  - Trường hợp tốt nhất (xóa cuối, `index = count - 1`): $O(1)$.
  - Trường hợp xấu nhất (xóa đầu, `index = 0`): $O(n)$.
  - Bộ nhớ phụ: $\Theta(1)$.

---

### BÀI 3: QUẢN LÝ LIST STUDENT

#### 1. Mô tả thuật toán & Lựa chọn kỹ thuật
- **Cấu trúc:** Sử dụng lớp `Student` gồm `Id`, `FullName`, `Score` và quản lý bằng `List<Student>`.
- **Thêm sinh viên:** Duyệt qua danh sách để kiểm tra mã trùng $O(n)$. Kiểm tra điểm nằm trong đoạn $[0, 10]$. Nếu hợp lệ mới thực hiện `Add`.
- **Cập nhật & Xóa:** Duyệt danh sách tìm chỉ số sinh viên theo `Id` ($O(n)$). Xóa phần tử bằng `RemoveAt(index)` làm cho các phần tử phía sau bị dịch trái 1 vị trí.
- **Tìm kiếm:** Duyệt danh sách, chuyển họ tên và từ khóa về chuỗi chữ thường (`ToLower()`) để so sánh bằng `Contains()` giúp tìm kiếm không phân biệt hoa/thường.
- **Thống kê:** Duyệt qua `List<Student>` một lần để tính tổng điểm và đếm số lượng sinh viên có điểm $\ge 5.0$. Kiểm tra `Count == 0` để tránh lỗi chia cho 0.

#### 2. Phân tích độ phức tạp
- **Thêm sinh viên:** Dù `List.Add()` có chi phí khấu hao $O(1)$, nhưng bước kiểm tra trùng mã cần duyệt danh sách nên tổng thời gian là $O(n)$.
- **Cập nhật / Tìm kiếm / Xóa:** Thời gian $O(n)$ trường hợp xấu nhất, Bộ nhớ phụ $O(1)$.
- **Thống kê:** Thời gian $\Theta(n)$, Bộ nhớ phụ $\Theta(1)$.

---

### BÀI 4: MẢNG ĐỘNG VÀ CAPACITY (`DynamicArray<T>`)

#### 1. Mô tả thuật toán & Lựa chọn kỹ thuật
- **Khởi tạo:** Cấp phát mảng tĩnh nội bộ `T[] items` với kích thước mặc định `Capacity = 4`.
- **Mở rộng mảng (`EnsureCapacity`):** Khi `Count == Capacity`, tạo mảng tạm mới có kích thước gấp đôi (`Capacity * 2`), sao chép toàn bộ `Count` phần tử từ mảng cũ sang mảng mới, sau đó trỏ `items` sang mảng mới.
- **Lý giải về việc x2 Capacity:** Nếu mỗi lần đầy chỉ tăng `Capacity` thêm 1 đơn vị, mỗi lần chèn mới đều phải cấp phát và sao chép lại toàn bộ $i$ phần tử cũ. Tổng chi phí cho $n$ lần `Add` sẽ là $1 + 2 + 3 + ... + n = \frac{n(n+1)}{2} = O(n^2)$. Việc nhân đôi giúp trung bình hóa chi phí (Amortized Complexity) của $n$ lần `Add` xuống còn $O(n)$, tức trung bình $O(1)$ cho mỗi lần `Add`.
- **Indexer (`this[int index]`):** Cho phép truy xuất và gán giá trị như mảng thông thường. Kiểm tra biên $0 \le \text{index} < \text{Count}$, ném `ArgumentOutOfRangeException` nếu vi phạm.

#### 2. Phân tích độ phức tạp
- **Indexer (get/set):** $O(1)$.
- **Thao tác `Add`:** 
  - Trường hợp không cần mở rộng: $O(1)$.
  - Trường hợp cần mở rộng: $O(n)$ (chi phí sao chép).
  - Chi phí khấu hao (Amortized): $O(1)$.
- **Bộ nhớ phụ:** Bộ nhớ lưu trữ $O(n)$, bộ nhớ tạm thời khi nhân đôi dung lượng $O(n)$.

---

## 📊 Bảng Kiểm Thử (Test Cases)

| Bài | Loại Ca | Đầu vào | Kết quả mong đợi | Kết quả thực tế | Nhận xét |
|:---:|:---:|---|---|---|:---:|
| **1** | Thường | `3 7 2 9 5` | Min: 2; Max: 9; Đảo: `5 9 2 7 3` | Min: 2; Max: 9; Đảo: `5 9 2 7 3` | Đạt |
| **1** | Âm & 0 | `-5 0 5 0` | Âm: 1, Dương: 1, Bằng 0: 2 | Âm: 1, Dương: 1, Bằng 0: 2 | Đạt |
| **1** | 1 phần tử | `8` | Min = Max = 8; Đảo: `8` | Min = Max = 8; Đảo: `8` | Đạt |
| **1** | Toàn số âm | `-4 -2 -9` | Max: -2; TBC: -5.00 | Max: -2; TBC: -5.00 | Đạt |
| **2** | Thường | `[4, 7, 2, 9, 5]`, count = 5. Insert `99` tại index 2, sau đó RemoveAt index 1 | Insert xong: `[4, 7, 99, 2, 9, 5]`, count = 6. RemoveAt xong: `[4, 99, 2, 9, 5, 0]`, count = 5 | Hoạt động chính xác đúng thứ tự | Đạt |
| **2** | Biên / Lỗi | Mảng đầy (count = Length), gọi `Insert` | Phát sinh `InvalidOperationException` | Bắt được ngoại lệ mảng đầy | Đạt |
| **2** | Biên / Lỗi | `RemoveAt` với index = count | Phát sinh `ArgumentOutOfRangeException` | Bắt được ngoại lệ index ngoài phạm vi | Đạt |
| **3** | Thường | Thêm 5 sinh viên hợp lệ | Thêm thành công vào danh sách | Thêm thành công | Đạt |
| **3** | Không hợp lệ| Thêm sinh viên với ID đã tồn tại | Báo lỗi trùng mã, từ chối thêm | Báo lỗi trùng mã | Đạt |
| **3** | Không hợp lệ| Nhập điểm = 15 hoặc -2 | Báo lỗi điểm không hợp lệ | Từ chối nhập điểm sai | Đạt |
| **3** | Biên | Tính TBC khi danh sách rỗng | Thông báo danh sách rỗng, không bị chia cho 0 | Xử lý an toàn | Đạt |
| **4** | Thường | Thêm lần lượt 10 phần tử từ 1 đến 10 | Capacity tăng từ 4 -> 8 -> 16. Dữ liệu giữ nguyên thứ tự 1..10 | Khởi tạo 4, nhân đôi lên 8 và 16 đúng thời điểm | Đạt |
| **4** | Không hợp lệ| Truy cập indexer `[-1]` hoặc `[Count]` | Ném `ArgumentOutOfRangeException` | Bắt được ngoại lệ chỉ số vi phạm | Đạt |

---

## 🤖 Khai báo sử dụng AI

Tôi đã sử dụng **Gemini 3 Flash** để hỗ trợ trong quá trình làm bài.
- **Mục đích sử dụng:** Gợi ý cấu trúc giải thuật dịch chuyển mảng, rà soát các trường hợp biên ngoại lệ và hỗ trợ định dạng khung báo cáo README.md theo chuẩn Markdown.
- **Kiểm chứng:** Tôi đã tự viết lại code, kiểm tra từng dòng lệnh bằng comment, biên dịch và chạy thử nghiệm đầy đủ các ca kiểm thử trên môi trường VS Code / Visual Studio trước khi nộp bài. Tôi hoàn toàn chịu trách nhiệm về toàn bộ nội dung mã nguồn này.
