using System;
using System.Text;

namespace Task_2_Problem_2
{
    public static class Program
    {
        // 1. Створити клас для роботи з прямокутними матрицями.
        // 2. Заповнення матриці має здійснюватися в межах класу та може відбуватись за різними законами.
        // 3. Заповнення матриці у вигляді вертикальної змійки.
        // 4. Заповнення матриці у вигляді діагональної змійки для квадратної матриці.
        // 5. Заповнення матриці у вигляді спіральної змійки.

        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;

            try
            {
                Console.Write("Введіть кількість стовпців матриці: ");
                int n = Convert.ToInt32(Console.ReadLine());
                Console.Write("Введіть кількість рядків матриці: ");
                int m = Convert.ToInt32(Console.ReadLine());
                Array array = new(n, m);
                Console.Clear();

                Console.WriteLine($"Типи матриць (C:{n}, R:{m}).");
                Console.WriteLine("1. Вертикальна змійка");
                Console.WriteLine("2. Діагональна змійка");
                Console.WriteLine("3. Спіральна змійка");
                Console.Write("Виберіть тип матриці: ");
                int type = Convert.ToInt32(Console.ReadLine());
                Console.Clear();

                if (type == 3 && n != m)
                {
                    throw new Exception("Даний тип матриці доступний тільки для квадратної матриці!");
                }

                switch (type)
                {
                    case 1: array.ArrayVerticalSnake(); break;
                    case 2: array.ArrayDiagonalSnake(); break;
                    case 3: array.ArraySpiralSnake(); break;
                    default: throw new Exception("Введене число не відповідає ні одній з функцій!");
                }
                array.ArrayOutput();
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