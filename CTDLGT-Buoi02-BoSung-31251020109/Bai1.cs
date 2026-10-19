using System;
using System.Collections.Generic;
using System.Text;

namespace CTDLGT_Buoi02_BoSung_31251020109
{
    internal class Bai1
    {
        public static void Main(string[] args)
        {
            Console.Write($"Mang dau vao: "); string mang = Console.ReadLine();
            string[] chuoi = mang.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int[] arr = Array.ConvertAll(chuoi, int.Parse);
            int n = arr.Length;
            long sum = 0;
            int min = arr[0], max = arr[0];
            double average = sum / n;
            int am = 0, duong = 0, zero = 0;
            for (int i = 0; i < n; i++)
            {
                sum += arr[i];
                if (arr[i] < min) min = arr[i];
                if (arr[i] > max) max = arr[i];
                if (arr[i] < 0) am++;
                if (arr[i] > 0) duong++;
                if (arr[i] == 0) zero++;
            }
            int temp = 0;
            for (int left = 0; left <= n / 2; left++)
            {
                int right = n - left - 1;
                temp = arr[left];
                arr[left] = arr[right];
                arr[right] = temp;
            }
            Console.WriteLine($"Tong: {sum}");
            Console.WriteLine($"Min: {min}");
            Console.WriteLine($"Max: {max}");
            Console.WriteLine($"Trung binh cong: {average}");
            string dao = string.Join(" ", arr);
            Console.WriteLine($"Dao: {dao}");
        }
    }
}
