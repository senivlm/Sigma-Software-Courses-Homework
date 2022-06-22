class Interface
{
    private Buy buy;
    public void StartUp()
    {
        Buy.AddStorage(new Product("Цукор", 28, 1000));
        Buy.AddStorage(new Product("Хліб", 22, 350));
        Buy.AddStorage(new Product("Макарони", 97, 500));
        Buy.AddStorage(new Product("Сіль", 20, 350));
        buy = new Buy();
        Menu();
    }

    private void Menu()
    {
        Console.WriteLine("Функції:");
        Console.WriteLine("1. Переглянути список товарів");
        Console.WriteLine("2. Переглянути список покупок");
        Console.WriteLine("3. Додати товар у кошик");
        Console.WriteLine("4. Видалити товар з кошику");
        Console.WriteLine("5. Вивести чек");
        Console.Write("Виберіть функцію: ");
        try
        {
            int input = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            switch (input)
            {
                case 1: StorageOutput(); break;
                case 2: PurchaseOutput(); break;
                case 3: AddProductToPurchases(); break;
                case 4: RemoveProductToPurchases(); break;
                case 5: CheckOutput(); break;
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
        Buy.StorageOutput();
        BackToMenu();
    }

    private void AddProductToPurchases()
    {
        Buy.StorageOutput();
        Console.Write("Введіть індекс товару, який бажаєте додати у кошик: ");
        int index = Convert.ToInt32(Console.ReadLine());
        if (Buy.ProductInStorage(index) == null)
        {
            throw new Exception("Введене число не відповідає індексу ні одного з продуктів!");
        }
        buy.AddPurchase(Buy.GetProductFromStorage(index));
        Console.WriteLine("Товар успішно додано!");
        BackToMenu();
    }

    private void RemoveProductToPurchases()
    {
        buy.PuchaseOutput();
        Console.Write("Введіть індекс товару, який бажаєте видалити із кошика: ");
        int index = Convert.ToInt32(Console.ReadLine());
        if (buy.ProductInPurchase(index) == null)
        {
            throw new Exception("Введене число не відповідає індексу ні одного з продуктів!");
        }
        buy.RemovePurchase(buy.GetProductFromPurchase(index));
        Console.WriteLine("Товар успішно видалено!");
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
