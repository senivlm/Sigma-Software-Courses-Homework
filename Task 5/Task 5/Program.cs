using System;
using System.Text;
class Program
{
    // 1. Змінити метод сортування злиттям, враховуючи обмеження,
    // що елементи для сортування розташовані в файлі і в програмі можна використовувати тільки масиви,
    // кількість елементів яких вдвічі менша за кількість елементів в файлі.
    // P.S. Як я зрозумів завдання: в пам'яті не може бути більше одного масиву з кількістю елементів вдічі мешною, ніж у кінцевому файлі. Умову виконав.
    
    // 2. Реалізувати в класі Vector метод пірамідального сортування.
    static void Main()
    {
        Console.Write("Enter the number of matrix elements: ");
        int n = Convert.ToInt32(Console.ReadLine());

        // Task 1
        Console.WriteLine("\nTask 1:");
        Vector vector = new(n);
        vector.RandomInitialization(1, n);
        using (StreamWriter unsortedArrayFile = new("D:\\Sigma-Software-Courses-Homework\\Task 5\\Task 5\\arrays\\Unsorted Array.txt"))
        {
            unsortedArrayFile.Write(vector.ToString());
        }
        Vector.MergeSortFromFile("D:\\Sigma-Software-Courses-Homework\\Task 5\\Task 5\\arrays\\");
        Console.WriteLine("Sorted Array in file!");

        //Task 2
        Console.WriteLine("\nTask 2:");
        Vector vectorHeap = new(n);
        vectorHeap.RandomInitialization(1, n);
        Console.WriteLine("Unsorted Array: " + vectorHeap.ToString());
        vectorHeap.HeapSort(n);
        Console.WriteLine("Sorted Array: " + vectorHeap.ToString());
    }
}