class Storage
{
    public List<Product> listProduct;
    public Storage() { listProduct = new List<Product>(); }
    public void Append(Product product)
    {
        listProduct.Add(product);
    }
}