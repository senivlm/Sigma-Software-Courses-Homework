using System;
using System.Text;
class Program
{// Ваш код 20.
    // В класі вектор реалізуваті швидке сортування. Вибрати опорний елемент: як середній елемент масиву, перший та останній. Всі варіанти методів реалізувати.
    static void Main(string[] args)
    {
        Console.OutputEncoding = UTF8Encoding.UTF8;

        Console.Write("Введіть кількість елементів матриці: ");
        int n = Convert.ToInt32(Console.ReadLine());
        Console.Write("Виберіть опорний елемент при сортуванні (1 - перший, 2 - останній, 3 - середній): ");
        int pos = Convert.ToInt32(Console.ReadLine());
        
        Vector vector = new Vector(n);
        vector.RandomInitialization(0,n);
        Console.WriteLine("Массив: " + vector.ToString());
        
        switch (pos)
        {
            case 1: vector.QuickSort(0, n - 1, IndexPos.First); break;
            case 2: vector.QuickSort(0, n - 1, IndexPos.Last); break;
            case 3: vector.QuickSort(0, n - 1, IndexPos.Middle); break;
        }
        Console.WriteLine("Відсортирований массив: " + vector.ToString());
    }
}
