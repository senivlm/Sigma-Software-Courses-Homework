using System;
using System.Text;

namespace Task_4
{
    class Program
    {
        // В класі вектор реалізуваті швидке сортування. Вибрати опорний елемент: як середній елемент масиву, перший та останній. Всі варіанти методів реалізувати.
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            try
            {
                Console.Write("Введіть кількість елементів матриці: ");
                int n = Convert.ToInt32(Console.ReadLine());
                Vector vector = new(n);

                Console.Write("Виберіть опорний елемент при сортуванні (1 - перший, 2 - останній, 3 - середній): ");
                int pos = Convert.ToInt32(Console.ReadLine());

                vector.RandomInitialization(0, n);
                Console.WriteLine("Массив: " + vector.ToString());

                switch (pos)
                {
                    case 1: vector.QuickSort(0, n - 1, IndexPos.First); break;
                    case 2: vector.QuickSort(0, n - 1, IndexPos.Last); break;
                    case 3: vector.QuickSort(0, n - 1, IndexPos.Middle); break;
                    default: throw new Exception("Даний номер не відповідає ні одній з функцій!");
                }
                Console.WriteLine("Відсортирований массив: " + vector.ToString());
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ResetColor();
            }
        }
    }
}