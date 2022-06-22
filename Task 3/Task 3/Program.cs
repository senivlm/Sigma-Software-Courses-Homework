using System;
using System.Text;

namespace Task_3
{
    class Program
    {
        // 1. Додати в клас Vector метод, який перевіряє, чи поле є паліндромом.
        // 2. Додати в клас Vector метод, який реверсує елементи масиву.
        // 3. Додати в клас Vector метод, який в масиві знаходить  найдовшу підпослідовність однакових чисел.
        // 4. У класі Matrix створити метод, який заповнює квадратну матрицю діагональною змійкою, параметром методу має бути напрям початкового повороту змійки (вправо, чи вниз), заданий змінною типу Enum.
        // 5. Оптимізувати метод InitShufle класу Vector, створений на занятті.
        // Додаткове завдання. Дано цілочисельна прямокутна матриця. Знайти прямокутник найбільшої площі, заповнений однаковими числами.
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;

            try
            {
                Console.WriteLine("1. Завдання 1-3");
                Console.WriteLine("2. Завдання 4");
                Console.WriteLine("3. Завдання 5");
                Console.WriteLine("4. Додаткове завдання");
                Console.Write("Виберіть номер завдання: ");
                int choice = Convert.ToInt32(Console.ReadLine());
                Console.Clear();

                switch (choice)
                {
                    case 1:
                        {
                            Console.Write("Задайте кількість елементів массиву: ");
                            int n = Convert.ToInt32(Console.ReadLine());
                            Vector arr = new(n);

                            Console.Write("Задайте перший індекс поля массиву, який бажаєте перевірити на палідромність: ");
                            int firstIndex = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Задайте останній індекс поля массиву, який бажаєте перевірити на палідромність: ");
                            int secondIndex = Convert.ToInt32(Console.ReadLine());
                            if (firstIndex < 0 || firstIndex > n || firstIndex > secondIndex || secondIndex < 0 || secondIndex > n)
                            {
                                throw new Exception("Індекс некоректний!");
                            }
                            Console.Clear();

                            arr.RandomInitialization(1, 5);
                            Console.WriteLine($"Массив: {arr}");
                            Console.WriteLine($"Поле [{firstIndex}]-[{secondIndex}] є палідромом: {arr.PalindromeCheck(firstIndex, secondIndex)}");
                            arr.ArrayReverse();
                            Console.WriteLine($"Реверсивний массив: {arr}");
                            Console.WriteLine($"Перший індекс найдовшої послідовності одинакових чисел: [{arr.Sequence()}]");
                            break;
                        }
                    case 2:
                        {
                            Console.Write("Введіть кількість рядків матриці: ");
                            int n = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Введіть кількість стовпців матриці: ");
                            int m = Convert.ToInt32(Console.ReadLine());
                            Matrix matrix = new(n, m);

                            Console.Write("Виберіть напрям початкового повороту змійки (1 - вниз, 2 - вправо): ");
                            choice = Convert.ToInt32(Console.ReadLine());
                            
                            switch (choice)
                            {
                                case 1: matrix.MatrixDiagonalSnake(MatrixDirection.Down); break;
                                case 2: matrix.MatrixDiagonalSnake(MatrixDirection.Right); break;
                                default: throw new Exception("Даний номер не відповідає ні одній з функцій!");
                            }
                            matrix.ArrayOutput();
                            break;
                        }
                    case 3:
                        {
                            Console.Write("Задайте кількість елементів массиву: ");
                            int n = Convert.ToInt32(Console.ReadLine());
                            Vector arr = new(n);
                            arr.ShufleInitialization();
                            Console.WriteLine("Массив: " + arr);
                            break;
                        }
                    case 4:
                        {
                            Console.Write("Введіть кількість рядків матриці: ");
                            int n = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Введіть кількість стовпців матриці: ");
                            int m = Convert.ToInt32(Console.ReadLine());
                            Matrix matrix = new(n, m);

                            matrix.MatrixRandomInitialization(1, 5); // can be custom
                            matrix.ArrayOutput();
                            matrix.MatrixSquare(out int i, out int j);
                            Console.WriteLine($"Індекс першого елементу прямокутника: [{i},{j}].");
                            break;
                        }
                    default: throw new Exception("Даний номер не відповідає ні одній з функцій!");
                }
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