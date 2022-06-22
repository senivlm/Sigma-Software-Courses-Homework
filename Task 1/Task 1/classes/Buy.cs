static class Buy
{
    static public List<Product> listStorage = new(), listPurchase = new();
    public static int PurchaseAmount { 
        get 
        {
            return listPurchase.Count;
        } 
    }
    public static decimal PurchasePrice
    {
        get
        {
            decimal purchasePrice = 0;
            foreach (Product product in listPurchase)
            {
                purchasePrice += product.Price;
            }
            return purchasePrice;
        }
    }
    public static decimal PurchaseWeight
    {
        get
        {
            decimal purchaseWeight = 0;
            foreach (Product product in listPurchase)
            {
                purchaseWeight += product.Weight;
            }
            return purchaseWeight;
        }
    }

    public static void AddStorage(Product product)
    {
        listStorage.Add(product);
    }

    public static void AddPurchase(Product product)
    {
        listPurchase.Add(product);
    }

    public static void StorageOutput()
    {
        HeaderOutput();
        for (int i = 0; i < listStorage.Count; i++)
        {
            Console.WriteLine("| {0,0} | {1,-10} | {2,-5} | {3,-5} |", i, listStorage[i].Name, listStorage[i].Price, listStorage[i].Weight);
        }
        Console.WriteLine("----------------------------------");
    }

    public static void PuchaseOutput()
    {
        HeaderOutput();
        for (int i = 0; i < listPurchase.Count; i++)
        {
            Console.WriteLine("| {0,0} | {1,-10} | {2,-5} | {3,-5} |", i, listPurchase[i].Name, listPurchase[i].Price, listPurchase[i].Weight);
        }
        Console.WriteLine("----------------------------------");
    }

    private static void HeaderOutput()
    {
        Console.WriteLine("----------------------------------");
        Console.WriteLine(String.Format("| {0,0} | {1,-10} | {2,-5} | {3,-5} |", "#", "Назва", "Ціна", "Вага"));
        Console.WriteLine("----------------------------------");
    }
}