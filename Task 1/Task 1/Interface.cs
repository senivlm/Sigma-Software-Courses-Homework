class Interface
{
    readonly Buy buy;

    public Interface(Buy buy)
    {
        this.buy = buy;
    }
    public void Menu()
    {
        Console.WriteLine("Функції:");
        Console.WriteLine("1. Переглянути список товарів");
        Console.WriteLine("2. Додати товар у кошик");
        Console.WriteLine("3. Переглянути список покупок");
        Console.WriteLine("4. Вивести чек");
        Console.Write("Виберіть функцію: ");
        int input = Convert.ToInt32(Console.ReadLine());
        Console.Clear();
        switch (input)
        {
            case 1: FunctionOne(); break;
            case 2: FunctionTwo(); break;
            case 3: FunctionThree(); break;
            case 4: FunctionFour(); break;
        }   
    }
    
    private void FunctionOne()
    {
        buy.StorageOutput();
        Console.Write("Нажміть будь-яку клавішу, щоб повернутися до меню...");
        Console.ReadKey();
        Console.Clear();
        Menu();
    }

    private void FunctionTwo()
    {
        buy.StorageOutput();
        Console.Write("Введіть індекс товару, який бажаєте додати у кошик: ");
        int index = Convert.ToInt32(Console.ReadLine());
        buy.AddPurchase(buy.listStorage[index]);
        Console.WriteLine("Товар успішно додано!");
        Console.Write("Нажміть будь-яку клавішу, щоб повернутися до меню...");
        Console.ReadKey();
        Console.Clear();
        Menu();
    }

    private void FunctionThree()
    {
        buy.PuchaseOutput();
        Console.Write("Нажміть будь-яку клавішу, щоб повернутися до меню...");
        Console.ReadKey();
        Console.Clear();
        Menu();
    }

    private void FunctionFour()
    {
        buy.PuchaseOutput();
        Check.Purchase(buy);
    }
}
