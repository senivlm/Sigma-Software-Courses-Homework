using System;
using System.Text;

namespace Task_1
{
    public static class Program
    {
        // 1. Клас Product, який має три елемент-даних – назва, ціна і вага.
        // 2. Клас Buy, містить дані про товар, кількість товару, що купується в штуках, про ціну за весь куплений товар і про вагу товару.
        // 3. Клас Check, що не містить ніяких елементів-даних. Даний клас повинен виводити на екран інформацію про товар і про покупку.
        // 4. Створити конструктори класів, визначити властивості з різними модифікаторами.
        // 5. Продемонструвати створення екземплярів класів.
        public static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            UserInterface userInterface = new();
            userInterface.StartUp();
        }
    }
}