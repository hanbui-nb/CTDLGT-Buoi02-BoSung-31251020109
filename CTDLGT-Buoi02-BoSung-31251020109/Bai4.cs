using System;
using System.Collections.Generic;
using System.Text;

namespace CTDLGT_Buoi02_BoSung_31251020109
{
    internal class Bai4
    {
        public class DynamicArray<T>
        {
            private T[] items;
            // Số lượng phần tử thực tế hiện có trong mảng
            public int Count { get; private set; }
            // Dung lượng tối đa của mảng hiện tại
            public int Capacity => items.Length;
            // Khởi tạo với dung lượng mặc định là 4, từ chối dung lượng âm
            public DynamicArray(int capacity = 4)
            {
                if (capacity < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(capacity), "Dung luong khoi tao khong duoc là so am!");
                }
                // Nếu người dùng nhập vào 0, ta có thể khởi tạo mặc định là 4 hoặc giữ nguyên 0
                if (capacity == 0) capacity = 4;
                items = new T[capacity];
                Count = 0;
            }
            // Phương thức thêm phần tử vào cuối mảng
            public void Add(T item)
            {
                // Kiểm tra và mở rộng mảng nếu đầy
                EnsureCapacity(); 
                items[Count] = item;
                Count++;
            }
            // Phương thức tự động mở rộng mảng khi Count == Capacity
            private void EnsureCapacity()
            {
                if (Count == Capacity)
                {
                    // Tạo mảng mới có dung lượng gấp đôi
                    int newCapacity = Capacity == 0 ? 4 : Capacity * 2;
                    T[] newitems = new T[newCapacity];
                    // Sao chép đúng Count phần tử cũ sang mảng mới
                    for (int i = 0; i < Count; i++)
                    {
                        newitems[i] = items[i];
                    }
                    items = newitems;
                }
            }
            // Gán giá trị qua chỉ số [index]
            public T this[int index]
            {
                get
                {
                    // Chỉ chấp nhận chỉ số từ 0 đến Count - 1
                    if (index < 0 || index >= Count)
                    {
                        throw new ArgumentOutOfRangeException(nameof(index), "Chi so nam ngoai pham vi danh sach");
                    }
                    return items[index];
                }
                set
                {
                    if (index < 0 || index >= Count)
                    {
                        throw new ArgumentOutOfRangeException(nameof(index), "Chi so nam ngoai pham vi danh sach");
                    }
                    items[index] = value;
                }
            }
        }
    }
}
