using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace syap1
{
    class Program
    {
        static void Create(out Set set)
        {
            string answer;
            while (true)
            {
                Console.WriteLine("Выберите способ представления\n1 - Логический\n2 - Битовый\n3 - Мультимножество");
                answer = Console.ReadLine();
                if (!(answer == "1" || answer == "2" || answer == "3"))
                    Console.WriteLine("\nНекорректный ввод\n");
                else
                    break;
            }

            int max;
            while (true)
            {
                Console.WriteLine("Введите максимальный элемент");
                if (int.TryParse(Console.ReadLine(), out max))
                    break;
                else
                    Console.WriteLine("\nНекорректный ввод\n");
            }

            if (answer == "1")
                set = new SimpleSet(max);
            else
                if (answer == "2")
                set = new BitSet(max);
            else
                set = new MultiSet(max);
        }
        static void Insert(Set set)
        {
            int elem = -1;
            bool flag = true;
            while (true)
            {
                Console.WriteLine("Введите элемент для добавления");
                if (int.TryParse(Console.ReadLine(), out elem))
                    break;
                else
                    Console.WriteLine("\nНекорректный ввод\n");
            }
            try
            {
                set.Insert(elem);
            }
            catch (SetExceptionOutOfRange e)
            {
                Console.WriteLine("\nНеудалось добавить элемент: " + e.Message + "\n");
                flag = false;
            }
            if (flag)
                Console.WriteLine("\nЭлемент успешно вставлен в множество.\n");
        }
        static void Delete(Set set)
        {
            int elem = -1;
            bool flag = true;
            while (true)
            {
                Console.WriteLine("Введите элемент для исключения");
                if (int.TryParse(Console.ReadLine(), out elem))
                    break;
                else
                    Console.WriteLine("\nНекорректный ввод\n");
            }
            try
            {
                set.Delete(elem);
            }
            catch(SetExceptionOutOfRange e)
            {
                Console.WriteLine("\nНеудалось исключить элемент: " + e.Message + "\n");
                flag = false;
            }
            catch(SetExceptionDelete)
            {

            }
            if (flag)
            Console.WriteLine("\nЭлемент успешно исключен из множества.\n");
        }
        static void Find(Set set)
        {
            int elem = -1;
            while (true)
            {
                Console.WriteLine("Введите искомый элемент");
                if (int.TryParse(Console.ReadLine(), out elem))
                    break;
                else
                    Console.WriteLine("\nНекорректный ввод\n");
            }
            if (set.Found(elem))
                Console.WriteLine("\nЭлемент найден.\n");
            else
                Console.WriteLine("\nЭлемент не найден.\n");
        }
        static void SetWork(Set set)
        {
            while (true)
            {
                Console.WriteLine("Выберите действие\n1 - Добавить элемент\n2 - Исключить элемент\n3 - Найти элемент\n4 - Показать множество\n5 - Выход");
                string answer = Console.ReadLine();
                if (answer == "1")
                    Insert(set);
                else
                    if (answer == "2")
                    Delete(set);
                else
                    if (answer == "3")
                    Find(set);
                else
                    if (answer == "4")
                    set.Show();
                else
                    if (answer == "5")
                    break;
                else
                    Console.WriteLine("\nНекорректный ввод\n");
            }
        }
        static void Dialog()
        {
            Set set = null;

            Create(out set);

            bool flag;
            do
            {
                Console.WriteLine("Введите элементы множества");
                string str = Console.ReadLine();
                try
                {
                    set.FillSet(str);
                    flag = true;
                }
                catch (SetExceptionOutOfRange e)
                {
                    Console.WriteLine(e.Message);
                    flag = false;
                }
            }
            while (!flag);
                SetWork(set);            
        }
        static void TestUI()
        {
            int maxA = 0, maxB = 0;
            while (true)
            {
                Console.WriteLine("Введите максимальный элемент множества А");
                if (int.TryParse(Console.ReadLine(), out maxA))
                    break;
                else
                    Console.WriteLine("\nНекорректный ввод\n");
            }
            while (true)
            {
                Console.WriteLine("Введите максимальный элемент множества B");
                if (int.TryParse(Console.ReadLine(), out maxB))
                    break;
                else
                    Console.WriteLine("\nНекорректный ввод\n");
            }

            Console.WriteLine("Введите элементы множества А");
            string a = Console.ReadLine();
            Console.WriteLine("Введите элементы множества B");
            string b = Console.ReadLine();

            SimpleSet sA = new SimpleSet(maxA);
            SimpleSet sB = new SimpleSet(maxB);

            BitSet bA = new BitSet(maxA);
            BitSet bB = new BitSet(maxB);

            sA.FillSet(a);
            sB.FillSet(b);
            bA.FillSet(a);
            bB.FillSet(b);

            SimpleSet sUnion = sA + sB;
            SimpleSet sIntersection = sA * sB;

            BitSet bUnion = bA + bB;
            BitSet bIntersection = bA * bB;

            Console.WriteLine("\nA + B\nSimpleSet:");
            sUnion.Show();
            Console.WriteLine("BitSet:");
            bUnion.Show();

            Console.WriteLine("\nA * B\nSimpleSet:");
            sIntersection.Show();
            Console.WriteLine("BitSet:");
            bIntersection.Show();

            Console.ReadKey();
        }
        static void Main(string[] args)
        {
            string answer = "";
            while(true)
            {
                Console.WriteLine("Выберите режим работы\n1 - Диалог\n2 - Тестирование операторных методов");
                answer = Console.ReadLine();
                if (!(answer == "1" || answer == "2"))
                    Console.WriteLine("\nНекорректный ввод\n");
                else
                    break;
            }
            if (answer == "1")
                Dialog();
            else
                TestUI();
        }
    }
}
