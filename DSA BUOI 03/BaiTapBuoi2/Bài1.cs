using System;
using System.Collections.Generic;
using System.Text;

namespace DSA_BUOI_03.BaiTapBuoi2
{
    internal class Bài1
    {
        public static void Run()
        {
            Console.Write("Nhập số lượng phần tử n (1 <= n <= 100000): ");
            int n = int.Parse(Console.ReadLine() ?? "0");
            int[] a = new int[n];

            Console.WriteLine($"Nhập {n} số nguyên:");
            for (int i = 0; i < n; i++)
            {
                a[i] = int.Parse(Console.ReadLine() ?? "0");
            }

            if (n <= 0) return;

            long sum = 0;
            int min = a[0];
            int max = a[0];
            int am = 0, duong = 0, bang0 = 0;


            for (int i = 0; i < n; i++)
            {
                sum += a[i];

                if (a[i] < min) min = a[i];
                if (a[i] > max) max = a[i];

                if (a[i] < 0) am++;
                else if (a[i] > 0) duong++;
                else bang0++;
            }

            double average = (double)sum / n;
            Console.WriteLine($"Tổng: {sum}");
            Console.WriteLine($"Min: {min}, Max: {max}");
            Console.WriteLine($"Trung bình cộng: {average:F2}");
            Console.WriteLine($"Số phần tử âm: {am}, dương: {duong}, bằng 0: {bang0}");

            int left = 0, right = n - 1;
            while (left < right)
            {
                int temp = a[left];
                a[left] = a[right];
                a[right] = temp;

                left++;
                right--;
            }

            Console.WriteLine("Mảng sau khi đảo tại chỗ: " + string.Join(" ", a));
        }
    }
}
