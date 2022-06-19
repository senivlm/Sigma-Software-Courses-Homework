static class Storage
{
    #region Variables
    private static List<Product> listProduct = new(); // !
    private static Dictionary<string, List<Product>> dictionaryProducts = new()
    {
        {"Основний", listProduct }
    };
    #endregion

    #region Methods
    public static void Append(string name, Product product)
    {
        dictionaryProducts[name].Add(product);
    }

    public static List<Product> GetListProducts(string name)
    {
        return dictionaryProducts[name];
    }

    public static void SetListProducts(string name, List<Product> products)
    {
        dictionaryProducts[name] = products;
    }

    public static void AddListProducts(string name)
    {
        List<Product> products = new();
        dictionaryProducts.Add(name, products);
    }

    public static int GetAmountLists()
    {
        return dictionaryProducts.Count;
    }

    public static Dictionary<string, List<Product>> GetDictionary()
    {
        return dictionaryProducts;
    }

    public static List<Product> GetExclusive(string key1, string key2)
    {
        List<Product> res = new();
        res.AddRange(dictionaryProducts[key1]);
        foreach (Product product1 in dictionaryProducts[key1])
        {
            foreach (Product product2 in dictionaryProducts[key2])
            {
                if (product1.GetHashCode() == product2.GetHashCode())
                {
                    res.Remove(product1);
                }
            }
        }
        return res;
    }

    public static List<Product> GetCommon(string key1, string key2)
    {
        List<Product> res = new();
        foreach (Product product1 in dictionaryProducts[key1])
        {
            foreach (Product product2 in dictionaryProducts[key2])
            {
                if (product1.GetHashCode() == product2.GetHashCode())
                {
                    res.Add(product1);
                }
            }
        }
        return res;
    }

    public static List<Product> GetMerged(string key1, string key2)
    {
        List<Product> res = new();
        foreach (Product product1 in dictionaryProducts[key1])
        {
            foreach (Product product2 in dictionaryProducts[key2])
            {
                bool notDupe = true;
                foreach (Product product3 in res)
                {
                    if (product3.GetHashCode() == product2.GetHashCode())
                    {
                        notDupe = false;
                    }
                }
                if (product1.GetHashCode() != product2.GetHashCode() && notDupe)
                {
                    res.Add(product2);
                }
            }
        }
        return res;
    }
    #endregion
}