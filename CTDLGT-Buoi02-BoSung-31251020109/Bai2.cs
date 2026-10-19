using System;
using System.Collections.Generic;
using System.Text;

namespace CTDLGT_Buoi02_BoSung_31251020109
{
    internal class Bai2
    {
        static void Insert(int[] data, ref int count, int index, int value)
        {
            for (int i = count; i > index; i--)
            {
                data[i] = data[i - 1];
            }
            data[index] = value;
            count++;
        }
        static void RemoveAt(int[] data, ref int count, int index)
        {
            for (int i = index; i < count; i++)
            {
                data[i] = data[i + 1];
            }
            count--;
        }
        public static void Main(string[] args)
        {
            Console.Write($"Mang dau vao: "); string mang = Console.ReadLine();
            string[] chuoi = mang.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int[] data = new int[chuoi.Length + 2];
            for (int i = 0; i < chuoi.Length; i++)
            {
                data[i] = int.Parse(chuoi[i]);
            }
            int count = chuoi.Length;
            while (true)
            {
                Console.Write("Chon Insert (1) hoac Remove (2): "); int chon = int.Parse(Console.ReadLine());
                switch (chon)
                {
                    case 1:
                        Console.WriteLine("Insert: ");
                        if (count > data.Length)
                        {
                            throw new InvalidOperationException("Mang da day. Khong the chen them!");
                        }
                        Console.Write("Nhap vi tri can chen: "); int index = Convert.ToInt32(Console.ReadLine());
                        if (index < 0 || index > count)
                        {
                            throw new ArgumentOutOfRangeException("Chi so khong hop le!");
                        }
                        Console.Write("Nhap gia tri can chen: "); int value = Convert.ToInt32(Console.ReadLine());
                        Insert(data, ref count, index, value);
                        Console.Write($"Sau chen: {string.Join(" ", data)}");
                        break;
                    case 2:
                        Console.WriteLine("Insert: ");
                        Console.Write("Nhap vi tri can xoa: "); index = Convert.ToInt32(Console.ReadLine());
                        if (index < 0 || index >= count)
                        {
                            throw new ArgumentOutOfRangeException("Chi so khong hop le!");
                        }
                        RemoveAt(data, ref count, index);
                        Console.Write($"Sau xoa: {string.Join(" ", data)}");
                        break;
                }
                Console.Write("Ban muon chon tiep? Y/N "); string next = Console.ReadLine();
                if (next.ToLower() == "y") break;
            }
        }
    }
}
