using System;
using System.Text;
class Program
{
    // В класі вектор реалізуваті швидке сортування. Вибрати опорний елемент: як середній елемент масиву, перший та останній. Всі варіанти методів реалізувати.
    static void Main(string[] args)
    {
        Console.OutputEncoding = UTF8Encoding.UTF8;

        Console.Write("Введіть кількість елементів матриці: ");
        int n = Convert.ToInt32(Console.ReadLine());
        Console.Write("Виберіть опорний елемент при сортуванні (1 - перший, 2 - останній, 3 - середній): ");
        int pos = Convert.ToInt32(Console.ReadLine());
        Random random = new Random();
        Vector vector = new Vector(n);
        vector.RandomInitialization(0,10);
        string output = vector.ToString();
        Console.WriteLine("Массив: " + output);
        switch (pos)
        {
            case 1: vector.QuickSort(0, n - 1, IndexPos.first); break;
            case 2: vector.QuickSort(0, n - 1, IndexPos.last); break;
            case 3: vector.QuickSort(0, n - 1, IndexPos.middle); break;
        }
        output = vector.ToString();
        Console.WriteLine("Відсортирований массив: " + output);
    }
}