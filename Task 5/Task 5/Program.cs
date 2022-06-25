using System;
using System.Text;

namespace Task_5
{
    class Program
    {
        // 1. Змінити метод сортування злиттям, враховуючи обмеження,
        // що елементи для сортування розташовані в файлі і в програмі можна використовувати тільки масиви,
        // кількість елементів яких вдвічі менша за кількість елементів в файлі.

        // 2. Реалізувати в класі Vector метод пірамідального сортування.
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8; // Ukrainian symbols in console   
            try
            {
                Console.Write("Enter the number of matrix elements: ");
                int n = Convert.ToInt32(Console.ReadLine());

                // Task 1
                string path = "..\\..\\..\\data\\"; // change path here
                Vector.FilesExistsCheck(path); // check if all files exists for Task 1

                // Random initialization an array and writing to Unsorted Array.txt
                Console.WriteLine("\nTask 1:");
                Vector vectorMerge = new(n); // exception checking is in Constructor
                vectorMerge.RandomInitialization(1, n + 1);
                using (StreamWriter unsortedArrayFile = new(path + "Unsorted Array.txt"))
                {
                    unsortedArrayFile.Write(vectorMerge.ToString());
                }

                // Sorting an array and writing to Sorted Array.txt
                Vector.MergeSortFromFile(path);
                Console.WriteLine("Sorted Array in file!");

                File.Delete(path + "Sorted Array First Part.txt");
                File.Delete(path + "Sorted Array Second Part.txt");

                // Task 2
                Console.WriteLine("\nTask 2:");
                Vector vectorHeap = new(n);
                vectorHeap.RandomInitialization(1, n + 1);
                Console.WriteLine("Unsorted Array: " + vectorHeap.ToString());
                vectorHeap.HeapSort();
                Console.WriteLine("Sorted Array: " + vectorHeap.ToString());
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