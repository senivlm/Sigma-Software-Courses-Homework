static class UserInterface
{
    #region Methods
    public static void Menu()
    {
        Console.WriteLine("Перелік функцій.");
        Console.WriteLine("Робота з файлами.");
        Console.WriteLine("1. Завантажити дані з файлу");
        Console.WriteLine("2. Зберегти дані в основний файл");
        Console.WriteLine("3. Виправити дані в журналі помилок");
        Console.WriteLine("\nРобота із завантаженими даними.");
        Console.WriteLine("4. Наповнення інформацією даних у режимі діалогу з користувачем");
        Console.WriteLine("5. Наповнення інформацією даних шляхом ініціалізації");
        Console.WriteLine("6. Виведення повної інформації про всі товари");
        Console.WriteLine("7. Виведення всіх мясних продуктів");
        Console.WriteLine("8. Змінити ціну для всіх товарів на заданий відсоток");
        Console.WriteLine("9. Переглянути або змінити дані товару за індексом");

        Console.Write("\nВиберіть функцію: ");
        int input = Convert.ToInt32(Console.ReadLine());
        Console.Clear();
        switch (input)
        {
            case 1: FillStorageFromFile(); break;
            case 2: SaveStorageToFile(); break;
            case 3: ImproveErrors(); break;
            case 4: GetProductInDialogue(); break;
            case 5: AddRandomProducts(); break;
            case 6: AllProductsOutput(); break;
            case 7: AllMeatOutput(); break;
            case 8: ChangeValueAllProducts(); break;
            case 9: ChangeProductField(); break;
            default: throw new Exception("Індекс не відповідає ні одній з функцій!");
        }
    }
    
    private static void FillStorageFromFile()
    {
        Console.WriteLine("1. Завантажити дані з основного файлу");
        Console.WriteLine("2. Завантажити дані з свого файлу");
        Console.Write("Виберіть: ");
        int input = Convert.ToInt32(Console.ReadLine());
        Console.Clear();
        switch (input)
        {
            case 1: { FillFromMainFile(); break; }
            case 2: { FillFromCustomFile(); break; }
        }
        Console.WriteLine("Товари успішно додані!");
        BackToMenu();
    }
    private static void FillFromMainFile()
    {
        FileWorker fileWorker = new(FileWorker.PathToData);
        fileWorker.ReadDataFromFile();
    }
    private static void FillFromCustomFile()
    {
        string path;
        while (true)
        {
            Console.WriteLine("Введіть шлях по прикладу: D:\\Visual Studio Projects\\Task 7\\Task 7\\data\\products.txt");
            path = Console.ReadLine();
            if (File.Exists(path))
            {
                break;
            }
            else
            {
                Console.WriteLine("Файл не існує!");
                Console.WriteLine("1. Попробувати знову");
                Console.WriteLine("2. Повернутися до меню");
                Console.Write("Виберіть: ");
                Console.Clear();
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1: { break; }
                    case 2: { BackToMenu(); break; }
                }
            }
        }
        FileWorker fileWorker = new(path);
        fileWorker.ReadDataFromFile();
    }

    private static void SaveStorageToFile()
    {

        FileWorker fileWorker = new("..\\..\\..\\data\\products.txt");
        fileWorker.WriteDataToFile();
        Console.WriteLine("Дані успішно збережено!");
        BackToMenu();
    }

    private static void ImproveErrors()
    {
        List<string[]> parametersList = FileWorker.ReadLog();
        ConsoleWorker.LogOutput(parametersList);
        Console.Write("\nВведіть дату, пізніше якої хочете виправити всі дані: ");
        string date = Console.ReadLine();
        DateTime dateInput = DateTime.Parse(date);
        Console.WriteLine(dateInput.ToString());
        Console.Clear();

        for (int i = 0; i < parametersList.Count; i++)
        {
            if (DateTime.Compare(dateInput, DateTime.Parse(parametersList[i][^1])) < 0)
            {
                Console.WriteLine($"Поточна назва: {parametersList[i][0]}");
                Console.WriteLine("Назва не може утримувати цифри.");
                Console.WriteLine($"Кількість символів в назві повинно бути більше {ErrorChecker.MinCharactersInName}, а також менше {ErrorChecker.MaxCharactersInName}.");
                Console.Write("Введіть нову назву: ");
                string name = Console.ReadLine();

                Console.WriteLine($"Поточна ціна: {parametersList[i][1]}");
                Console.WriteLine("Ціна не може утримувати букви.");
                Console.WriteLine($"Ціна не може бути більшою за {ErrorChecker.MaxPrice}, а також меншою за {ErrorChecker.MinPrice}.");
                Console.Write("Введіть нову ціну: ");
                decimal price = Convert.ToDecimal(Console.ReadLine());

                Console.WriteLine($"Поточна вага: {parametersList[i][2]}");
                Console.WriteLine("Вага не може утримувати букви.");
                Console.WriteLine($"Вага не може бути більшою за {ErrorChecker.MaxWeight}, а також меншою за {ErrorChecker.MinWeight}.");
                Console.Write("Введіть нову вагу: ");
                decimal weight = Convert.ToDecimal(Console.ReadLine());

                if (parametersList[i].Length == 6)
                {
                    Console.WriteLine($"Поточний тип мяса: {parametersList[i][3]}");
                    Console.WriteLine("Доступні типи мяса: 1-й, 2-й.");
                    Console.Write("Введіть новий тип: ");
                    string meatType = Console.ReadLine();

                    Console.WriteLine($"Поточний вид мяса: {parametersList[i][4]}");
                    Console.WriteLine("Доступні види мяса: Баранина, Телятина, Свинина, Курятина.");
                    Console.Write("Введіть новий вид: ");
                    string meatCategory = Console.ReadLine();
                    Storage.Append(new Meat(name, price, weight, meatType, meatCategory));
                }
                else if (parametersList[i].Length == 5)
                {
                    Console.WriteLine($"Поточний термін придатності: {parametersList[i][3]}");
                    Console.Write("Введіть нову дату: ");
                    string dateD = Console.ReadLine();
                    DateTime dtD = DateTime.Parse(dateD);
                    Storage.Append(new Dairy(name, price, weight, dtD));
                }
                else
                {
                    Storage.Append(new Product(name, price, weight));
                }
            }
        }
        Console.WriteLine("Товари успішно додані!");
        BackToMenu();
    }

    private static void GetProductInDialogue()
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
        BackToMenu();
    }
    private static void GetMeatInDialogue(string name, int price, int weight)
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
    private static void GetDairyInDialogue(string name, int price, int weight)
    {
        Console.WriteLine("Введіть термін придатності.");
        string date = Console.ReadLine();
        DateTime dt = DateTime.Parse(date);
        Storage.Append(new Dairy(name, price, weight, dt));
    }
    
    private static void AddRandomProducts()
    {
        Console.Write("Введіть кількість товарів, яку хочете додати: ");
        int amount = Convert.ToInt32(Console.ReadLine());
        RandomInitialization.RandomProducts(amount);
        Console.Clear();
        Console.WriteLine("Товари в кількості {0} були успішно сгенеровані!", amount);
        BackToMenu();
    }
   
    private static void AllProductsOutput()
    {
        ConsoleWorker.AllProductsOutput();
        BackToMenu();
    }

    private static void AllMeatOutput()
    {
        ConsoleWorker.AllMeatOutput();
        BackToMenu();
    }
    
    private static void ChangeValueAllProducts()
    {
        Console.Write("Введіть на який відсоток змінити ціну: ");
        decimal percent = decimal.Parse(Console.ReadLine());
        for (int i = 0; i < Storage.listProduct.Count; i++)
        {
            Storage.listProduct[i].ChangeValue(percent);
        }
        Console.Clear();
        Console.WriteLine("Ціни всіх продуктів успішно змінені на {0}%!", percent);
        BackToMenu();
    }

    private static void ChangeProductField()
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
                    ConsoleWorker.OutputProduct(index);
                    BackToMenu();
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
                            Storage.listProduct[index].Name = Console.ReadLine(); break;
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
                                dairy.SetexpDate(year, month, day);
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
        BackToMenu();
    }

    private static void BackToMenu()
    {
        Console.Write("Нажміть будь-яку клавішу, щоб перейти в меню...");
        Console.ReadKey();
        Console.Clear();
        Menu();
    }

    #endregion
}