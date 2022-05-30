class Buy
{
    public int PurchaseAmount { 
        get 
        {
            return listPurchase.Count;
        } 
    }
    public decimal PurchasePrice
    {
        get
        {
            decimal purchasePrice = 0;
            foreach (Product product in listPurchase)
            {
                purchasePrice += product.price;
            }
            return purchasePrice;
        }
    }
    public decimal PurchaseWeight
    {
        get
        {
            decimal purchaseWeight = 0;
            foreach (Product product in listPurchase)
            {
                purchaseWeight += product.weight;
            }
            return purchaseWeight;
        }
    }

    public List<Product>? listStorage, listPurchase;

    public Buy()
    {
        listStorage = new List<Product>();
        listPurchase = new List<Product>();
    }

    public void AddStorage(Product product)
    {
        listStorage.Add(product);
    }

    public void AddPurchase(Product product)
    {
        listPurchase.Add(product);
    }

    public void StorageOutput()
    {
        Console.WriteLine("-------------------------------");
        Console.WriteLine(String.Format("| {0,0} | {1,-10} | {2,-5} | {3,-5}", "#", "Назва", "Ціна", "Вага"));
        Console.WriteLine("-------------------------------");
        for (int i = 0; i < listStorage.Count; i++)
        {
            Console.WriteLine("| {0,0} | {1,-10} | {2,-5} | {3,-5}", i, listStorage[i].name, listStorage[i].price, listStorage[i].weight);
        }
        Console.WriteLine("-------------------------------");
    }

    public void PuchaseOutput()
    {
        Console.WriteLine("-------------------------------");
        Console.WriteLine(String.Format("| {0,0} | {1,-10} | {2,-5} | {3,-5}", "#", "Назва", "Ціна", "Вага"));
        Console.WriteLine("-------------------------------");
        for (int i = 0; i < listPurchase.Count; i++)
        {
            Console.WriteLine("| {0,0} | {1,-10} | {2,-5} | {3,-5}", i, listPurchase[i].name, listPurchase[i].price, listPurchase[i].weight);
        }
        Console.WriteLine("-------------------------------");
    }
}