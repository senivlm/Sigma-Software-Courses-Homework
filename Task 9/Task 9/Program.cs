using System;
using System.Text;

// 1. У файлі «Menu.txt» задано інформацію про меню для ресторану. Інградієнтів та страв може бути довільна кількість.
// 2. У текстовому файлі «Prices.txt» заданий прейскурант цін.
// 3. У текстовому файлі «Course.txt» задано інформацію про біжучий курс одиниці валюти в грн для євро і долара.
// 4. Визначити сумарну кількість кожного продукту для потреб ресторану та їх сумарну вартість у грошовій валюті на вибір користувача. Результат вивести в файл «result.txt».
// 5. Якщо в прейскуранті не виявиться заявленого продукту, то згенеруйте виключення.
// 6. При опрацюванні винятку надайте можливість користувачу доповнити інформацію в прйскуранті. При другій невдалій спробі щодо одного продукту, повідомте користувача та заверште програму.
public static class Program
{
    public static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8; // Ukrainian symbols in console   
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance); // Ukrainian symbols in input from file

        try
        {
            FileWorker pricesFile = new FileWorker(FileWorker.PathToPrices);
            pricesFile.LoadPricesForProducts();

            FileWorker dishesFile = new FileWorker(FileWorker.PathToMenu);
            dishesFile.LoadDishesToMenu();

            FileWorker courses = new FileWorker(FileWorker.PathToCourse);
            courses.LoadCourses();

            Console.Clear();
            Console.Write($"Виберіть валюту (USD, EUR): ");
            string courseCode = Console.ReadLine();

            if (Storage.courses.ContainsKey(courseCode))
            {
                FileWorker result = new FileWorker("..\\..\\..\\data\\result.txt");
                result.WriteTotalProducts(Storage.TotalProducts(), courseCode);
            }
            else
            {
                throw new Exception("The course code is invalid!");
            }

            Console.Write("Програму виконано успішно, результат у файлі \"result.txt\"!");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}