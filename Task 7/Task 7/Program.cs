using System;
using System.Text;

// 1. Метод для наповлення данних з файлу. (class FileWorker, method ReadDataFromFile)
// 2. У випадку не існування файлу надати кілька спроб користувачу змінити файл завантаження. (class UserInterface, method FillStorageFromFile)
// 3. При неправильному форматі даних для зчитування вивести інформацію в файл-журнал реєстрації помилок з фіксацією дату та часу перевірки. (class FileWorker, method WriteError)
// 4. Некоректні дані не вносити до колекції. (class FileWorker, method ReadDataFromFile)
// 5. Вважати, що всі назви товарів мають бути з великої літери. У випадку, якщо у файл назва занесена з малої літери, дане не вважати некоректним, а замінити першу  літеру та додати товар до колекції. (class Product, Name in properties)
// 6. Створити метод, який надає можливість аналізувати журнал реєстрації та змінювати дані, які попали в журнал пізніше за задану користувачем дату. (class UserInterface, method ImproveErrors)
// Планую покращувати код з плином часу

public static class Program
{
    public static void Main()
    {
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance); // Ukrainian symbols in input from file
        Console.OutputEncoding = UTF8Encoding.UTF8; // Ukrainian symbols in console
        UserInterface.Menu();
    }
}