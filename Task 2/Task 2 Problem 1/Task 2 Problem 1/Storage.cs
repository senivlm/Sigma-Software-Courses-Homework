static class Storage
{
    public static List<Product> listProduct = new();
    public static void Append(Product product)
    {
        listProduct.Add(product);
    }
}