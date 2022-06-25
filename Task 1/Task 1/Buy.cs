class Buy
{
    private List<Product> _listPurchase;
    static private List<Product> _listStorage = new();

    public int PurchaseAmount { 
        get 
        {
            return _listPurchase.Count;
        } 
    }
    public decimal PurchasePrice
    {
        get
        {
            decimal purchasePrice = 0;
            foreach (Product product in _listPurchase)
            {
                purchasePrice += product.Price;
            }
            return purchasePrice;
        }
    }
    public decimal PurchaseWeight
    {
        get
        {
            decimal purchaseWeight = 0;
            foreach (Product product in _listPurchase)
            {
                purchaseWeight += product.Weight;
            }
            return purchaseWeight;
        }
    }

    public Buy()
    {
        _listPurchase = new List<Product>();
    }

    public static void AddStorage(Product product)
    {
        _listStorage.Add(product);
    }
    public static Product? ProductInStorage(int index)
    {
        return _listStorage.ElementAtOrDefault(index);
    }
    public static Product GetProductFromStorage(int index)
    {
        return _listStorage[index];
    }

    public void AddPurchase(Product product)
    {
        _listPurchase.Add(product);
    }
    public void RemovePurchase(Product product)
    {
        _listPurchase.Remove(product);
    }
    public Product? ProductInPurchase(int index)
    {
        return _listPurchase.ElementAtOrDefault(index);
    }
    public Product GetProductFromPurchase(int index)
    {
        return _listPurchase[index];
    }

    public static void StorageOutput()
    {
        HeaderOutput();
        for (int i = 0; i < _listStorage.Count; i++)
        {
            Console.WriteLine("| {0,0} | {1,-10} | {2,-5} | {3,-5} |", i, _listStorage[i].Name, _listStorage[i].Price, _listStorage[i].Weight);
        }
        Console.WriteLine("----------------------------------");
    }

    public void PuchaseOutput()
    {
        HeaderOutput();
        for (int i = 0; i < _listPurchase.Count; i++)
        {
            Console.WriteLine("| {0,0} | {1,-10} | {2,-5} | {3,-5} |", i, _listPurchase[i].Name, _listPurchase[i].Price, _listPurchase[i].Weight);
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