using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LAB1
{
    internal class Program
    {
        static int x;
        static int index;

        public static void PrintArr(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();
        }
        public static void PrintList(List<int> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                Console.Write(list[i] + " ");
            }
            Console.WriteLine();
        }
        static int ArrSearchThrough(int[] arr, int x)
        {
            int i = 0;
            while (i < arr.Length)
            {
                if (arr[i] == x)
                {
                    return i;
                }
                i++;
            }
            return -1;
        }
        static int ListSearchThrough(List<int> list, int x)
        {
            int i = 0;
            while (i < list.Count)
            {
                if (list[i] == x) return i;
                i++;
            }
            return -1;
        }
        static int ArrSearchBarrier(int[] arr, int x)
        {
            Array.Resize(ref arr, arr.Length + 1);
            arr[arr.Length - 1] = x;

            int i = 0;
            while (arr[i] != x) i++;
            return i;
        }
        static int ListSearchBarrier(List<int> list, int x)
        {
            list.Add(x);
            int i = 0;
            while (list[i] != x) i++;
            list.RemoveAt(list.Count - 1);
            return i;
        }
        static int ArrBinarySearch(int[] arr, int x)
        {
            int L = 0;
            int R = arr.Length - 1;
            while (L <= R)
            {
                int i = (L + R) / 2;
                if (arr[i] == x) return i;
                else if (arr[i] < x) L = i + 1;
                else if (arr[i] > x) R = i - 1;
            }
            return -1;
        }
        static int ListBinarySearch(List<int> list, int x)
        {
            int L = 0;
            int R = list.Count - 1;
            while (L <= R)
            {
                int i = (L + R) / 2;
                if (list[i] == x) return i;
                else if (list[i] < x) L = i + 1;
                else if (list[i] > x) R = i - 1;
            }
            return -1;
        }
        static int ArrGoldenSearch(int[] arr, int x)
        {
            int L = 0;
            int R = arr.Length - 1;
            while (L < R)
            {
                int i = (int)((R - L) / 1.618 + L);
                if (arr[i] == x) return i;
                else if (arr[i] < x) L = i + 1;
                else if (arr[i] > x) R = i - 1;
            }
            return -1;
        }
        static int ListGoldenSearch(List<int> list, int x)
        {
            int L = 0;
            int R = list.Count - 1;
            while (L <= R)
            {
                int i = (int)((R - L) / 1.618 + L);
                if (list[i] == x) return i;
                else if (list[i] < x) L = i + 1;
                else if (list[i] > x) R = i - 1;
            }
            return -1;
        }
        public static void F1(List<int> list, int[] arr, Stopwatch time, int size, Random rndm) 
        {
            if (size <= 30)
            {
                Console.Write("\nВведiть шукане число: ");
                x = Convert.ToInt32(Console.ReadLine());
            }
            else x = rndm.Next(-10000, 10000);
            time.Start();
            index = ArrSearchThrough(arr, x);
            time.Stop();
            Console.WriteLine("\n\t--МАСИВ--");
            if (index != -1) Console.WriteLine("\nЧисло " + x + " має iндекс: " + (index + 1));
            else Console.WriteLine("Число " + x + " відсутнє");
            Console.WriteLine("Час пошуку - " + time.Elapsed);
            time.Reset();

            time.Start();
            index = ListSearchThrough(list, x);
            time.Stop();
            Console.WriteLine("\n\t--СПИСОК--");
            if (index != -1) Console.WriteLine("\nЧисло " + x + " має iндекс: " + (index + 1));
            else Console.WriteLine("Число " + x + " відсутнє");
            Console.WriteLine("Час пошуку - " + time.Elapsed);
        }
        public static void F2(List<int> list, int[] arr, Stopwatch time, int size, Random rndm)
        {
            if (size <= 30)
            {
                Console.Write("\nВведiть шукане число: ");
                x = Convert.ToInt32(Console.ReadLine());
            }
            else x = rndm.Next(-10000, 10000);

            time.Start();
            index = ArrSearchBarrier(arr, x);
            time.Stop();

            Console.WriteLine("\n\t--МАСИВ--");
            if (index < arr.Length) Console.WriteLine("\nЧисло " + x + " має iндекс: " + (index + 1));
            else Console.WriteLine("Число " + x + " відсутнє");
            Console.WriteLine("Час пошуку - " + time.Elapsed);
            time.Reset();

            time.Start();
            index = ListSearchBarrier(list, x);
            time.Stop();

            Console.WriteLine("\n\t--СПИСОК--");
            if (index < list.Count) Console.WriteLine("\nЧисло " + x + " має iндекс: " + (index + 1));
            else Console.WriteLine("Число " + x + " відсутнє");
            Console.WriteLine("Час пошуку - " + time.Elapsed);
        }
        public static void F3(List<int> list, int[] arr, Stopwatch time, int size, Random rndm)
        {
            if (size <= 30)
            {
                Console.Write("\nВідсортований масив: "); PrintArr(arr);
                Console.Write("Відсортований список: "); PrintList(list);
                Console.Write("\nВведiть шукане число: ");
                x = Convert.ToInt32(Console.ReadLine());
            }
            else x = rndm.Next(-10000, 10000);

            time.Start();
            index = ArrBinarySearch(arr, x);
            time.Stop();

            Console.WriteLine("\n\t--МАСИВ--");
            if (index != -1) Console.WriteLine("\nЧисло " + x + " має iндекс: " + (index + 1));
            else Console.WriteLine("Число " + x + " відсутнє");
            Console.WriteLine("Час пошуку - " + time.Elapsed);
            time.Reset();

            time.Start();
            index = ListBinarySearch(list, x);
            time.Stop();

            Console.WriteLine("\n\t--СПИСОК--");
            if (index != -1) Console.WriteLine("\nЧисло " + x + " має iндекс: " + (index + 1));
            else Console.WriteLine("Число " + x + " відсутнє");
            Console.WriteLine("Час пошуку - " + time.Elapsed);
        }
        public static void F4(List<int> list, int[] arr, Stopwatch time, int size, Random rndm)
        {
            if (size <= 30)
            {
                Console.Write("\nВідсортований масив: "); PrintArr(arr);
                Console.Write("Відсортований список: "); PrintList(list);
                Console.Write("\nВведiть шукане число: ");
                x = Convert.ToInt32(Console.ReadLine());
            }
            else x = rndm.Next(-10000, 10000);

            time.Start();
            index = ArrGoldenSearch(arr, x);
            time.Stop();

            Console.WriteLine("\n\t--МАСИВ--");
            if (index != -1) Console.WriteLine("\nЧисло " + x + " має iндекс: " + (index + 1));
            else Console.WriteLine("Число " + x + " відсутнє");
            Console.WriteLine("Час пошуку - " + time.Elapsed);
            time.Reset();

            time.Start();
            index = ListGoldenSearch(list, x);
            time.Stop();

            Console.WriteLine("\n\t--СПИСОК--");
            if (index != -1) Console.WriteLine("\nЧисло " + x + " має iндекс: " + (index + 1));
            else Console.WriteLine("Число " + x + " відсутнє");
            Console.WriteLine("Час пошуку - " + time.Elapsed);
        }

        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Stopwatch time = new Stopwatch();
            Random random = new Random();

            byte l;

            Console.Write("Введiть розмір масиву (якщо розмір " +
                "> 30 - шукане число генерується випадково): ");
            int size = Convert.ToInt32(Console.ReadLine());

            int[] arr = new int[size];
            List<int> list = new List<int>();

            for (int i = 0; i < arr.Length; i++)
            {
                if (size > 30) x = random.Next(-10000, 10001);
                else x = random.Next(-50, 51);
                arr[i] = x;
                list.Add(x);
            }

            int[] arr2 = new int[arr.Length];
            List<int> list2 = new List<int>();

            Array.Copy(arr, arr2, arr.Length);
            foreach (int i in list)
            {
                list2.Add(i);
            }

            Array.Sort(arr2);
            list2.Sort();

            do
            {
                time.Reset();
                Console.Clear();
                if (size <= 30)
                {
                    Console.Write("Масив: "); PrintArr(arr);
                    Console.Write("Список: "); PrintList(list);
                    Console.WriteLine();
                }
                Console.WriteLine("1 - пошук перебором");
                Console.WriteLine("2 - пошук iз бар'єром");
                Console.WriteLine("3 - бінарний пошук");
                Console.WriteLine("4 - бінарний пошук з золотим перерізом");
                Console.WriteLine("0 - вихід");
                Console.Write("Введіть номер команди: ");
                if (byte.TryParse(Console.ReadLine(), out l))
                {
                    switch (l)
                    {
                        case 1:
                            F1(list, arr, time, size, random);
                            Console.ReadKey();
                            break;
                        case 2:
                            F2(list, arr, time, size, random);
                            Console.ReadKey();
                            break;
                        case 3:
                            F3(list2, arr2, time, size, random);
                            Console.ReadKey();
                            break;
                        case 4:
                            F4(list2, arr2, time, size, random);
                            Console.ReadKey();
                            break;
                        case 0:
                            break;
                        default:
                            continue;
                    }
                }
                else l = 1;
            } while (l != 0) ;
        }
    }
}
