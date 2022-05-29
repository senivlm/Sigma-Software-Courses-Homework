class Storage
{
    public List<Product> listProduct;
    public Storage() { listProduct = new List<Product>(); }
    public void append(Product product)
    {
        listProduct.Add(product);
    }
}