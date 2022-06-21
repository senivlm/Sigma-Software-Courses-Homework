﻿class Interface
{
    private Buy buy;
    
    public void StartUp()
    {
        buy = new Buy();
        buy.AddStorage(new Product("Цукор", 28, 1000));
        buy.AddStorage(new Product("Хліб", 22, 350));
        buy.AddStorage(new Product("Макарони", 97, 500));
        buy.AddStorage(new Product("Сіль", 20, 350));
        Menu();
    }

    private void Menu()
    {
        Console.WriteLine("Функції:");
        Console.WriteLine("1. Переглянути список товарів");
        Console.WriteLine("2. Додати товар у кошик");
        Console.WriteLine("3. Переглянути список покупок");
        Console.WriteLine("4. Вивести чек");
        Console.Write("Виберіть функцію: ");
        try
        {
            int input = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            switch (input)
            {
                case 1: StorageOutput(); break;
                case 2: AddProductToPurchases(); break;
                case 3: PurchaseOutput(); break;
                case 4: CheckOutput(); break;
                default: throw new Exception("Введене число не відповідає номеру ні одній із функцій!");
            }
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(ex.Message);
            Console.ResetColor();
        }
    }
    
    private void StorageOutput()
    {
        buy.StorageOutput();
        BackToMenu();
    }

    private void AddProductToPurchases()
    {
        buy.StorageOutput();
        Console.Write("Введіть індекс товару, який бажаєте додати у кошик: ");
        int index = Convert.ToInt32(Console.ReadLine());
        if (buy.listStorage.ElementAtOrDefault(index) == null)
        {
            throw new Exception("Введене число не відповідає індексу ні одного з продуктів!");
        }
        buy.AddPurchase(buy.listStorage[index]);
        Console.WriteLine("Товар успішно додано!");
        BackToMenu();
    }

    private void PurchaseOutput()
    {
        buy.PuchaseOutput();
        BackToMenu();
    }

    private void CheckOutput()
    {
        buy.PuchaseOutput();
        Check.Purchase(buy);
        BackToMenu();
    }

    private void BackToMenu()
    {
        Console.Write("Нажміть будь-яку клавішу, щоб повернутися до меню...");
        Console.ReadKey();
        Console.Clear();
        Menu();
    }
}
