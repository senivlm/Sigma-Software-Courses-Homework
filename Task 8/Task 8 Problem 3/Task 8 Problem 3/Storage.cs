static class Storage
{
    #region Variables
    public static List<Product> listProduct = new();
    #endregion

    #region Methods
    public static void Append(Product product)
    {
        listProduct.Add(product);
    }
    #endregion
}