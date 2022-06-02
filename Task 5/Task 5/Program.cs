using System;
using System.Text;
class Program
{
    // 1. Змінити метод сортування злиттям, враховуючи обмеження,
    // що елементи для сортування розташовані в файлі і в програмі можна використовувати тільки масиви,
    // кількість елементів яких вдвічі менша за кількість елементів в файлі.
    // P.S. Поки не найшов виходу як брати дані з файлу без використання масивів (в мене все рівно все упирається в string).
    
    // 2. Реалізувати в класі Vector метод пірамідального сортування.
    static void Main(string[] args)
    {
        Console.Write("Enter the number of matrix elements: ");
        int n = Convert.ToInt32(Console.ReadLine());

        // Task 1
        Vector vector = new(n);
        vector.InitShufle();
        using (StreamWriter unsortedArrayFile = new("D:\\Sigma-Software-Courses-Homework\\Task 5\\Task 5\\Unsorted Array.txt"))
        {
            unsortedArrayFile.Write(vector.ToString());
        }
        Vector.MergeSortFromFile("D:\\Sigma-Software-Courses-Homework\\Task 5\\Task 5\\");
        

        //Task 2
        Vector vectorHeap = new(n);
        vectorHeap.RandomInitialization(1, n);
        Console.WriteLine("Unsorted Array: " + vectorHeap.ToString());
        vectorHeap.HeapSort(n);
        Console.WriteLine("Sorted Array: " + vectorHeap.ToString());
    }
}