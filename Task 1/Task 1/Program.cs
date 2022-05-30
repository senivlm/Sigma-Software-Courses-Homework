using System;
using System.Text;

public static class Program
{
    public static void Main()
    {
        Console.OutputEncoding = UTF8Encoding.UTF8;
        Buy buy = new();
        buy.AddStorage(new Product("Цукор", 28, 1000));
        buy.AddStorage(new Product("Хліб", 22, 350));
        buy.AddStorage(new Product("Макарони", 97, 500));
        buy.AddStorage(new Product("Сіль", 20, 350));

        Interface userInterface = new(buy);
        userInterface.Menu();
    }
}
