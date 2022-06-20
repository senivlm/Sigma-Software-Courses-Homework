class Product
{
    private string _name;
    private decimal _price;
    private int _weight;

    public string Name
    {
        get => _name;
        set
        {
            if (!value.Any(char.IsDigit))
            {
                _name = value;
            }
            else
            {
                throw new Exception($"Назва продукту не може містити числа! (\"{value}\")");
            }
        }
    }
    public decimal Price { get; set; }
    public int Weight { get; set; }

    public Product(string name, int weight)
    {
        Name = name;
        Weight = weight;
        if (Storage.FindPriceForProduct(name) != null)
        {
            Price = (decimal)(weight * Storage.FindPriceForProduct(name)/1000);
        }
        else
        {
            Storage.GetProductPriceInDialog(name);
        }
    }
}