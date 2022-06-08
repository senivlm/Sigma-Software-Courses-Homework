static class UserInterface
{
    public static void Menu()
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
            case 1: GetProductInDialogue(); break;
            case 2: AddRandomProducts(); break;
            case 3: AllProductsOutput(); break;
            case 4: AllMeatOutput(); break;
            case 5: ChangeValueAllProducts(); break;
            case 6: ChangeProductField(); break;
        }
    }

    private static void GetProductInDialogue() // Adding a Product in the mode of communication with the user
    {
        Console.Write("1 - Product \n2 - Meat \n3 - Dairy \nВиберіть тип продукту: ");
        int input = Convert.ToInt32(Console.ReadLine());
        Console.Write("Введіть назву продукту: ");
        string name = Console.ReadLine();
        Console.Write("Введіть ціну продукту: ");
        int price = Convert.ToInt32(Console.ReadLine());
        Console.Write("Введіть вагу продукту: ");
        int weight = Convert.ToInt32(Console.ReadLine());
        switch (input)
        {
            case 1: Storage.Append(new Product(name, price, weight)); break;
            case 2: GetMeatInDialogue(name, price, weight); break;
            case 3: GetDairyInDialogue(name, price, weight); break;
        }
        Console.WriteLine("\nТовар успішно доданий!");
        GoToMenu();
    }

    private static void GetMeatInDialogue(string name, int price, int weight) // If we wanna add Meat product
    {
        Console.WriteLine("Виберіть сорт мяса: 1 - перший сорт, 2 - другий сорт");
        int inputType = Convert.ToInt32(Console.ReadLine());
        MeatType type = MeatType.First;
        switch (inputType)
        {
            case 1: type = MeatType.First; break;
            case 2: type = MeatType.Second; break;
        }
        Console.WriteLine("Виберіть тип мяса: 1 - баранина, 2 - телятина, 3 - свинина, 4 - курятина");
        int inputCategory = Convert.ToInt32(Console.ReadLine());
        Category category = Category.Mutton;
        switch (inputCategory)
        {
            case 1: category = Category.Mutton; break;
            case 2: category = Category.Veal; break;
            case 3: category = Category.Pork; break;
            case 4: category = Category.Chicken; break;
        }
        Storage.Append(new Meat(name, price, weight, type, category));
    }
    private static void GetDairyInDialogue(string name, int price, int weight) // If we wanna add Dairy
    {
        Console.WriteLine("Введіть термін придатності.");
        Console.Write("Рік: ");
        int year = Convert.ToInt32(Console.ReadLine());
        Console.Write("Місяць: ");
        int month = Convert.ToInt32(Console.ReadLine());
        Console.Write("День: ");
        int day = Convert.ToInt32(Console.ReadLine());
        Storage.Append(new Dairy(name, price, weight, new DateTime(year, month, day)));
    }

    private static void AddRandomProducts() // Automatic generation of products
    {
        Console.Write("Введіть кількість товарів, яку хочете додати: ");
        int amount = Convert.ToInt32(Console.ReadLine());
        RandomInitialization.RandomProducts(amount);
        Console.Clear();
        Console.WriteLine("Товари в кількості {0} були успішно сгенеровані!", amount);
        GoToMenu();
    }

    private static void AllProductsOutput() // Output all products list
    {
        Console.WriteLine("------------------------------------------------------------------------------");
        Console.WriteLine("| Назва      | Ціна  | Вага | Сорт мяса  | Вид мяса      | Термін придатності");
        Console.WriteLine("------------------------------------------------------------------------------");
        foreach (Product product in Storage.listProduct)
        {
            Console.Write(string.Format("| {0,-10} | {1,-5:F1} | {2,-5}", product.name, product.price, product.weight));
            if (product is Meat)
            {
                Meat p = product as Meat;
                Console.Write(string.Format("| {0,-10} | {1,-10}", p.GetMeatType(), p.GetCategory()));
            }
            if (product is Dairy)
            {
                Dairy p = product as Dairy;
                Console.Write(string.Format("{0,50}", "| " + p.expdate));
            }
            Console.WriteLine();
        }
        Console.WriteLine("------------------------------------------------------------------------------");
        GoToMenu();
    }

    private static void AllMeatOutput() // Output Meat list
    {
        Console.WriteLine("----------------------------------------------------");
        Console.WriteLine("| Назва      | Ціна  | Вага  | Сорт мяса  | Вид мяса");
        Console.WriteLine("----------------------------------------------------");
        foreach (Product product in Storage.listProduct)
        {
            if (product is Meat)
            {
                Meat p = product as Meat;
                Console.WriteLine(string.Format("| {0,-10} | {1,-5:F1} | {2,-5} | {3,-10} | {4,-10}", p.name, p.price, p.weight, p.GetMeatType(), p.GetCategory()));
            }
        }
        Console.WriteLine("----------------------------------------------------");
        GoToMenu();
    }

    private static void ChangeValueAllProducts() // Change value of every Product on {percent}
    {
        Console.Write("Введіть на який відсоток змінити ціну: ");
        decimal percent = decimal.Parse(Console.ReadLine());
        for (int i = 0; i < Storage.listProduct.Count; i++)
        {
            Storage.listProduct[i].ChangeValue(percent);
        }
        Console.Clear();
        Console.WriteLine("Ціни всіх продуктів успішно змінені на {0}%!", percent);
        GoToMenu();
    }

    private static void ChangeProductField() // Change or check product data by index in list
    {
        Console.WriteLine("1. Відобразити дані про товар");
        Console.WriteLine("2. Змінити дані про товар");
        Console.Write("Виберіть функцію: ");
        int choose = Convert.ToInt32(Console.ReadLine());
        Console.Write("Введіть індекс товару: ");
        int index = Convert.ToInt32(Console.ReadLine());

        switch (choose)
        {
            case 1:
                {
                    Console.Clear();
                    Console.WriteLine($"Назва: {Storage.listProduct[index].name} \nЦіна: {Storage.listProduct[index].price}\nВага: {Storage.listProduct[index].weight}");
                    if (Storage.listProduct[index] is Meat)
                    {
                        Meat p = Storage.listProduct[index] as Meat;
                        Console.WriteLine($"Сорт мяса: {p.GetMeatType()} \nТип мяса: {p.GetCategory()}");
                    }
                    if (Storage.listProduct[index] is Dairy)
                    {
                        Dairy p = Storage.listProduct[index] as Dairy;
                        Console.WriteLine($"Дата: {p.expdate}");
                    }
                    Console.Write("Нажміть будь-яку клавішу, щоб перейти в меню...");
                    Console.ReadKey();
                    Console.Clear();
                    Menu();
                    break;
                }

            case 2:
                {
                    Console.WriteLine("1. Змінити назву товару");
                    Console.WriteLine("2. Змінити ціну товару");
                    Console.WriteLine("3. Змінити вагу товару");
                    if (Storage.listProduct[index] is Meat)
                    {
                        Console.WriteLine("4. Змінити сорт мяса");
                        Console.WriteLine("5. Змінити вид мяса");
                    }
                    else if (Storage.listProduct[index] is Dairy)
                    {
                        Console.WriteLine("4. Змінити термін придатності");
                    }
                    Console.Write("Виберіть функцію: ");
                    int choice = Convert.ToInt32(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("Введіть нову назву: ");
                            Storage.listProduct[index].name = Console.ReadLine(); break;
                        case 2:
                            Console.WriteLine("Введіть нову ціну: ");
                            Storage.listProduct[index].price = Convert.ToInt32(Console.ReadLine()); break;
                        case 3:
                            Console.WriteLine("Введіть нову вагу: ");
                            Storage.listProduct[index].weight = Convert.ToInt32(Console.ReadLine()); break;
                        case 4:
                            if (Storage.listProduct[index] is Meat)
                            {
                                Meat meatT = Storage.listProduct[index] as Meat;
                                Console.Write("Виберіть сорт мяса (1 - перший сорт, 2 - другий сорт): ");
                                int choiceMeatType = Convert.ToInt32(Console.ReadLine());
                                meatT.SetMeatType(choiceMeatType);
                                break;
                            }
                            else if (Storage.listProduct[index] is Dairy)
                            {
                                Dairy dairy = Storage.listProduct[index] as Dairy;
                                Console.WriteLine("Введіть термін придатності.");
                                Console.Write("Рік: ");
                                int year = Convert.ToInt32(Console.ReadLine());
                                Console.Write("Місяць: ");
                                int month = Convert.ToInt32(Console.ReadLine());
                                Console.Write("День: ");
                                int day = Convert.ToInt32(Console.ReadLine());
                                dairy.SetExpdate(year, month, day);
                            }
                            break;
                        case 5:
                            Meat meatC = Storage.listProduct[index] as Meat;
                            Console.Write("Виберіть тип мяса (1 - баранина, 2 - телятина, 3 - свинина, 4 - курятина): ");
                            int choiceCategory = Convert.ToInt32(Console.ReadLine());
                            meatC.SetCategory(choiceCategory);
                            break;
                    }
                    break;
                }
        }
        GoToMenu();
    }

    private static void GoToMenu()
    {
        Console.Write("Нажміть будь-яку клавішу, щоб перейти в меню...");
        Console.ReadKey();
        Console.Clear();
        Menu();
    }
}