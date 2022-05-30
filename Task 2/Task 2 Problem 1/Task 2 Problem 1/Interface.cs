class Interface
{
    Storage storage = new();
    public void Menu()
    {
        Console.WriteLine("Перелік функцій.");
        Console.WriteLine("1. Наповнення інформацією даних у режимі діалогу з користувачем");
        Console.WriteLine("2. Наповнення інформацією даних шляхом ініціалізації");
        Console.WriteLine("3. Виведення повної інформації про всі товари");
        Console.WriteLine("4. Виведення всіх мясних продуктів");
        Console.WriteLine("5. Змінити ціну для всіх товарів на заданий відсоток");
        Console.WriteLine("6. Переглянути або змінити дані товару за індексом");
        Console.Write("Виберіть функцію: ");
        int input = Convert.ToInt32(Console.ReadLine());
        Console.Clear();
        switch (input)
        {
            case 1: FunctionOne(); break;
            case 2: FunctionTwo(); break;
            case 3: FunctionThree(); break;
            case 4: FunctionFour(); break;
            case 5: FunctionFive(); break;
            case 6: FunctionSix(); break;
        }
    }

    private void FunctionOne() // Adding a Product in the mode of communication with the user
    {
        Console.Write("1 - Product \n2 - Meat \n3 - Dairy Product \nВиберіть тип продукту: ");
        int input = Convert.ToInt32(Console.ReadLine());
        Console.Write("Введіть назву продукту: ");
        string name = Console.ReadLine();
        Console.Write("Введіть ціну продукту: ");
        int price = Convert.ToInt32(Console.ReadLine());
        Console.Write("Введіть вагу продукту: ");
        int weight = Convert.ToInt32(Console.ReadLine());
        switch (input)
        {
            case 1:
                storage.Append(new Product(name, price, weight)); break;
            case 2:
                FunctionOneMeat(name, price, weight); break;
            case 3:
                FunctionOneDairyProduct(name, price, weight); break;
        }

        Console.WriteLine("\nТовар успішно доданий!\n1. Додати ще один товар. \n2. Повернутися до меню.");
        input = Convert.ToInt32(Console.ReadLine());
        Console.Clear();
        if (input == 1)
        {
            FunctionOne();
        }
        else if (input == 2)
        {
            Menu();
        }
    }

    private void FunctionOneMeat(string name, int price, int weight) // If we wanna add Meat product
    {
        Console.WriteLine("Виберіть сорт мяса: 1 - перший сорт, 2 - другий сорт");
        int inputType = Convert.ToInt32(Console.ReadLine());
        MeatType type = MeatType.first;
        switch (inputType)
        {
            case 1: type = MeatType.first; break;
            case 2: type = MeatType.second; break;
        }
        Console.WriteLine("Виберіть тип мяса: 1 - баранина, 2 - телятина, 3 - свинина, 4 - курятина");
        int inputCategory = Convert.ToInt32(Console.ReadLine());
        Category category = Category.mutton;
        switch (inputCategory)
        {
            case 1: category = Category.mutton; break;
            case 2: category = Category.veal; break;
            case 3: category = Category.pork; break;
            case 4: category = Category.chicken; break;
        }
        storage.Append(new Meat(name, price, weight, type, category));
    }
    private void FunctionOneDairyProduct(string name, int price, int weight) // If we wanna add Dairly_Product
    {
        Console.WriteLine("Введіть термін придатності.");
        Console.Write("Рік: ");
        int year = Convert.ToInt32(Console.ReadLine());
        Console.Write("Місяць: ");
        int month = Convert.ToInt32(Console.ReadLine());
        Console.Write("День: ");
        int day = Convert.ToInt32(Console.ReadLine());
        storage.Append(new Dairy_products(name, price, weight, new DateTime(year, month, day)));
    }

    private void FunctionTwo() // Automatic generation of products
    {
        Console.Write("Введіть кількість товарів, яку хочете додати: ");
        int amount = Convert.ToInt32(Console.ReadLine());
        Random random = new Random();
        string[] namesProduct = { "Консерви", "Макарони", "Рис", "Цукор", "Сіль", "Кава", "Мед", "Борошно", "Спеції" };
        string[] namesMeat = { "Ковбаски", "Філе", "Фарш", "Шашлик", "Сосіки", "Сардельки", "Рулет", "Стейки" };
        string[] namesDairly_Products = { "Лаваш", "Круасан", "Батон", "Лаваш", "Багет", "Майонез", "Помідори" };
        for (int i = 0; i < amount; i++)
        {
            int change = random.Next(3);
            if (change == 0)
            {
                storage.Append(new Product(namesProduct[random.Next(namesProduct.Length-1)], random.Next(20, 100), random.Next(100, 2001)));
            }
            else if (change == 1)
            {
                int meatType = random.Next(2);
                MeatType mt = MeatType.first;
                if (meatType == 0)
                {
                    mt = MeatType.first;
                }
                else if (meatType == 1)
                {
                    mt = MeatType.second;
                }
                int meatCategory = random.Next(4);
                Category ct = Category.mutton;
                switch (meatCategory)
                {
                    case 0: ct = Category.mutton; break;
                    case 1: ct = Category.veal; break;
                    case 2: ct = Category.pork; break;
                    case 3: ct = Category.chicken; break;
                }
                storage.Append(new Meat(namesMeat[random.Next(namesMeat.Length-1)], random.Next(20, 100), random.Next(100, 2001), mt, ct));
            }
            else if (change == 2)
            {
                DateTime dt = DateTime.Now;
                Random randomDay = new Random();
                dt = dt.AddDays(randomDay.Next(31));
                storage.Append(new Dairy_products(namesDairly_Products[random.Next(namesDairly_Products.Length-1)], random.Next(20, 100), random.Next(100, 2001), dt));
            }
        }
        Console.Clear();
        Console.WriteLine("Товари в кількості {0} були успішно сгенеровані!", amount);
        Console.Write("Нажміть будь-яку клавішу, щоб перейти в меню...");
        Console.ReadKey();
        Console.Clear();
        Menu();
    }
    private void FunctionThree() // Output all products list
    {
        Console.WriteLine("------------------------------------------------------------------------------");
        Console.WriteLine("| Назва      | Ціна  | Вага | Сорт мяса  | Вид мяса      | Термін придатності");
        Console.WriteLine("------------------------------------------------------------------------------");
        foreach (Product product in storage.listProduct)
        {
            Console.Write(string.Format("| {0,-10} | {1,-5:F1} | {2,-5}", product.name, product.price, product.weight));
            if (product is Meat)
            {
                Meat p = product as Meat;
                Console.Write(string.Format("| {0,-10} | {1,-10}", p.GetMeatType(), p.GetCategory()));
            }
            if (product is Dairy_products)
            {
                Dairy_products p = product as Dairy_products;
                Console.Write(string.Format("{0,50}", "| " + p.expdate));
            }
            Console.WriteLine();
        }
        Console.WriteLine("------------------------------------------------------------------------------");
        Console.Write("Нажміть будь-яку клавішу, щоб перейти в меню...");
        Console.ReadKey();
        Console.Clear();
        Menu();
    }

    private void FunctionFour() // Output Meat list
    {
        Console.WriteLine("----------------------------------------------------");
        Console.WriteLine("| Назва      | Ціна  | Вага  | Сорт мяса  | Вид мяса");
        Console.WriteLine("----------------------------------------------------");
        foreach (Product product in storage.listProduct)
        {
            if (product is Meat)
            {
                Meat p = product as Meat;
                Console.WriteLine(string.Format("| {0,-10} | {1,-5:F1} | {2,-5} | {3,-10} | {4,-10}", p.name, p.price, p.weight, p.GetMeatType(), p.GetCategory()));
            }
        }
        Console.WriteLine("----------------------------------------------------");
        Console.Write("Нажміть будь-яку клавішу, щоб перейти в меню...");
        Console.ReadKey();
        Console.Clear();
        Menu();
    }

    public void FunctionFive() // Change value every Product on {percent}
    {
        Console.Write("Введіть на який відсоток змінити ціну: ");
        decimal percent = decimal.Parse(Console.ReadLine());
        for (int i = 0; i < storage.listProduct.Count; i++)
        {
            if (storage.listProduct[i].GetType() == typeof(Product))
            {
                storage.listProduct[i].ChangeValue(percent);
            }
            else if (storage.listProduct[i].GetType() == typeof(Meat))
            {
                storage.listProduct[i].ChangeValue(percent);
            }
            else if (storage.listProduct[i].GetType() == typeof(Dairy_products))
            {
                storage.listProduct[i].ChangeValue(percent);
            }
        }
        Console.Clear();
        Console.WriteLine("Ціни всіх продуктів успішно змінені на {0}%!", percent);
        Console.Write("Нажміть будь-яку клавішу, щоб перейти в меню...");
        Console.ReadKey();
        Console.Clear();
        Menu();
    }
    private void FunctionSix() // Change or check product data by index in list
    {
        Console.WriteLine("1. Відобразити дані про товар");
        Console.WriteLine("2. Змінити дані про товар");
        Console.Write("Виберіть функцію: ");
        int choose = Convert.ToInt32(Console.ReadLine());
        Console.Write("Введіть індекс товару: ");
        int index = Convert.ToInt32(Console.ReadLine());

        if (choose == 1)
        {
            Console.Clear();
            Console.WriteLine($"Назва: {storage.listProduct[index].name} \nЦіна: {storage.listProduct[index].price}\nВага: {storage.listProduct[index].weight}");
            if (storage.listProduct[index] is Meat)
            {
                Meat p = storage.listProduct[index] as Meat;
                Console.WriteLine($"Сорт мяса: {p.GetMeatType()} \nТип мяса: {p.GetCategory()}");
            }
            if (storage.listProduct[index] is Dairy_products)
            {
                Dairy_products p = storage.listProduct[index] as Dairy_products;
                Console.WriteLine($"Дата: {p.expdate}");
            }
            Console.Write("Нажміть будь-яку клавішу, щоб перейти в меню...");
            Console.ReadKey();
            Console.Clear();
            Menu();
        }
        else if (choose == 2)
        {
            Console.WriteLine("1. Змінити назву товару");
            Console.WriteLine("2. Змінити ціну товару");
            Console.WriteLine("3. Змінити вагу товару");
            if (storage.listProduct[index] is Meat)
            {
                Console.WriteLine("4. Змінити сорт мяса");
                Console.WriteLine("5. Змінити вид мяса");
            }
            else if (storage.listProduct[index] is Dairy_products)
            {
                Console.WriteLine("4. Змінити термін придатності");
            }
            Console.Write("Виберіть функцію: ");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    Console.WriteLine("Введіть нову назву: ");
                    storage.listProduct[index].name = Console.ReadLine(); break;
                case 2:
                    Console.WriteLine("Введіть нову ціну: ");
                    storage.listProduct[index].price = Convert.ToInt32(Console.ReadLine()); break;
                case 3:
                    Console.WriteLine("Введіть нову вагу: ");
                    storage.listProduct[index].weight = Convert.ToInt32(Console.ReadLine()); break;
                case 4:
                    if (storage.listProduct[index] is Meat)
                    {
                        Meat meatT = storage.listProduct[index] as Meat;
                        Console.Write("Виберіть сорт мяса (1 - перший сорт, 2 - другий сорт): ");
                        int choiceMeatType = Convert.ToInt32(Console.ReadLine());
                        meatT.SetMeatType(choiceMeatType);
                        break;
                    }
                    else if (storage.listProduct[index] is Dairy_products)
                    {
                        Dairy_products dairly_product = storage.listProduct[index] as Dairy_products;
                        Console.WriteLine("Введіть термін придатності.");
                        Console.Write("Рік: ");
                        int year = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Місяць: ");
                        int month = Convert.ToInt32(Console.ReadLine());
                        Console.Write("День: ");
                        int day = Convert.ToInt32(Console.ReadLine());
                        dairly_product.SetExpdate(year, month, day);
                    }
                    break;
                case 5:
                    Meat meatC = storage.listProduct[index] as Meat;
                    Console.Write("Виберіть тип мяса (1 - баранина, 2 - телятина, 3 - свинина, 4 - курятина): ");
                    int choiceCategory = Convert.ToInt32(Console.ReadLine());
                    meatC.SetCategory(choiceCategory);
                    break;
            }
            Console.Write("Нажміть будь-яку клавішу, щоб перейти в меню...");
            Console.ReadKey();
            Console.Clear();
            Menu();
        }
    }
}