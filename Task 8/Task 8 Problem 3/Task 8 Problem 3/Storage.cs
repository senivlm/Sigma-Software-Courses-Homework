static class Storage
{
    #region Variables
    private static List<Product> listProduct = new(); // !
    private static Dictionary<string, List<Product>> listsProducts = new()
    {
        {"Основний", listProduct }
    };
    #endregion

    #region Methods
    public static void Append(string name, Product product)
    {
        listsProducts[name].Add(product);
    }

    public static List<Product> GetListProducts(string name)
    {
        return listsProducts[name];
    }

    public static void SetListProducts(string name, List<Product> products)
    {
        listsProducts[name] = products;
    }

    public static void AddListProducts(string name)
    {
        List<Product> products = new();
        listsProducts.Add(name, products);
    }

    public static int GetAmountLists()
    {
        return listsProducts.Count;
    }

    public static Dictionary<string, List<Product>> GetDictionary()
    {
        return listsProducts;
    }
    #endregion
}