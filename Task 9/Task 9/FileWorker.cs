class FileWorker
{
    private string _path;
    public const string PathToPrices = "..\\..\\..\\data\\Prices.txt";
    public const string PathToMenu = "..\\..\\..\\data\\Menu.txt";
    public const string PathToCourse = "..\\..\\..\\data\\Course.txt";

    public FileWorker(string path)
    {
        try
        {
            if (!File.Exists(path))
            {
                var file = File.Create(path);
                file.Close();
            }
            _path = path;
        }
        catch
        {
            throw new Exception($"Деякі проблеми з шляхом до файлу! ({path})");
        }
    }
    public void LoadPricesForProducts()
    {
        using (StreamReader pricesFile = new StreamReader(_path))
        {
            while (!pricesFile.EndOfStream)
            {
                try
                {
                    string[] line = pricesFile.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    string name = line[0];
                    decimal price = decimal.Parse(line[2]);
                    Storage.productsPrices.Add(name, price);
                }
                catch (FormatException)
                {
                    throw new Exception($"Деякі проблеми з зчитуванням цін товарів!");
                }
            }
        }
    }

    public void LoadDishesToMenu()
    {
        using (StreamReader dishesFile = new StreamReader(_path))
        {
            while (!dishesFile.EndOfStream)
            {
                string dishName = dishesFile.ReadLine();
                List<Product> listProducts = new();
                while (true && !dishesFile.EndOfStream)
                {
                    string[] line = dishesFile.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    if (line.Length == 0) { break; }
                    listProducts.Add(new Product(line[0].Replace(",", ""), int.Parse(line[1].Replace("г", "").Replace("мл", ""))));
                }

                if (listProducts.Count() != 0)
                {
                    Storage.menu.Add(new Dish(dishName, listProducts));
                }
                else
                {
                    throw new Exception($"Блюдо \"{dishName}\" не може містити 0 інгредієнтів!");
                }
            }
        }
    }

    public void LoadCourses()
    {
        using (StreamReader pricesFile = new StreamReader(_path))
        {
            while (!pricesFile.EndOfStream)
            {
                try
                {
                    string[] line = pricesFile.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    string name = line[1];
                    decimal price = decimal.Parse(line[3]);
                    Storage.courses.Add(name, price);
                }
                catch (FormatException)
                {
                    throw new Exception($"Деякі проблеми зі зчитуванням біжучого курсу валют!");
                }
            }
        }
    }

    public void WriteTotalProducts(Dictionary<string, List<Product>> productsTotal, string courseCode)
    {
        using (StreamWriter streamWriter = new StreamWriter(_path))
        {
            int totalProductsNumber = 0, totalProductsWeight = 0;
            decimal totalProductsPrice = 0;
            streamWriter.WriteLine("----------------------------------------------------------------");
            streamWriter.WriteLine(String.Format("| {0,-15} | {1,-3} | {2,-10} | {3,-23} |", "Назва продукту", " # ", "Вага/Об`єм", "Ціна"));
            streamWriter.WriteLine("----------------------------------------------------------------");
            streamWriter.WriteLine(String.Format("| {0,-15} | {1,-3} | {2,-10} | {3,-10} | {4,-10} |", "", "", "г/мл", "UAH", courseCode));
            streamWriter.WriteLine("----------------------------------------------------------------");
            foreach (KeyValuePair<string, List<Product>> kvp in productsTotal)
            {
                decimal totalPrice = 0;
                int totalWeight = 0;
                foreach (var product in kvp.Value)
                {
                    totalPrice += product.Price;
                    totalWeight += product.Weight;
                }
                streamWriter.WriteLine(String.Format("| {0,-15} | {1,-3} | {2,-10} | {3,-10:F2} | {4,-10:F2} |", kvp.Key, kvp.Value.Count, totalWeight, totalPrice,  totalPrice/Storage.courses[courseCode]));
                totalProductsPrice += totalPrice;
                totalProductsWeight += totalWeight;
                totalProductsNumber += kvp.Value.Count;
            }
            streamWriter.WriteLine("----------------------------------------------------------------");
            streamWriter.WriteLine(String.Format("| {0,-15} | {1,-3} | {2,-10} | {3,-10:F2} | {4,-10:F2} |", "TOTAL", totalProductsNumber, totalProductsWeight, totalProductsPrice,  totalProductsPrice/Storage.courses[courseCode]));
            streamWriter.WriteLine("----------------------------------------------------------------");
        }
    }

    public void WriteNewProductPrice(string name)
    {
        using (StreamWriter streamWriter = new StreamWriter(_path, true))
        {
            streamWriter.WriteLine($"{name} - {Storage.productsPrices[name]} UAH");
        }
    }
}