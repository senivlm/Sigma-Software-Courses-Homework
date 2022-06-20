static class Storage
{
    public static Dictionary<string, decimal> productsPrices = new();   // Prices.txt
    public static List<Dish> menu = new();                              // Menu.txt
    public static Dictionary<string, decimal> courses = new();          // Courses.txt
    public static Dictionary<Product, int> productsAmount = new();      // result.txt

    public static decimal? FindPriceForProduct(string name) 
    {
        if (productsPrices.ContainsKey(name))
        {
            return productsPrices[name];
        }
        return null;
    }

    public static void GetProductPriceInDialog(string name) // this method can be moved to another class
    {
        Console.WriteLine($"Ціна для продукту \"{name}\" не була знайдена!");
        Console.Write($"Введіть ціну за кілограм: ");
        if (decimal.TryParse(Console.ReadLine(), out decimal price))
        {
            productsPrices.Add(name, price);
            FileWorker fileWorker = new(FileWorker.PathToPrices);
            fileWorker.WriteNewProductPrice(name);
        }
        else
        {
            throw new Exception($"Для продукту \"{name}\" вказана некоректна ціна!");
        }

    }

    public static Dictionary<string, List<Product>> TotalProducts()
    {
        Dictionary<string, List<Product>> productsTotal = new();
        foreach(Dish dish in menu)
        {
            foreach(Product product in dish._ingredients)
            {
                if(productsTotal.ContainsKey(product.Name))
                {
                    productsTotal[product.Name].Add(product);
                }
                else
                {
                    productsTotal.Add(product.Name, new List<Product> { product });
                }
            }
        }
        return productsTotal;
    }
}