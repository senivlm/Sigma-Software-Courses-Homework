static class Storage
{
    #region Variables
    public static List<Product> listProduct = new();
    #endregion

    #region Methods
      // А де поділись всі методи?
    public static void Append(Product product)
    {
        listProduct.Add(product);
    }
    #endregion
}
