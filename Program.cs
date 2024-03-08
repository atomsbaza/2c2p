using System;
using System.Diagnostics.Metrics;

namespace _2c2p;
class Program
{
    static void Main(string[] args)
    {
        int[] lists = { 10, 11, 23, 45, 11, 12, 10, 10, 10, 11, 23 };
        var countValue = new Dictionary<int, int>();

        // Method 1
        // วนหาว่าเจอตัวเลขนี้ใน list นั้นมี key ซ้ำกับที่มีอยู่ไหม ถ้าซ้ำให้ +1 value ของ item นั้นๆ
        // กรณีเจอครั้งแรกให้ value ตั้งต้นคือ 1
        // จะได้ countValue ที่เป็น dic มี key คือเลขใน lists และ value ที่ได้จากการ check ว่าซ้ำหรือไม่
        //foreach (var item in lists)
        //{
        //    if (countValue.ContainsKey(item))
        //    {
        //        countValue[item]++;
        //    }
        //    else
        //    {
        //        countValue[item] = 1;
        //    }
        //}

        // Method 2
        // ใช้ linq GroupBy
        countValue = lists.GroupBy(x => x).ToDictionary(g => g.Key, g => g.Count());


        // ใช้ linq Aggregate เช็คเปรียบเทียบ value ใน dic แต่ละจุดว่าเลขไหนมี value มากกว่ากัน
        // กรณีที่ x (ตัวเก่า) มีค่ามากกว่า y (ตัวใหม่) ให้คง x ไว้ว่ามากสุด
        // กรณีที่ y (ตัวใหม่) มีค่ามากกว่า x (ตัวเก่า) ให้แทน x ด้วย y เพราะมากว่า
        // เช็ํคไปเรื่อยๆจนหมด lists แล้วดึง key ออกมาจะได้ key คือเลขอะไรที่ซ้ำมากที่สุด
        var mostDup = countValue.Aggregate((x, y) => x.Value > y.Value ? x : y).Key;

        // เอา Key เลขที่มากสุดมาใส่เพื่อหาว่ามีจำนวนซ้ำทั้งหมดกี่ตัว(Value)
        int maxCount = countValue[mostDup];
    }
}
