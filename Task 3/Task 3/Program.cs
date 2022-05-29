using System;
using System.Text;
class Program
{
    // 1. Додати в клас Vector метод, який перевіряє, чи поле є паліндромом.
    // 2. Додати в клас Vector метод, який реверсує елементи масиву.
    // 3. Додати в клас Vector метод, який в масиві знаходить  найдовшу підпослідовність однакових чисел.
    // 4. У класі Matrix створити метод, який заповнює квадратну матрицю діагональною змійкою, параметром методу має бути напрям початкового повороту змійки (вправо, чи вниз), заданий змінною типу Enum.
    // 5. Оптимізувати метод InitShufle класу Vector, створений на занятті.
    // Додаткове завдання. Дано цілочисельна прямокутна матриця. Знайти прямокутник найбільшої площі, заповнений однаковими числами.
    static void Main(string[] args)
    {

        Console.OutputEncoding = UTF8Encoding.UTF8; // Ukrainian output in console

        Console.WriteLine("1. Завдання 1-3");
        Console.WriteLine("2. Завдання 4");
        Console.WriteLine("3. Додаткове завдання");
        Console.Write("Виберіть номер завдання: ");
        int choice = Convert.ToInt32(Console.ReadLine());
        Console.Clear();

        if (choice == 1)
        {
            Console.Write("Задайте кількість елементів массиву: ");
            int n = Convert.ToInt32(Console.ReadLine());
            Console.Write("Задайте перший індекс поля массиву, який бажаєте перевірити на палідромність: ");
            int firstIndex = Convert.ToInt32(Console.ReadLine());
            Console.Write("Задайте останній індекс поля массиву, який бажаєте перевірити на палідромність: ");
            int secondIndex = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            Vector arr = new Vector(n);
            arr.InitShufle(1, 5);
            Console.WriteLine($"Массив: {arr}");
            bool palidrom = arr.palindromeCheck(firstIndex, secondIndex);
            Console.WriteLine($"Поле [{firstIndex}]-[{secondIndex}] є палідромом: {palidrom}");
            arr.arrayReverse();
            Console.WriteLine($"Реверсивний массив: {arr}");
            arr.sequence();
        }
        else if (choice == 2)
        {
            Console.Write("Введіть кількість рядків матриці: ");
            int n = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введіть кількість стовпців матриці: ");
            int m = Convert.ToInt32(Console.ReadLine());
            Console.Write("Виберіть напрям початкового повороту змійки (1 - вниз, 2 - вправо): ");
            choice = Convert.ToInt32(Console.ReadLine());
            Matrix matrix = new Matrix();
            if (choice == 1)
            {
                matrix.matrixDiagonalSnake(n, m, MatrixDirection.Down);
            }
            else if (choice == 2)
            {
                matrix.matrixDiagonalSnake(n, m, MatrixDirection.Right);
            }
        }
        else if (choice == 3)
        {
            Console.Write("Введіть кількість рядків матриці: ");
            int n = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введіть кількість стовпців матриці: ");
            int m = Convert.ToInt32(Console.ReadLine());
            Matrix matrix = new Matrix();
            matrix.matrixSquare(n, m);
        }
    }
}